// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal.Fragments;

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
    Center = 0,
    /// <summary>
    /// The image is aligned to the left of the window.
    /// </summary>
    [JsonStringEnumMemberName("left")]
    Left = 1,
    /// <summary>
    /// The image is aligned to the top of the window.
    /// </summary>
    [JsonStringEnumMemberName("top")]
    Top = 2,
    /// <summary>
    /// The image is aligned to the right of the window.
    /// </summary>
    [JsonStringEnumMemberName("right")]
    Right = 3,
    /// <summary>
    /// The image is aligned to the bottom of the window.
    /// </summary>
    [JsonStringEnumMemberName("bottom")]
    Bottom = 4,
    /// <summary>
    /// The image is aligned to the top left corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("topLeft")]
    TopLeft = 5,
    /// <summary>
    /// The image is aligned to the top right corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("topRight")]
    TopRight = 6,
    /// <summary>
    /// The image is aligned to the bottom left corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("bottomLeft")]
    BottomLeft = 7,
    /// <summary>
    /// The image is aligned to the bottom right corner of the window.
    /// </summary>
    [JsonStringEnumMemberName("bottomRight")]
    BottomRight = 8,
}
