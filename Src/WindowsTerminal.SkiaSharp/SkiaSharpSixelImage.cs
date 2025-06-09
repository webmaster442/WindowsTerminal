// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------


using SkiaSharp;

namespace Webmaster442.WindowsTerminal.SkiaSharp;

/// <summary>
/// An implementation of <see cref="ISixelImage"/> using SkiaSharp for image processing.
/// </summary>
public sealed class SkiaSharpSixelImage : ISixelImage
{
    private readonly SKColor[] _data;

    /// <inheritdoc/>
    public int Width { get; private set; }

    /// <inheritdoc/>
    public int Height { get; private set; }

    /// <inheritdoc/>
    public Color GetColor(int x, int y)
    {
        var color = _data[y * Width + x];
        return new Color(color.Red, color.Green, color.Blue);
    }

    private SkiaSharpSixelImage(SKBitmap bitmap, SixelOptions options)
    {
        var terminalSize = Terminal.GetTerminalWindowSize();

        if (!options.MaxSize.HasValue)
            options.MaxSize = terminalSize;

        var calculated = Size.GetSize(new Size(options.MaxSize.Value.Width, options.MaxSize.Value.Height),
                                      new Size(bitmap.Width, bitmap.Height),
                                      options.SizeMode);


        using var resized = bitmap.Resize(new SKSizeI(calculated.Width, calculated.Height), SKSamplingOptions.Default);
        Width = resized.Width;
        Height = resized.Height;
        _data = Octree.Quantize(resized, options.Colors);
        bitmap.Dispose();
    }



    /// <inheritdoc/>
    public static ISixelImage FromFile(string filePath, SixelOptions? sixelOptions = null)
    {
        return new SkiaSharpSixelImage(SKBitmap.Decode(filePath), sixelOptions ?? SixelOptions.Default);
    }

    /// <inheritdoc/>
    public static ISixelImage FromStream(Stream stream, SixelOptions? sixelOptions = null)
    {
        return new SkiaSharpSixelImage(SKBitmap.Decode(stream), sixelOptions ?? SixelOptions.Default);
    }

    /// <inheritdoc/>
    public override string ToString()
        => SixelEncoder.Encode(this);
}
