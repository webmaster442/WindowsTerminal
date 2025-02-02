// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// This sets how the background image aligns to the boundaries of the window.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<TerminalBackgroundImageAlignment>))]
public enum TerminalBackgroundImageAlignment
{
    /// <summary>
    /// The image is centered in the window.
    /// </summary>
    [JsonStringEnumMemberName("center")]
    Center,
    /// <summary>
    /// The image is aligned to the left of the window.
    /// </summary>
    [JsonStringEnumMemberName("left")]
    Left,
    /// <summary>
    /// The image is aligned to the top of the window.
    /// </summary>
    [JsonStringEnumMemberName("top")]
    Top,
    /// <summary>
    /// The image is aligned to the right of the window.
    /// </summary>
    [JsonStringEnumMemberName("right")]
    Right,
    /// <summary>
    /// The image is aligned to the bottom of the window.
    /// </summary>
    [JsonStringEnumMemberName("bottom")]
    Bottom,
    /// <summary>
    /// The image is aligned to the top left corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("topLeft")]
    TopLeft,
    /// <summary>
    /// The image is aligned to the top right corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("topRight")]
    TopRight,
    /// <summary>
    /// The image is aligned to the bottom left corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("bottomLeft")]
    BottomLeft,
    /// <summary>
    /// The image is aligned to the bottom right corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("bottomRight")]
    BottomRight,
}
