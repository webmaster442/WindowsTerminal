// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Built in color schemes for Windows Terminal
/// </summary>
public static class TerminalSchemes
{
    /// <summary>
    /// Campbell scheme
    /// </summary>
    public const string Campbell = "Campbell";
    /// <summary>
    /// Campbell Powershell scheme
    /// </summary>
    public const string CampbellPowershell = "Campbell Powershell";
    /// <summary>
    /// One Half Dark scheme
    /// </summary>
    public const string OneHalfDark = "One Half Dark";
    /// <summary>
    /// One Half Light scheme
    /// </summary>
    public const string OneHalfLight = "One Half Light";
    /// <summary>
    /// Vintage scheme
    /// </summary>
    public const string Vintage = "Vintage";
    /// <summary>
    /// Tango Dark scheme
    /// </summary>
    public const string TangoDark = "Tango Dark";
    /// <summary>
    /// Tango Light scheme
    /// </summary>
    public const string TangoLight = "Tango Light";

    /// <summary>
    /// Purplepeter color scheme
    /// https://windowsterminalthemes.dev/?theme=purplepeter
    /// </summary>
    public static readonly TerminalScheme PurplepeterShecme = new()
    {
        Name = "purplepeter",
        Black = "#961947",
        Red = "#ff796d",
        Green = "#99b481",
        Yellow = "#efdfac",
        Blue = "#66d9ef",
        Purple = "#e78fcd",
        Cyan = "#ba8cff",
        White = "#ffba81",
        BrightBlack = "#d62365",
        BrightRed = "#f99f92",
        BrightGreen = "#b4be8f",
        BrightYellow = "#f2e9bf",
        BrightBlue = "#79daed",
        BrightPurple = "#ba91d4",
        BrightCyan = "#a0a0d6",
        BrightWhite = "#b9aed3",
        Background = "#2a1a4a",
        Foreground = "#ece7fa",
        CursorColor = "#c7c7c7",
        SelectionBackground = "#8689c2",
    };

    /// <summary>
    /// Github inspired color scheme
    /// https://windowsterminalthemes.dev/?theme=Github
    /// </summary>
    public static readonly TerminalScheme GithubShecme = new()
    {
        Name = "Github",
        Black = "#3e3e3e",
        Red = "#970b16",
        Green = "#07962a",
        Yellow = "#f8eec7",
        Blue = "#003e8a",
        Purple = "#e94691",
        Cyan = "#89d1ec",
        White = "#ffffff",
        BrightBlack = "#666666",
        BrightRed = "#de0000",
        BrightGreen = "#87d5a2",
        BrightYellow = "#f1d007",
        BrightBlue = "#2e6cba",
        BrightPurple = "#ffa29f",
        BrightCyan = "#1cfafe",
        BrightWhite = "#ffffff",
        Background = "#f4f4f4",
        Foreground = "#3e3e3e",
        SelectionBackground = "#a9c1e2",
        CursorColor = "#3f3f3f"
    };

    /// <summary>
    /// Dracula color scheme
    /// https://windowsterminalthemes.dev/?theme=Dracula
    /// </summary>
    public static readonly TerminalScheme Dracula = new()
    {
        Name = "Dracula",
        Black = "#000000",
        Red = "#ff5555",
        Green = "#50fa7b",
        Yellow = "#f1fa8c",
        Blue = "#bd93f9",
        Purple = "#ff79c6",
        Cyan = "#8be9fd",
        White = "#bbbbbb",
        BrightBlack = "#555555",
        BrightRed = "#ff5555",
        BrightGreen = "#50fa7b",
        BrightYellow = "#f1fa8c",
        BrightBlue = "#bd93f9",
        BrightPurple = "#ff79c6",
        BrightCyan = "#8be9fd",
        BrightWhite = "#ffffff",
        Background = "#1e1f29",
        Foreground = "#f8f8f2",
        SelectionBackground = "#44475a",
        CursorColor = "#bbbbbb"
    };

    /// <summary>
    /// Retrowave color scheme
    /// https://windowsterminalthemes.dev/?theme=Retrowave
    /// </summary>
    public static readonly TerminalScheme Retrowave = new()
    {
        Name = "Retrowave",
        Black = "#181A1F",
        Red = "#FF16B0",
        Green = "#929292",
        Yellow = "#fcee54",
        Blue = "#46BDFF",
        Purple = "#FF92DF",
        Cyan = "#df81fc",
        White = "#FFFFFF",
        BrightBlack = "#FF16B0",
        BrightRed = "#f85353",
        BrightGreen = "#fcee54",
        BrightYellow = "#ffffff",
        BrightBlue = "#46BDFF",
        BrightPurple = "#FF92DF",
        BrightCyan = "#ff901f",
        BrightWhite = "#ffffff",
        Background = "#070825",
        Foreground = "#46BDFF"
    };

    /// <summary>
    /// Coffe theme color scheme
    /// https://windowsterminalthemes.dev/?theme=coffee_theme
    /// </summary>
    public static readonly TerminalScheme CoffeTheme = new()
    {
        Name = "coffee_theme",
        Black = "#000000",
        Red = "#c91b00",
        Green = "#00c200",
        Yellow = "#c7c400",
        Blue = "#0225c7",
        Purple = "#ca30c7",
        Cyan = "#00c5c7",
        White = "#c7c7c7",
        BrightBlack = "#686868",
        BrightRed = "#ff6e67",
        BrightGreen = "#5ffa68",
        BrightYellow = "#fffc67",
        BrightBlue = "#6871ff",
        BrightPurple = "#ff77ff",
        BrightCyan = "#60fdff",
        BrightWhite = "#ffffff",
        Background = "#f5deb3",
        Foreground = "#000000",
        SelectionBackground = "#c1deff",
        CursorColor = "#c7c7c7"
    };
}