// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Controls image to sixel conversion options
/// </summary>
public record struct SixelOptions
{
    /// <summary>
    /// Default options
    /// </summary>
    public static readonly SixelOptions Default = new();

    /// <summary>
    /// Maximum size. If the image is greater than this size, it will be resized
    /// in a way specified by the SizeMode property. If null, then terminal window size is used.
    /// </summary>
    public (int Width, int Height)? MaxSize { get; set; }

    /// <summary>
    /// Gets or sets the image sizeing mode
    /// </summary>
    public SizeMode SizeMode { get; set; }

    /// <summary>
    /// Gets or sets the number of colors to use in the sixel image
    /// Maximum is 256
    /// </summary>
    public int Colors
    {
        get => field;
        set
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(value, 1);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 256);
            field = value;
        }
    }

    /// <summary>
    /// Creates a new instance of SixelOptions
    /// </summary>
    public SixelOptions()
    {
        MaxSize = null;
        SizeMode = SizeMode.None;
        Colors = 256;
    }
}
