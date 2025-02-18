# 3.0.0
 - Colors can now be specified in hsl() and rgb() CSS format in the `TerminalFormattedStringBuilder.WithForegroundColor(string color)` and `TerminalFormattedStringBuilder.WithBackgroundColor(string color)` methods.
 - `WindowsTerminal` class now has a `GetPaletteColor(int index)` method, that returns the color of the specified palette index.
- `Sixel.ImageToSixel`: Image is now properly resized, instead of cropped, if the image is larger than the specified size.
- Added `Sixel.GetTerminalWindowSize()` method, that returns the current terminal window size in pixels.
- `Sixel.ImageToSixel`: Removed versions where the `maxSize` can be specied as a tuple. Use the new `Sixel.ImageToSixel` variants, that accept a `SixelOptions` instead.


# 2.0.0

- Added .NET 8 support
- Libary is now AOT compatible
- `TerminalProfile` class now has static factory methods for creating profiles for Anaconda3, Cmder, Cygwin, Far and Gith Bash
- `TerminalFragment` class now has a `ToJson()` method that converts the fragment to a JSON string.
- Nullability changes of `TerminalProfile` class: `Icon`, `TabTitle`, `ColorScheme` and `BackgroundImage` are now nullable and by default have `null` values.
- `TerminalProfile` class new properties:
    - `ShowMarksOnScrollbar`, `AutoMarkPrompts` for Shell integration support
    - `Font` to specify font settings
- Sixel image support via the Webmaster442.Windowsterminal.Sixel package. This package depends on Sixlabors.ImageSharp

# 1.1.1

- Fixes Json fragment generation of enum values

# 1.1.0

- Added support for `char` and `object` based overloads for the `Append` method of `TerminalFormattedStringBuilder`.
- `TerminalFormattedStringBuilder.WithBackgroundColor()` and `TerminalFormattedStringBuilder.WithForegroundColor()` now have overloads that accept `ConsoleColor ` enum values.

# 1.0.0

- Initial Release