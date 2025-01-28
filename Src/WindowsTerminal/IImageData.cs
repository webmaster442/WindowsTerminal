// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Image data for sixel encoder
/// </summary>
public interface IImageData
{
    /// <summary>
    /// A Two dimensional array of pixels
    /// </summary>
    Color[,] Pixels { get; }

    /// <summary>
    /// Image width
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Image height
    /// </summary>
    int Height { get; }
}
