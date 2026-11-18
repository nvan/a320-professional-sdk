using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Channels;
using NVAN.A320.Sdk.Client.Internal;

namespace NVAN.A320.Sdk.Client;

/// <summary>
/// Connection to one NVAN A320 Professional Systems over its public WebSocket API (<c>ws://host:8080/api/ws</c>).
/// </summary>
/// <remarks>
/// <para>
/// <b>Connection.</b> The client connects on <see cref="Start"/> (or on the first operation that needs Systems) and
/// keeps reconnecting forever, whatever the start order, when Systems restarts or the network fails (0.5 s after a
/// failure, doubling up to 5 s). After every (re)connection it sends every subscription again (Systems then sends the
/// current value of everything subscribed) and delivers pending pushbutton releases (see <see cref="PressAsync"/>).
/// </para>
/// <para>
/// <b>Requests</b> (<see cref="SetAsync(string, double, CancellationToken)"/>, <see cref="GetAsync"/>...) wait for a
/// connection, then for the reply. If the connection drops after a request was sent, it fails with
/// <see cref="SystemsDisconnectedException"/>.
/// </para>
/// <para>
/// <b>Threading.</b> Every member is thread-safe. Events are raised one at a time, in order, on a background task
/// (never on the caller's thread: marshal to your UI thread yourself). Exceptions thrown by handlers are discarded.
/// </para>
/// </remarks>
public sealed class SystemsClient : IAsyncDisposable, IDisposable
{
    /// <summary>Default TCP port of the API.</summary>
    public const int DefaultPort = 8080;

    /// <summary>Default (and minimum) time a pushbutton is held by <see cref="PressAsync"/>.</summary>
    public static readonly TimeSpan DefaultPressTime = TimeSpan.FromMilliseconds(100);

    private const int MaxMessageBytes = 16 * 1024 * 1024;
    private static readonly TimeSpan ReconnectMinDelay = TimeSpan.FromSeconds(0.5);
    private static readonly TimeSpan ReconnectMaxDelay = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan ConnectTimeout = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(10);

    private readonly Lock _lock = new();
    private readonly Dictionary<string, int> _patterns = new(StringComparer.Ordinal);   // pattern → subscription count
    private readonly List<DatarefSubscription> _subscriptions = new();
    private readonly ValueCache _cache = new();
    private readonly Channel<Action> _events = Channel.CreateUnbounded<Action>(new UnboundedChannelOptions { SingleReader = true });
    private readonly CancellationTokenSource _stop = new();
    private TaskCompletionSource<Connection> _connected = NewConnectedSource();
    private Connection? _connection;
    private Task? _loop;
    private uint? _lastInstanceId;
    private long _nextId;
    private int _generation;
    private bool _disposed;

