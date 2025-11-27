// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Formatted text output builder
/// </summary>
public sealed class TerminalFormattedStringBuilder
{
    private readonly StringBuilder _builder;

    /// <summary>
    /// Create a new instance of TerminalFormattedStringBuilder
    /// </summary>
    public TerminalFormattedStringBuilder()
    {
        _builder = new(4096);
    }

    /// <summary>
    /// Append a text to the formatted string
    /// </summary>
    /// <param name="text">text</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder Append(string text)
    {
        _builder.Append(text);
        return this;
    }

    /// <summary>
    ///  Appends the string representation of a specified System.Char object to this instance.
    /// </summary>
    /// <param name="chr">The UTF-16-encoded code unit to append.</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder Append(char chr)
    {
        _builder.Append(chr);
        return this;
    }

    /// <summary>
    /// Appends a specified number of copies of the string representation of a Unicode character to this instance.
    /// </summary>
    /// <param name="chr">The UTF-16-encoded code unit to append.</param>
    /// <param name="repeatCount">The number of times to append chr.</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder Append(char chr, int repeatCount)
    {
        _builder.Append(chr, repeatCount);
        return this;
    }

    /// <summary>
    /// Appends the string representation of a specified object to this instance.
    /// </summary>
    /// <param name="obj">object to append</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder Append(object? obj)
    {
        _builder.Append(obj);
        return this;
    }

    /// <summary>
    ///  Appends the string returned by processing a composite format string, which contains zero or more format items,
    ///  to this instance. Each format item is replaced by  the string representation of a corresponding argument in a parameter array.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An array of objects to format.</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendFormat([StringSyntax("CompositeFormat")] string format, params object?[] args)
    {
        _builder.AppendFormat(format, args);
        return this;
    }

    /// <summary>
    /// Concatenates and appends the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <typeparam name="T">The type of the members of values.</typeparam>
    /// <param name="separator">The character to use as a separator. separator is included in the concatenated and appended strings only if values has more than one element.</param>
    /// <param name="values">A collection that contains the objects to concatenate and append to the current TerminalFormattedStringBuilder</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
    {
        _builder.AppendJoin(separator, values);
        return this;
    }

    /// <summary>
    /// Concatenates and appends the members of a collection, using the specified separator between each member.
    /// </summary>
    /// <typeparam name="T">The type of the members of values.</typeparam>
    /// <param name="separator">The string to use as a separator. separator is included in the concatenated and appended strings only if values has more than one element.</param>
    /// <param name="values">A collection that contains the objects to concatenate and append to the current TerminalFormattedStringBuilder</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendJoin<T>(string? separator, IEnumerable<T> values)
    {
        _builder.AppendJoin(separator, values);
        return this;
    }

    /// <summary>
    /// Append a line to the formatted string
    /// </summary>
    /// <param name="text">text</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendLine(string text)
    {
        _builder.AppendLine(text);
        return this;
    }

    /// <summary>
    /// Append a line to the formatted string
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendLine()
    {
        _builder.AppendLine();
        return this;
    }

    /// <summary>
    /// Append a clickable link
    /// </summary>
    /// <param name="link">link url</param>
    /// <param name="text">link display text</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendLink(string link, string text)
    {
        _builder.Append($"\e]8;;{link}\e\\{text}\e]8;;\e\\");
        return this;
    }

    /// <summary>
    /// Append a clickable link
    /// </summary>
    /// <param name="uri">link url</param>
    /// <param name="text">link display text</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder AppendLink(Uri uri, string text)
    {
        _builder.Append($"\e]8;;{uri}\e\\{text}\e]8;;\e\\");
        return this;
    }

    /// <summary>
    /// Clear internal buffer
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder New()
    {
        _builder.Clear();
        return this;
    }

    /// <summary>
    /// Reset all formatting
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder ResetFormat()
    {
        _builder.Append("\e[0m");
        return this;
    }

    /// <summary>
    /// Convert the formatted string to a string
    /// </summary>
    /// <returns>a string with ANSI escape codes</returns>
    public override string ToString()
        => _builder.ToString();

    /// <summary>
    /// Set background color to a standard color
    /// </summary>
    /// <param name="color">Color to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithBackgroundColor(TerminalColor color)
    {
        _builder.Append(ToBackgroundColor(color));
        return this;
    }

