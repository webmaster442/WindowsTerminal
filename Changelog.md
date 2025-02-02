# Next

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