// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Windows terminal progress bar state
/// </summary>
public enum ProgressbarState
{
    /// <summary>
    /// default state, and indicates that the progress bar should be hidden.
    /// Use this state when the command is complete, to clear out any progress state.
    /// </summary>
    Hidden = 0,
    /// <summary>
    /// default state, and indicates that the progress bar should be shown in the default color.
    /// </summary>
    Default = 1,
    /// <summary>
    /// Indicates that the progress bar should be shown in an error state.
    /// </summary>
    Error = 2,
    /// <summary>
    /// Indicates that the progress bar should be shown in an indeterminate state. 
    /// This is useful for commands that don't have a progress value, but are still running. This state ignores the progress value.
    /// </summary>
    Indeterminate = 3,
    /// <summary>
    /// Indicates that the progress bar should be shown in a warning state.
    /// </summary>
    Warning = 4,
}
