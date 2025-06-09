// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------


using SkiaSharp;

namespace Webmaster442.WindowsTerminal.SkiaSharp;

/// <summary>
/// An implementation of <see cref="ISixelImage"/> using SkiaSharp for image processing.
/// </summary>
public sealed class SkiaSharpSixelImage : ISixelImage, IDisposable
{
    private readonly SKBitmap _data;

    /// <inheritdoc/>
    public int Width => _data.Width;

    /// <inheritdoc/>
    public int Height => _data.Height;

    /// <inheritdoc/>
    public Color GetColor(int x, int y)
    {
        var color = _data.GetPixel(x, y);
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
    public void Dispose()
    {
        _data.Dispose();
    }

    /// <inheritdoc/>
    public override string ToString()
        => SixelEncoder.Encode(this);
}
