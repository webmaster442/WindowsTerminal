// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Weight (lightness or heaviness of the strokes) of  a Font
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<TerminalFontWeight>))]
public enum TerminalFontWeight
{
    /// <summary>
    /// Normal font weight
    /// </summary>
    [JsonStringEnumMemberName("normal")]
    Normal,
    /// <summary>
    /// Thin font weight
    /// </summary>
    [JsonStringEnumMemberName("thin")]
    Thin,
    /// <summary>
    /// Extra light font weight
    /// </summary>
    [JsonStringEnumMemberName("extra-light")]
    ExtraLight,
    /// <summary>
    /// Light font weight
    /// </summary>
    [JsonStringEnumMemberName("light")]
    Light,
    /// <summary>
    /// Semi light font weight
    /// </summary>
    [JsonStringEnumMemberName("semi-light")]
    SemiLight,
    /// <summary>
    /// Medium font weight
    /// </summary>
    [JsonStringEnumMemberName("medium")]
    Medium,
    /// <summary>
    /// Semi bold font weight
    /// </summary>
    [JsonStringEnumMemberName("semi-bold")]
    SemiBold,
    /// <summary>
    /// Bold font weight
    /// </summary>
    [JsonStringEnumMemberName("bold")]
    Bold,
    /// <summary>
    /// Extra bold font weight
    /// </summary>
    [JsonStringEnumMemberName("extra-bold")]
    ExtraBold,
    /// <summary>
    /// Black font weight
    /// </summary>
    [JsonStringEnumMemberName("black")]
    Black,
    /// <summary>
    /// Extra black font weight
    /// </summary>
    [JsonStringEnumMemberName("extra-black")]
    ExtraBlack,
}