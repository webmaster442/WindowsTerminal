// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Webmaster442.WindowsTerminal.Sixel.ImageSharp;

internal sealed class ImageSharpImageData : IImageData
{
    public ImageSharpImageData(ImageFrame<Rgba32> imageFrame)
    {
        Width = imageFrame.Width;
        Height = imageFrame.Height;
        Pixels = new Webmaster442.WindowsTerminal.Color[imageFrame.Width, imageFrame.Height];
        for (int y = 0; y < imageFrame.Height; y++)
        {
            for (int x = 0; x < imageFrame.Width; x++)
            {
                var pixel = imageFrame[x, y];
                Pixels[x, y] = new Webmaster442.WindowsTerminal.Color()
                {
                    R = pixel.R,
                    G = pixel.G,
                    B = pixel.B,
                };
            }
        }
    }

    public Webmaster442.WindowsTerminal.Color[,] Pixels { get; }

    public int Width { get; }

    public int Height { get; }
}
