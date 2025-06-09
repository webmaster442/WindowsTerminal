// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Represents an RGB image that can be encoded into Sixel format.
/// </summary>
public interface ISixelImage
{
    /// <summary>
    /// Image width
    /// </summary>
    int Width { get; }

    /// <summary>
    /// Image height
    /// </summary>
    int Height { get; }

    /// <summary>
    /// Image pixel color at the specified coordinates.
    /// </summary>
    /// <param name="x">Horizonatl coordinate</param>
    /// <param name="y">Vertical coordinate</param>
    /// <returns>Color at given position</returns>
    Color GetColor(int x, int y);

    /// <summary>
    /// Create an ISixelImage from a stream.
    /// </summary>
    /// <param name="stream">Image stream data</param>
    /// <param name="sixelOptions">Sixel conversion options</param>
    /// <returns>An ISixelImage instance</returns>
    public static abstract ISixelImage FromStream(Stream stream, SixelOptions? sixelOptions = null);

    /// <summary>
    /// Create an ISixelImage from a file path.
    /// </summary>
    /// <param name="filePath">Image file path</param>
    /// <param name="sixelOptions">>Sixel conversion options</param>
    /// <returns>An ISixelImage instance</returns>
    public static abstract ISixelImage FromFile(string filePath, SixelOptions? sixelOptions = null);
}
