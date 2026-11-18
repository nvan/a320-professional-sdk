using System.Globalization;

namespace NVAN.A320.Sdk.Client;

/// <summary>
/// The value of a dataref as sent by Systems: a number (bool, int and float datarefs) or a text (string datarefs).
/// </summary>
/// <remarks>
/// Bools travel as 0 / 1. Float datarefs are single precision in Systems and travel as the exact double of that float
/// (e.g. 26.2 arrives as 26.200000762939453): use <see cref="AsFloat"/> to get the value Systems holds.
/// </remarks>
public readonly struct DatarefValue : IEquatable<DatarefValue>
{
    private readonly double _number;
    private readonly string? _text;

    private DatarefValue(double number, string? text)
    {
        _number = number;
        _text = text;
    }

    /// <summary>A numeric value (bool, int or float dataref).</summary>
    public static DatarefValue FromNumber(double number) => new(number, null);

    /// <summary>A text value (string dataref).</summary>
    public static DatarefValue FromText(string text) => new(double.NaN, text ?? throw new ArgumentNullException(nameof(text)));

    /// <summary>True for a string dataref's value.</summary>
    public bool IsText => _text is not null;

    /// <summary>The number as received (NaN for a text value).</summary>
    public double Number => _number;

    /// <summary>The text (null for a numeric value).</summary>
    public string? Text => _text;

    /// <summary>A bool dataref's value (any non-zero number is true, as Systems does).</summary>
    /// <exception cref="InvalidOperationException">The value is a text.</exception>
    public bool AsBool() => RequireNumber() != 0;

    /// <summary>An int dataref's value (rounded to the nearest whole number, as Systems does when it is written).</summary>
    /// <exception cref="InvalidOperationException">The value is a text.</exception>
    public int AsInt() => (int)Math.Round(RequireNumber());

    /// <summary>The number as a double.</summary>
    /// <exception cref="InvalidOperationException">The value is a text.</exception>
    public double AsDouble() => RequireNumber();

    /// <summary>The number as the single-precision float Systems holds (26.2f rather than 26.200000762939453).</summary>
    /// <exception cref="InvalidOperationException">The value is a text.</exception>
    public float AsFloat() => (float)RequireNumber();

    /// <summary>
    /// The text of a string dataref, or the number formatted with the invariant culture (a float dataref's value
    /// with single precision: "26.2", not "26.200000762939453").
    /// </summary>
    public string AsString()
    {
        if (_text is not null) return _text;
        var single = (float)_number;
        return single == _number
            ? single.ToString(CultureInfo.InvariantCulture)
            : _number.ToString(CultureInfo.InvariantCulture);
    }

    private double RequireNumber() =>
        _text is null ? _number : throw new InvalidOperationException("This dataref holds a string; use AsString()");

    /// <inheritdoc/>
    public bool Equals(DatarefValue other) =>
        _text is null ? other._text is null && _number.Equals(other._number) : _text == other._text;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is DatarefValue other && Equals(other);

    /// <inheritdoc/>
    public override int GetHashCode() => _text?.GetHashCode(StringComparison.Ordinal) ?? _number.GetHashCode();

    /// <summary>Same as <see cref="AsString"/>.</summary>
    public override string ToString() => AsString();

    /// <summary>Equality.</summary>
    public static bool operator ==(DatarefValue left, DatarefValue right) => left.Equals(right);

    /// <summary>Inequality.</summary>
    public static bool operator !=(DatarefValue left, DatarefValue right) => !left.Equals(right);
}
