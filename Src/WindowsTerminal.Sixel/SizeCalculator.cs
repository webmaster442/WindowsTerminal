using System.Diagnostics;

using SixLabors.ImageSharp;

namespace Webmaster442.WindowsTerminal;

internal static class SizeCalculator
{
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