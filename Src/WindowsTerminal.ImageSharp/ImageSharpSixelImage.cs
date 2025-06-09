// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace Webmaster442.WindowsTerminal.ImageSharp;

/// <summary>
/// An implementation of <see cref="ISixelImage"/> using SixLabors.ImageSharp for image processing.
/// </summary>
public sealed class ImageSharpSixelImage : ISixelImage
{
    private readonly ImageFrame<Rgba32> _data;

    /// <inheritdoc/>
    public int Width => _data.Width;

    /// <inheritdoc/>
    public int Height => _data.Height;

    /// <inheritdoc/>
    public Color GetColor(int x, int y)
    {
        var pixel = _data[x, y];
        return new Color(pixel.R, pixel.G, pixel.B);
    }

    private ImageSharpSixelImage(Image<Rgba32> image, SixelOptions options)
    {
        var terminalSize = Terminal.GetTerminalWindowSize();

        if (!options.MaxSize.HasValue)
            options.MaxSize = terminalSize;

        var calculated = Size.GetSize(new Size(options.MaxSize.Value.Width, options.MaxSize.Value.Height),
                                      new Size(image.Width, image.Height),
                                      options.SizeMode);

        var size = new SixLabors.ImageSharp.Size(calculated.Width, calculated.Height);

        image.Mutate(ctx =>
        {
            ctx.Resize(new ResizeOptions()
            {
                Sampler = KnownResamplers.Bicubic,
                Size = size,
                Mode = ResizeMode.Manual,
                TargetRectangle = new Rectangle(new Point(), size),
                PremultiplyAlpha = true,
            });

            // Sixel supports 256 colors max
            ctx.Quantize(new OctreeQuantizer(new()
            {
                MaxColors = options.Colors,
            }));
        });
        _data = image.Frames[0];
    }

    /// <inheritdoc/>
    public static ISixelImage FromFile(string filePath, SixelOptions? sixelOptions = null)
    {
        var image = Image.Load<Rgba32>(filePath);
        return new ImageSharpSixelImage(image, sixelOptions ?? SixelOptions.Default);
    }

    /// <inheritdoc/>
    public static ISixelImage FromStream(Stream stream, SixelOptions? sixelOptions = null)
    {
        var image = Image.Load<Rgba32>(stream);
        return new ImageSharpSixelImage(image, sixelOptions ?? SixelOptions.Default);
    }

    /// <summary>
    /// Encode the image to a Sixel string representation.
    /// </summary>
    /// <returns>Sixel representation of the image</returns>
    public override string ToString()
        => SixelEncoder.Encode(this);
}
