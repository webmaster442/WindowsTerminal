// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

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
                // Some math to get the target size in pixels and
                // reverse it to cell height that it will consume.
                var pixelWidth = cellWidth * encoder.GetCellSize().width;
                var pixelHeight = (int)Math.Round((double)image.Height / image.Width * pixelWidth);
                // Resize the image to the target size
                ctx.Resize(new ResizeOptions()
                {
                    Sampler = KnownResamplers.Bicubic,
                    Size = new(pixelWidth, pixelHeight),
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
}