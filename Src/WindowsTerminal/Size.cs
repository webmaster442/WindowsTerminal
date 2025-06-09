namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Represents an image Size
/// </summary>
public readonly record struct Size
{
    /// <summary>
    /// Image Width
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Image Height
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Creates a new Size instance with the specified width and height.
    /// </summary>
    /// <param name="width">width</param>
    /// <param name="height">height</param>
    public Size(int width, int height)
    {
        Width = width;
        Height = height;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{Width}x{Height}";
    }
}
