﻿using Webmaster442.WindowsTerminal.Internals;

namespace Webmaster442.WindowsTerminal.Wigets;

/// <summary>
/// Pager options
/// </summary>
public sealed class PagerOptions
{
    /// <summary>
    /// Default pager options
    /// </summary>
    public static readonly PagerOptions Default = new()
    {
        PageHeight = Console.WindowHeight - 2,
        PageWidth = Console.WindowWidth,
    };

    /// <summary>
    /// Line formatter. Before displaying a line, this function will be called to format the line
    /// </summary>
    public Func<string, string> LineFormatter { get; set; } = DefaultFormatter;

    /// <summary>
    /// Gets or sets the height of the page
    /// </summary>
    public int PageHeight
    {
        get => field;
        set => field = value.Restrict(0, int.MaxValue);
    }

    /// <summary>
    /// Gets or sets the width of the page
    /// </summary>
    public int PageWidth 
    {
        get => field;
        set => field = value.Restrict(0, int.MaxValue);
    }
    private static string DefaultFormatter(string arg)
        => arg;
}