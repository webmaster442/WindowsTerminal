using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

namespace Webmaster442.WindowsTerminal.Sixel.Drawing;

/// <summary>
/// System.Drawing extension methods to encode images to sixel
/// </summary>
public static class SystemDrawingExtension
{
    /// <summary>
    /// Encodes an image to a sixel string
    /// </summary>
    /// <param name="encoder">Sixel encoder that is extended</param>
    /// <param name="image">A System.Drawing.Bitmap image</param>
    /// <returns>Sixel encoded string</returns>
    [SupportedOSPlatform("windows")]
    public static string Encode(this SixelEncoder encoder, Bitmap image)
    {
        Size size = Size(image, encoder.GetCellSize());
        var destRect = new Rectangle(0, 0, size.Width, size.Height);
        var resized = new Bitmap(size.Width, size.Height);
        resized.SetResolution(image.HorizontalResolution, image.VerticalResolution);
        using (var g = Graphics.FromImage(resized))
        {
            g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }

            return encoder.Encode(new DrawingImageData(Octree.Quantize(resized, 256)));
        }
    }

    [SupportedOSPlatform("windows")]
    private static Size Size(Bitmap image, (int width, int height) cellSize)
    {
        var maxWidht = Console.WindowWidth * cellSize.width;
        var maxHeight = Console.WindowHeight * cellSize.height;

        if (image.Width > maxWidht)
        {
            var ratio = (double)maxWidht / image.Width;
            return new Size(maxWidht, (int)Math.Round(image.Height * ratio));
        }
        else if (image.Height > maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            return new Size((int)Math.Round(image.Width * ratio), maxHeight);
        }
        else
        {
            return new Size(image.Width, image.Height);
        }
    }
}
