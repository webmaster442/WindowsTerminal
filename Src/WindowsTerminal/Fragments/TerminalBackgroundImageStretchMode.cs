// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal.Fragments;

/// <summary>
/// This sets how the background image is resized to fill the window.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<TerminalBackgroundImageStretchMode>))]
public enum TerminalBackgroundImageStretchMode
{
    /// <summary>
    /// The image is not resized.
    /// </summary>
    [JsonStringEnumMemberName("none")]
    None = 1,
    /// <summary>
    /// The image is resized to fill the destination dimensions. The aspect ratio is not preserved.
    /// </summary>
    [JsonStringEnumMemberName("fill")]
    Fill = 2,
    /// <summary>
    /// The image is resized to fit in the destination dimensions while it preserves its native aspect ratio.
    /// </summary>
    [JsonStringEnumMemberName("uniform")]
    Uniform = 3,
    /// <summary>
    /// The image is resized to fill the destination dimensions while it preserves its native aspect ratio.
    /// If the aspect ratio of the destination rectangle differs from the source,
    /// the source content is clipped to fit in the destination dimensions.
    /// </summary>
    [JsonStringEnumMemberName("uniformToFill")]
    UniformToFill = 0,
}