    /// <summary>
    /// Set background color to a standard color
    /// </summary>
    /// <param name="color">Color to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithBackgroundColor(ConsoleColor color)
        => WithBackgroundColor(ToTerminalColor(color));

    /// <summary>
    /// Set background color to a 24 bit RGB color
    /// </summary>
    /// <param name="color">color in hex format (E.g: #000000) or rgb format (E.g: rgb(0, 0, 0)) or hsl format. (E.g: hsl(0, 0%, 0%))</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    /// <exception cref="FormatException">The color was not one of the supported formats.</exception>
    public TerminalFormattedStringBuilder WithBackgroundColor(string color)
    {
        var parsed = Color.Parse(color, null);
        return WithBackgroundColor(parsed);
    }

    /// <summary>
    /// Set background color to a 24 bit RGB color
    /// </summary>
    /// <param name="r">red value</param>
    /// <param name="g">green value</param>
    /// <param name="b">blue value</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithBackgroundColor(byte r, byte g, byte b)
    {
        _builder.Append($"\e[48;2;{r};{g};{b}m");
        return this;
    }

    /// <summary>
    /// Set background color to a 24 bit RGB color
    /// </summary>
    /// <param name="c">An RGB color to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithBackgroundColor(Color c)
    {
        _builder.Append($"\e[48;2;{c.R};{c.G};{c.B}m");
        return this;
    }

