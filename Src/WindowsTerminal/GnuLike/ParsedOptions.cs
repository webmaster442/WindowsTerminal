namespace Webmaster442.WindowsTerminal.GnuLike;

/// <summary>
/// Represents the result of parsing command-line input into options, switches, and arguments.
/// </summary>
public class ParsedOptions
{
    /// <summary>
    /// Passed options as key-value pairs. Key is the option name without the option seperator, value is the option value.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Options { get; init; }
    /// <summary>
    /// Parsed switches (options without values).
    /// </summary>
    public required IReadOnlySet<string> Switches { get; init; }
    /// <summary>
    /// Arguments that are not options or switches.
    /// </summary>
    public required IReadOnlyList<string> Arguments { get; init; }
}
