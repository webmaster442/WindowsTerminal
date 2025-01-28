namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Represents an RGB 24-bit color
/// </summary>
public readonly record struct Color
{
    /// <summary>
    /// Red component
    /// </summary>
    public byte R { get; init; }

    /// <summary>
    /// Green component
    /// </summary>
    public byte G { get; init; }

    /// <summary>
    /// Blue component
    /// </summary>
    public byte B { get; init; }
}