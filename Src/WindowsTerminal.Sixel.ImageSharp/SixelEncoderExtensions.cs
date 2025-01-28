// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace Webmaster442.WindowsTerminal.Sixel.ImageSharp;

/// <summary>
/// Sixel encoder extensions
/// </summary>
public static class SixelEncoderExtensions
{
    /// <summary>
    /// Encodes an image to a sixel string
    /// </summary>
    /// <param name="encoder">Sixel encoder that is extended</param>
    /// <param name="image">An RGB image</param>
    /// <returns>Sixel encoded string</returns>
    public static string Encode(this SixelEncoder encoder, Image<Rgba32> image)
    {
        int cellWidth = Console.WindowWidth;
        image.Mutate(ctx =>
        {
            if (cellWidth > 0)
            {
                // Resize the image to the target size
                ctx.Resize(new ResizeOptions()
                {
                    Sampler = KnownResamplers.Bicubic,
                    Size = Size(image, encoder.GetCellSize()),
                    PremultiplyAlpha = false,
                });
            }
            // Sixel supports 256 colors max
            ctx.Quantize(new OctreeQuantizer(new()
            {
                MaxColors = 256,
            }));
        });
        return encoder.Encode(new ImageSharpImageData(image.Frames[0]));
    }

    private static Size Size(Image<Rgba32> image, (int width, int height) cellSize)
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