    /// <summary>Creates a client for the Systems at <paramref name="host"/> (name or IP address). Nothing happens until
    /// <see cref="Start"/> or the first operation.</summary>
    public SystemsClient(string host, int port = DefaultPort)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(host);
        ArgumentOutOfRangeException.ThrowIfLessThan(port, 1);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(port, 65535);
        Address = new UriBuilder("ws", host, port, "/api/ws").Uri;
    }

    /// <summary>The WebSocket address (<c>ws://host:port/api/ws</c>).</summary>
    public Uri Address { get; }

    /// <summary>Current connection state.</summary>
    public ConnectionState State { get; private set; }

    /// <summary>The Systems of the current or last connection (null before the first connection).</summary>
    public SystemsInfo? Info { get; private set; }

    /// <summary>Whether the client is connected right now.</summary>
    public bool IsConnected => State == ConnectionState.Connected;

    /// <summary>Raised when a subscribed dataref's value changes (and for its first value).</summary>
    public event EventHandler<DatarefChangedEventArgs>? ValueChanged;

    /// <summary>Raised when <see cref="State"/> changes.</summary>
    public event EventHandler<ConnectionStateChangedEventArgs>? ConnectionStateChanged;

    // ---- Connection ------------------------------------------------------------------------------------------------

    /// <summary>Starts connecting in the background (does nothing if already started).</summary>
    public void Start()
    {
        lock (_lock)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            if (_loop is not null) return;
            _ = Task.Run(DispatchLoopAsync);
            _loop = Task.Run(() => ConnectionLoopAsync(_stop.Token));
        }
    }

    /// <summary>Starts the client if needed and waits until it is connected.</summary>
    /// <returns>The Systems connected to.</returns>
    public async Task<SystemsInfo> WaitUntilConnectedAsync(CancellationToken cancellationToken = default)
    {
        var connection = await WaitForConnectionAsync(cancellationToken).ConfigureAwait(false);
        return connection.Info!;
    }

    private static TaskCompletionSource<Connection> NewConnectedSource() => new(TaskCreationOptions.RunContinuationsAsynchronously);

    private async Task<Connection> WaitForConnectionAsync(CancellationToken cancellationToken)
    {
        Start();
        Task<Connection> connected;
        lock (_lock)
        {
            if (_connection is { } current) return current;
            connected = _connected.Task;
        }
        return await connected.WaitAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task ConnectionLoopAsync(CancellationToken stop)
    {
        var delay = ReconnectMinDelay;
        while (!stop.IsCancellationRequested)
        {
            SetState(ConnectionState.Connecting, null, false, null);
            Exception? error = null;
            try
            {
                using var socket = new ClientWebSocket();
                socket.Options.Proxy = null;
                // Pings detect a dead connection (Systems sends nothing while nothing changes).
                socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(2);
                socket.Options.KeepAliveTimeout = TimeSpan.FromSeconds(4);
                using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(stop))
                {
                    timeout.CancelAfter(ConnectTimeout);
                    try
                    {
                        await socket.ConnectAsync(Address, timeout.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (!stop.IsCancellationRequested)
                    {
                        throw new TimeoutException($"No answer from {Address} in {ConnectTimeout.TotalSeconds:0} s");
                    }
                }
                var connection = new Connection(socket, Interlocked.Increment(ref _generation));
                var receiver = ReceiveLoopAsync(connection, stop);
                try
                {
                    await HandshakeAsync(connection, stop).ConfigureAwait(false);
                    delay = ReconnectMinDelay;
                    await receiver.ConfigureAwait(false);
                }
                finally
                {
                    Detach(connection);
                    socket.Abort();
                    try { await receiver.ConfigureAwait(false); } catch (Exception) { /* already reported */ }
                }
            }
            catch (OperationCanceledException) when (stop.IsCancellationRequested)
            {
                break;
            }
            catch (Exception e)
            {
                error = _disposed ? null : e;
            }
            SetState(ConnectionState.Disconnected, null, false, error);
            try
            {
                await Task.Delay(delay, stop).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            delay = TimeSpan.FromTicks(Math.Min(delay.Ticks * 2, ReconnectMaxDelay.Ticks));
        }
        SetState(ConnectionState.Disconnected, null, false, null);
    }

    private async Task HandshakeAsync(Connection connection, CancellationToken stop)
    {
        using (var document = JsonDocument.Parse(await RequestOnAsync(connection, id => Protocol.Request("info", id), stop).ConfigureAwait(false)))
            connection.Info = Protocol.SystemsInfo(document.RootElement);
        var info = connection.Info;

        bool restarted;
        lock (_lock)
        {
            restarted = _lastInstanceId is { } last && last != info.InstanceId;
            _lastInstanceId = info.InstanceId;
            Info = info;
        }
        await SyncSubscriptionsAsync(connection, stop).ConfigureAwait(false);

        lock (_lock)
        {
            _connection = connection;
            _connected.TrySetResult(connection);
        }
        // Subscriptions made during the handshake saw no connection: send them now (usually nothing to send).
        await SyncSubscriptionsAsync(connection, stop).ConfigureAwait(false);
        SetState(ConnectionState.Connected, info, restarted, null);
    }

    private void SetState(ConnectionState state, SystemsInfo? info, bool restarted, Exception? error)
    {
        if (State == state && state != ConnectionState.Connected) return;
        State = state;
        var args = new ConnectionStateChangedEventArgs(state, info, restarted, error);
        Post(() => ConnectionStateChanged?.Invoke(this, args));
    }

    private async Task ReceiveLoopAsync(Connection connection, CancellationToken stop)
    {
        await Task.Yield();
        var buffer = new byte[64 * 1024];
        using var message = new MemoryStream();
        try
        {
            while (true)
            {
                var result = await connection.Socket.ReceiveAsync(buffer.AsMemory(), stop).ConfigureAwait(false);
                if (result.MessageType == WebSocketMessageType.Close) throw new SystemsDisconnectedException("Systems closed the connection");
                message.Write(buffer, 0, result.Count);
                if (message.Length > MaxMessageBytes) throw new SystemsDisconnectedException("Message from Systems too large");
                if (!result.EndOfMessage) continue;
                if (result.MessageType == WebSocketMessageType.Text) Handle(connection, message.GetBuffer().AsMemory(0, (int)message.Length));
                message.SetLength(0);
            }
        }
        finally
        {
            Detach(connection);
        }
    }

    // The connection is gone: requests wait for the next one, pending ones fail.
    private void Detach(Connection connection)
    {
        lock (_lock)
        {
            if (_connection == connection) _connection = null;
            if (_connected.Task.IsCompleted) _connected = NewConnectedSource();
        }
        connection.Fail(new SystemsDisconnectedException("Connection to Systems lost"));
    }

    private void Handle(Connection connection, ReadOnlyMemory<byte> payload)
    {
        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(payload);
        }
        catch (JsonException)
        {
            return;
        }
        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object) return;
            var (op, id) = Protocol.Head(root);
            if (op == "values")
            {
                var values = Protocol.Values(root, out var tick);
                Apply(connection.Generation, tick, values);
            }
            else if (id is { } n && connection.Pending.TryRemove(n, out var reply))
            {
                if (op == "error") reply.TrySetException(new SystemsApiException(Protocol.ErrorMessage(root)));
                else reply.TrySetResult(payload.ToArray());
            }
        }
    }

    // Updates the cache with values of subscribed datarefs and raises the change events.
    private void Apply(int generation, long tick, List<KeyValuePair<string, DatarefValue>> values)
    {
        List<DatarefChangedEventArgs>? changes = null;
        lock (_lock)
        {
            foreach (var (path, value) in values)
            {
                if (!IsSubscribed(path)) continue; // e.g. arrived just after an unsubscribe
                if (_cache.Apply(path, value, generation, tick, out var previous))
                    (changes ??= new()).Add(new DatarefChangedEventArgs(path, value, previous, tick));
            }
        }
        if (changes is not null) Post(() => RaiseChanged(changes));
    }

    private bool IsSubscribed(string path)
    {
        foreach (var pattern in _patterns.Keys)
            if (Patterns.Matches(path, pattern)) return true;
        return false;
    }

    private void RaiseChanged(List<DatarefChangedEventArgs> changes)
    {
        DatarefSubscription[] subscriptions;
        lock (_lock) subscriptions = _subscriptions.ToArray();
        foreach (var change in changes)
        {
            Invoke(() => ValueChanged?.Invoke(this, change));
            foreach (var subscription in subscriptions)
                if (subscription.Matches(change.Path)) Invoke(() => subscription.Raise(change));
        }
    }

    private void Post(Action action) => _events.Writer.TryWrite(action);

    private static void Invoke(Action action)
    {
        try
        {
            action();
        }
        catch (Exception)
        {
            // A handler's exception must not stop the events of everybody else.
        }
    }

    private async Task DispatchLoopAsync()
    {
        await foreach (var action in _events.Reader.ReadAllAsync().ConfigureAwait(false)) Invoke(action);
    }

    // ---- Requests --------------------------------------------------------------------------------------------------

    private async Task<byte[]> RequestAsync(Func<long, byte[]> build, CancellationToken cancellationToken)
    {
        var connection = await WaitForConnectionAsync(cancellationToken).ConfigureAwait(false);
        return await RequestOnAsync(connection, build, cancellationToken).ConfigureAwait(false);
    }

    private async Task<byte[]> RequestOnAsync(Connection connection, Func<long, byte[]> build, CancellationToken cancellationToken)
    {
        var id = Interlocked.Increment(ref _nextId);
        var reply = new TaskCompletionSource<byte[]>(TaskCreationOptions.RunContinuationsAsynchronously);
        connection.Pending[id] = reply;
        try
        {
            if (connection.Closed) throw new SystemsDisconnectedException("Connection to Systems lost");
            await connection.SendAsync(build(id), cancellationToken).ConfigureAwait(false);
            try
            {
                return await reply.Task.WaitAsync(RequestTimeout, cancellationToken).ConfigureAwait(false);
            }
            catch (TimeoutException)
            {
                throw new TimeoutException($"No reply from Systems in {RequestTimeout.TotalSeconds:0} s");
            }
        }
        finally
        {
            connection.Pending.TryRemove(id, out _);
        }
    }

    private long NextId() => Interlocked.Increment(ref _nextId);

    private static byte[] SetMessage(long id, string path, DatarefValue value) =>
        value.IsText ? Protocol.Set(id, path, value.Text!) : Protocol.Set(id, path, value.Number);

    // ---- Catalog and one-shot reads ------------------------------------------------------------------------------

    /// <summary>The catalog of every dataref (op <c>catalog</c>): path, panel, type, kind, writable, description.</summary>
    public async Task<IReadOnlyList<DatarefInfo>> GetCatalogAsync(CancellationToken cancellationToken = default)
    {
        var payload = await RequestAsync(id => Protocol.Request("catalog", id), cancellationToken).ConfigureAwait(false);
        using var document = JsonDocument.Parse(payload);
        return Protocol.Catalog(document.RootElement).AsReadOnly();
    }

    /// <summary>Reads the current value of one dataref (op <c>get</c>; no subscription needed).</summary>
    /// <exception cref="KeyNotFoundException">No dataref has that path.</exception>
    public async Task<DatarefValue> GetAsync(string path, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        if (Patterns.IsPrefix(path)) throw new ArgumentException("GetAsync reads one exact path", nameof(path));
        var payload = await RequestAsync(id => Protocol.Paths("get", id, [path]), cancellationToken).ConfigureAwait(false);
        using var document = JsonDocument.Parse(payload);
        foreach (var (name, value) in Protocol.Values(document.RootElement, out _))
            if (name == path) return value;
        throw new KeyNotFoundException($"Unknown dataref {path}");
    }

    // ---- Subscriptions and the value cache -------------------------------------------------------------------------

    /// <summary>
    /// Subscribes to datarefs: exact paths or prefixes ending in '*' (e.g. <c>overhead.elec.*</c>). Returns at once;
    /// the subscription is sent now if connected and again after every reconnection. Values then fill the cache
    /// (<see cref="TryGetValue"/>) and raise change events. Dispose the subscription to unsubscribe.
    /// </summary>
    /// <param name="patterns">Paths or prefixes.</param>
    /// <param name="onChanged">Optional handler, attached before anything is sent so no value is missed.</param>
    public DatarefSubscription Subscribe(IEnumerable<string> patterns, EventHandler<DatarefChangedEventArgs>? onChanged = null)
    {
        var list = Patterns.Validate(patterns);
        var subscription = new DatarefSubscription(this, list);
        if (onChanged is not null) subscription.ValueChanged += onChanged;
        Connection? connection;
        lock (_lock)
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            _subscriptions.Add(subscription);
            foreach (var pattern in list) _patterns[pattern] = _patterns.GetValueOrDefault(pattern) + 1;
            connection = _connection;
        }
        Start();
        if (connection is not null) _ = SyncSubscriptionsQuietlyAsync(connection);
        return subscription;
    }

    /// <summary>
    /// Subscribes like <see cref="Subscribe"/> and waits until Systems has sent the current values: when it returns,
    /// the cache holds every matching dataref.
    /// </summary>
    public async Task<DatarefSubscription> SubscribeAsync(IEnumerable<string> patterns, EventHandler<DatarefChangedEventArgs>? onChanged = null,
        CancellationToken cancellationToken = default)
    {
        var subscription = Subscribe(patterns, onChanged);
        try
        {
            while (true)
            {
                var connection = await WaitForConnectionAsync(cancellationToken).ConfigureAwait(false);
                try
                {
                    await SyncSubscriptionsAsync(connection, cancellationToken).ConfigureAwait(false);
                    var payload = await RequestOnAsync(connection, id => Protocol.Paths("get", id, subscription.Patterns), cancellationToken)
                        .ConfigureAwait(false);
                    using var document = JsonDocument.Parse(payload);
                    var values = Protocol.Values(document.RootElement, out var tick);
                    Apply(connection.Generation, tick, values);
                    return subscription;
                }
                catch (SystemsDisconnectedException)
                {
                    // Reconnecting: the subscription is sent again; wait for the next connection and read the values.
                }
            }
        }
        catch
        {
            subscription.Dispose();
            throw;
        }
    }

    internal void Unsubscribe(DatarefSubscription subscription)
    {
        Connection? connection;
        lock (_lock)
        {
            if (!_subscriptions.Remove(subscription)) return;
            foreach (var pattern in subscription.Patterns)
            {
                var count = _patterns.GetValueOrDefault(pattern) - 1;
                if (count > 0) _patterns[pattern] = count;
                else _patterns.Remove(pattern);
            }
            _cache.RemoveWhere(path => !IsSubscribed(path));
            connection = _connection;
        }
        if (connection is not null) _ = SyncSubscriptionsQuietlyAsync(connection);
    }

    private async Task SyncSubscriptionsQuietlyAsync(Connection connection)
    {
        try
        {
            await SyncSubscriptionsAsync(connection, CancellationToken.None).ConfigureAwait(false);
        }
        catch (Exception)
        {
            // Lost connection: the next one sends every subscription.
        }
    }

    // Brings the connection's server-side subscriptions to the wanted set. Serialized per connection, and the
    // difference is computed at send time, so concurrent subscribes and unsubscribes always end in the right state.
    // Systems keeps one subscribed flag per dataref: unsubscribing a pattern also clears the datarefs another wanted
    // pattern overlaps, so those are subscribed again (Systems then resends their values; the cache drops repeats).
    private async Task SyncSubscriptionsAsync(Connection connection, CancellationToken cancellationToken)
    {
        await connection.SyncGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            string[] remove, add;
            lock (_lock)
            {
                var wanted = _patterns.Keys.ToHashSet(StringComparer.Ordinal);
                remove = connection.Subscribed.Where(p => !wanted.Contains(p)).ToArray();
                add = wanted.Where(p => !connection.Subscribed.Contains(p) || remove.Any(r => Patterns.Overlap(r, p))).ToArray();
                connection.Subscribed.Clear();
                connection.Subscribed.UnionWith(wanted);
            }
            if (remove.Length > 0) await connection.SendAsync(Protocol.Paths("unsubscribe", NextId(), remove), cancellationToken).ConfigureAwait(false);
            if (add.Length > 0) await connection.SendAsync(Protocol.Paths("subscribe", NextId(), add), cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            connection.SyncGate.Release();
        }
    }

    /// <summary>
    /// The last value received of a subscribed dataref. False if it is not subscribed or its value has not arrived
    /// yet. After a disconnection it keeps the last known value until the resync.
    /// </summary>
    public bool TryGetValue(string path, out DatarefValue value)
    {
        lock (_lock) return _cache.TryGet(path, out value);
    }

    /// <summary>The last value received of a subscribed dataref.</summary>
    /// <exception cref="KeyNotFoundException">Not subscribed, or no value received yet.</exception>
    public DatarefValue GetValue(string path) =>
        TryGetValue(path, out var value) ? value : throw new KeyNotFoundException($"No value for {path}: not subscribed or not received yet");

    // ---- Writes ----------------------------------------------------------------------------------------------------

    /// <summary>
    /// Writes a numeric dataref (bool as 0 / 1, int, float) and waits for Systems to accept it. Systems applies it on
    /// its next simulation tick: watch the dataref (or the lights it drives) to see the effect.
    /// </summary>
    /// <exception cref="SystemsApiException">Unknown dataref, read-only, or not a numeric dataref.</exception>
    public Task SetAsync(string path, double value, CancellationToken cancellationToken = default) =>
        SetCoreAsync(path, DatarefValue.FromNumber(value), cancellationToken);

    /// <summary>Writes a bool dataref (sent as 1 / 0). See <see cref="SetAsync(string, double, CancellationToken)"/>.</summary>
    public Task SetAsync(string path, bool value, CancellationToken cancellationToken = default) =>
        SetCoreAsync(path, DatarefValue.FromNumber(value ? 1 : 0), cancellationToken);

    /// <summary>Writes a string dataref. See <see cref="SetAsync(string, double, CancellationToken)"/>.</summary>
    public Task SetAsync(string path, string value, CancellationToken cancellationToken = default) =>
        SetCoreAsync(path, DatarefValue.FromText(value), cancellationToken);

    private Task SetCoreAsync(string path, DatarefValue value, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        if (!value.IsText && !double.IsFinite(value.Number)) throw new ArgumentOutOfRangeException(nameof(value), "Values must be finite");
        return RequestAsync(id => SetMessage(id, path, value), cancellationToken);
    }

    /// <summary>
    /// Presses a momentary pushbutton (e.g. <c>glare.fcu.ap1.pressed</c>): Systems writes 1, and 0 after
    /// <paramref name="hold"/> (default and minimum <see cref="DefaultPressTime"/>, at most 10 s). Returns once Systems
    /// has accepted the press. The release is Systems' own: it happens even if this client goes away.
    /// </summary>
    /// <remarks>
    /// For a latching pushbutton (e.g. <c>overhead.elec.bat1.pressed</c>) write the wanted state with
    /// <see cref="SetAsync(string, bool, CancellationToken)"/>.
    /// </remarks>
    /// <exception cref="SystemsApiException">Unknown dataref, read-only, or not a bool / int dataref.</exception>
    public Task PressAsync(string path, TimeSpan? hold = null, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(path);
        var ms = (int)Math.Clamp((hold ?? DefaultPressTime).TotalMilliseconds, DefaultPressTime.TotalMilliseconds, 10_000);
        return RequestAsync(id => Protocol.Press(id, path, ms), cancellationToken);
    }

    // ---- Disposal --------------------------------------------------------------------------------------------------

    /// <summary>
    /// Closes the connection (up to 1 s) and stops reconnecting. Pending
    /// requests fail.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        Connection? connection;
        lock (_lock)
        {
            if (_disposed) return;
            _disposed = true;
            connection = _connection;
        }
        if (connection is not null)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(1));
            try
            {
                await connection.Socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "bye", timeout.Token).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // Best effort.
            }
        }
        _stop.Cancel();
        if (_loop is not null)
        {
            try { await _loop.ConfigureAwait(false); } catch (Exception) { /* stopping */ }
        }
        lock (_lock) _connected.TrySetException(new ObjectDisposedException(nameof(SystemsClient)));
        _events.Writer.TryComplete(); // queued events are still delivered
        _stop.Dispose();
    }

    /// <summary>Same as <see cref="DisposeAsync"/>, blocking.</summary>
    public void Dispose() => DisposeAsync().AsTask().GetAwaiter().GetResult();

    // One WebSocket connection.
    private sealed class Connection(ClientWebSocket socket, int generation)
    {
        private readonly SemaphoreSlim _sendLock = new(1, 1);
        private volatile bool _closed;

        public ClientWebSocket Socket { get; } = socket;
        public int Generation { get; } = generation;    // values of an older connection are never compared by tick
        public SystemsInfo? Info { get; set; }
        public ConcurrentDictionary<long, TaskCompletionSource<byte[]>> Pending { get; } = new();
        public SemaphoreSlim SyncGate { get; } = new(1, 1);
        public HashSet<string> Subscribed { get; } = new(StringComparer.Ordinal);   // under the client's lock
        public bool Closed => _closed;

        public async Task SendAsync(byte[] message, CancellationToken cancellationToken)
        {
            await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await Socket.SendAsync(message, WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e) when (e is WebSocketException or ObjectDisposedException or IOException or InvalidOperationException)
            {
                throw new SystemsDisconnectedException("Connection to Systems lost", e);
            }
            finally
            {
                _sendLock.Release();
            }
        }

        public void Fail(Exception error)
        {
            _closed = true;
            foreach (var reply in Pending.Values) reply.TrySetException(error);
        }
    }
}
