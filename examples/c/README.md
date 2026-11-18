# Minimal Hardware plugin in C

`example_panel.c` is a whole plugin in one file: one button that presses MASTER WARN and one light that follows the
MASTER WARN light. With no real device, the button is "pressed" every 5 seconds and the light is written to the log.

Linux (gcc or clang):

```sh
gcc -shared -fPIC -I ../../include -o example_panel.so example_panel.c
```

Windows (Visual Studio "x64 Native Tools" prompt, or MinGW-w64):

```bat
cl /LD /I ..\..\include example_panel.c /Fe:example_panel.dll
x86_64-w64-mingw32-gcc -shared -I ../../include -o example_panel.dll example_panel.c
```

Copy `example_panel.so` / `example_panel.dll` into the `plugins` folder next to the Hardware executable and add a
"C example panel" in the Devices tab. Its log is in the Plugins tab.

The same file also builds as C++ (`g++ -x c++ -std=c++20 ...`): the header is `extern "C"`.
