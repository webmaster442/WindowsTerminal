using System.Diagnostics;

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

    /// <summary>
    /// Calculates the size of an image based on the maximum size, image size, and size mode.
    /// </summary>
    /// <param name="maxSize">Maximum avaliable size</param>
    /// <param name="imageSize">Image size</param>
    /// <param name="sizeMode">Size mode</param>
    /// <returns>A final, calculated size</returns>
    public static Size GetSize(Size maxSize, Size imageSize, SizeMode sizeMode)
    {
        return sizeMode switch
        {
            SizeMode.None => imageSize,
            SizeMode.Fit => Fit(maxSize, imageSize),
            SizeMode.FitWidth => FitWidth(maxSize, imageSize),
            SizeMode.FitHeight => FitHeight(maxSize, imageSize),
            SizeMode.Manual => maxSize,
            _ => throw new UnreachableException("Unknown Size mode"),
        };
    }

    private static Size FitHeight(Size maxSize, Size imageSize)
        => new(imageSize.Width * maxSize.Height / imageSize.Height, maxSize.Height);

    private static Size FitWidth(Size maxSize, Size imageSize)
        => new(maxSize.Width, imageSize.Height * maxSize.Width / imageSize.Width);

    private static Size Fit(Size maxSize, Size imageSize)
    {
        double ratoMaxSize = maxSize.Width / (double)maxSize.Height;
        double ratioImage = imageSize.Width / (double)imageSize.Height;

        return ratoMaxSize > ratioImage
            ? FitHeight(maxSize, imageSize)
            : FitWidth(maxSize, imageSize);
    }
}