    /// <summary>
    /// Set background color to a 256 color index.
    /// Color index must be between 0 and 255
    /// </summary>
    /// <param name="index">color index to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithBackgroundColor(int index)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(index, 255);
        _builder.Append($"\e[48;5;{index}m");
        return this;
    }

    /// <summary>
    /// Set foreground color to a standard color
    /// </summary>
    /// <param name="color">Color to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithForegroundColor(TerminalColor color)
    {
        _builder.Append(ToForegroundColor(color));
        return this;
    }

    /// <summary>
    /// Set foreground color to a standard color
    /// </summary>
    /// <param name="color">Color to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithForegroundColor(ConsoleColor color)
        => WithForegroundColor(ToTerminalColor(color));

    /// <summary>
    /// Set foreground color to a 24 bit RGB color
    /// </summary>
    /// <param name="color">color in hex format (E.g: #ffffff) or rgb format (E.g: rgb(255, 255, 255)) or hsl format. (E.g: hsl(0, 0%, 100%))</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    /// <exception cref="FormatException">The color was not one of the supported formats.</exception>
    public TerminalFormattedStringBuilder WithForegroundColor(string color)
    {
        var parsed = Color.Parse(color, null);
        return WithForegroundColor(parsed);
    }

    /// <summary>
    /// Set foreground color to a 24 bit RGB color
    /// </summary>
    /// <param name="r">red value</param>
    /// <param name="g">green value</param>
    /// <param name="b">blue value</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithForegroundColor(byte r, byte g, byte b)
    {
        _builder.Append($"\e[38;2;{r};{g};{b}m");
        return this;
    }

    /// <summary>
    /// Set foreground color to a 24 bit RGB color
    /// </summary>
    /// <param name="c">An RGB color to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithForegroundColor(Color c)
    {
        _builder.Append($"\e[38;2;{c.R};{c.G};{c.B}m");
        return this;
    }

    /// <summary>
    /// Set foreground color to a 256 color index.
    /// Color index must be between 0 and 255
    /// </summary>
    /// <param name="index">color index to use</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithForegroundColor(int index)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(index, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(index, 255);
        _builder.Append($"\e[38;5;{index}m");
        return this;
    }

    /// <summary>
    /// Inverts text foreground and background colors
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithInverse()
    {
        _builder.Append("\e[7m");
        return this;
    }

    /// <summary>
    /// Set text to italic
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithItalic()
    {
        _builder.Append("\e[3m");
        return this;
    }

    /// <summary>
    /// Set text to bold
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithBold()
    {
        _builder.Append("\e[1m");
        return this;
    }

    /// <summary>
    /// Append a nerd font icon to the output. Terminal needs to have a nerd font installed
    /// Cheat sheet: https://www.nerdfonts.com/cheat-sheet
    /// </summary>
    /// <param name="nerdFont">Nerd font icon codepoint to display</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithNerdFont(int nerdFont)
    {
        _builder.Append(char.ConvertFromUtf32(nerdFont));
        return this;
    }

    /// <summary>
    /// Appends a double-width line control sequence to the formatted string.
    /// </summary>
    public TerminalFormattedStringBuilder WithDoubleWidthLine()
    {
        _builder.Append($"\e#6");
        return this;
    }

    /// <summary>
    /// Appends the specified text as a double-height line to the terminal output and returns the current builder
    /// instance.
    /// </summary>
    /// <param name="line">The text to be rendered as a double-height line.</param>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithDoubleHeightLine(string line)
    {
        _builder.Append($"\e#3{line}\r\n\e#4{line}").AppendLine();
        return this;
    }

    /// <summary>
    /// Set text to underline
    /// </summary>
    /// <returns>A TerminalFormattedStringBuilder to chain formatting</returns>
    public TerminalFormattedStringBuilder WithUnderline()
    {
        _builder.Append("\e[4m");
        return this;
    }

    private static string ToBackgroundColor(TerminalColor color)
    {
        return color switch
        {
            TerminalColor.Black => "\e[40m",
            TerminalColor.Red => "\e[41m",
            TerminalColor.Green => "\e[42m",
            TerminalColor.Yellow => "\e[43m",
            TerminalColor.Blue => "\e[44m",
            TerminalColor.Magenta => "\e[45m",
            TerminalColor.Cyan => "\e[46m",
            TerminalColor.White => "\e[47m",
            TerminalColor.BrightBlack => "\e[40;1m",
            TerminalColor.BrightRed => "\e[41;1m",
            TerminalColor.BrightGreen => "\e[42;1m",
            TerminalColor.BrightYellow => "\e[43;1m",
            TerminalColor.BrightBlue => "\e[44;1m",
            TerminalColor.BrightMagenta => "\e[45;1m",
            TerminalColor.BrightCyan => "\e[46;1m",
            TerminalColor.BrightWhite => "\e[47;1m",
            _ => throw new UnreachableException(),
        };
    }

    private static string ToForegroundColor(TerminalColor color)
    {
        return color switch
        {
            TerminalColor.Black => "\e[30m",
            TerminalColor.Red => "\e[31m",
            TerminalColor.Green => "\e[32m",
            TerminalColor.Yellow => "\e[33m",
            TerminalColor.Blue => "\e[34m",
            TerminalColor.Magenta => "\e[35m",
            TerminalColor.Cyan => "\e[36m",
            TerminalColor.White => "\e[37m",
            TerminalColor.BrightBlack => "\e[30;1m",
            TerminalColor.BrightRed => "\e[31;1m",
            TerminalColor.BrightGreen => "\e[32;1m",
            TerminalColor.BrightYellow => "\e[33;1m",
            TerminalColor.BrightBlue => "\e[34;1m",
            TerminalColor.BrightMagenta => "\e[35;1m",
            TerminalColor.BrightCyan => "\e[36;1m",
            TerminalColor.BrightWhite => "\e[37;1m",
            _ => throw new UnreachableException(),
        };
    }

    private static TerminalColor ToTerminalColor(ConsoleColor consoleColor)
    {
        return consoleColor switch
        {
            ConsoleColor.Black => TerminalColor.Black,
            ConsoleColor.DarkRed => TerminalColor.Red,
            ConsoleColor.DarkGreen => TerminalColor.Green,
            ConsoleColor.DarkYellow => TerminalColor.Yellow,
            ConsoleColor.DarkBlue => TerminalColor.Blue,
            ConsoleColor.DarkMagenta => TerminalColor.Magenta,
            ConsoleColor.DarkCyan => TerminalColor.Cyan,
            ConsoleColor.Gray => TerminalColor.White,
            ConsoleColor.DarkGray => TerminalColor.BrightBlack,
            ConsoleColor.Red => TerminalColor.BrightRed,
            ConsoleColor.Green => TerminalColor.BrightGreen,
            ConsoleColor.Yellow => TerminalColor.BrightYellow,
            ConsoleColor.Blue => TerminalColor.BrightBlue,
            ConsoleColor.Magenta => TerminalColor.BrightMagenta,
            ConsoleColor.Cyan => TerminalColor.BrightCyan,
            ConsoleColor.White => TerminalColor.BrightWhite,
            _ => throw new UnreachableException(),
        };
    }
}
