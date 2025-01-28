using System.Drawing;
using System.Runtime.Versioning;

namespace Webmaster442.WindowsTerminal.Sixel.Drawing;

[SupportedOSPlatform("windows")]
internal sealed class DrawingImageData : IImageData
{
    public DrawingImageData(Bitmap image)
    {
        Width = image.Width;
        Height = image.Height;
        Pixels = new Webmaster442.WindowsTerminal.Color[image.Width, image.Height];
        for (int y = 0; y < image.Height; y++)
        {
            for (int x = 0; x < image.Width; x++)
            {
                var pixel = image.GetPixel(x, y);
                Pixels[x, y] = new Webmaster442.WindowsTerminal.Color()
                {
                    R = pixel.R,
                    G = pixel.G,
                    B = pixel.B,
                };
            }
        }
    }

    public Color[,] Pixels { get; }

    public int Width { get; }

    public int Height { get; }
}