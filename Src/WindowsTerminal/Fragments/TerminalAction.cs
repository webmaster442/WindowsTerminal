// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal.Fragments;

/// <summary>
/// A terminal action
/// </summary>
public class TerminalAction
{
    /// <summary>
    /// This is the command executed when the associated keys are pressed.
    /// </summary>
    [JsonPropertyName("command")]
    public required TerminalCommand Command { get; set; }
    /// <summary>
    /// This sets the name that will appear in the command palette. If one isn't provided, the terminal will attempt to automatically generate a name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    /// <summary>
    /// This sets the id of this action. If one isn't provided, the terminal will generate an ID for this action. The ID is used to refer to this action when creating keybindings.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }
}
