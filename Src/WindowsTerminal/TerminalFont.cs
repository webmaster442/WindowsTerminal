namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Represents a font used in the terminal
/// </summary>
public sealed class TerminalFont
{
    /// <summary>
    /// This is the name of the font face used in the profile. The terminal will try to fallback to Consolas if this can't be found or is invalid.
    /// </summary>
    public string? Face { get; init; }
    /// <summary>
    /// This sets the profile's font size in points.
    /// </summary>
    public int Size { get; init; }
    /// <summary>
    /// This sets the weight (lightness or heaviness of the strokes) for the profile's font.
    /// </summary>
    public TerminalFontWeight Weight { get; init; } = TerminalFontWeight.Normal;

}
