// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal.Fragments;

/// <summary>
/// Represents a terminal command
/// </summary>
public sealed class TerminalCommand
{
    internal string? Command { get; }
    internal Dictionary<string, string>? Actions { get; }

    private TerminalCommand(string command)
    {
        Command = command;
    }

    internal TerminalCommand(Dictionary<string, string> parameters)
    {
        Actions = parameters;
    }

    /// <summary>
    /// Creates a new terminal command based on command name
    /// </summary>
    /// <param name="command">A terminal command</param>
    public static implicit operator TerminalCommand(string command)
    {
        return new TerminalCommand(command);
    }

    /// <summary>
    /// This closes all open terminal windows. A confirmation dialog will appear in the current window to ensure you'd like to close all windows.
    /// </summary>
    public static readonly TerminalCommand Quit = "quit";
    /// <summary>
    /// This closes the current window and all tabs within it.
    /// </summary>
    public static readonly TerminalCommand CloseWindow = "closeWindow";
    /// <summary>
    /// Opens the system menu at the top left corner of the window.
    /// </summary>
    public static readonly TerminalCommand OpenSystemMenu = "openSystemMenu";
    /// <summary>
    /// This allows you to switch between full screen and default window sizes.
    /// </summary>
    public static readonly TerminalCommand toggleFullscreen = "toggleFullscreen";
    /// <summary>
    /// This allows you to enter "focus mode", which hides the tabs and title bar.
    /// </summary>
    public static readonly TerminalCommand ToggleFocusMode = "toggleFocusMode";
    /// <summary>
    /// This allows you toggle the "always on top" state of the window. When in "always on top" mode, the window will appear on top of all other non-topmost windows.
    /// </summary>
    public static readonly TerminalCommand ToggleAlwaysOnTop = "toggleAlwaysOnTop";
    /// <summary>
    /// This closes all tabs except for the one at an index. If no index is provided, use the focused tab's index.
    /// </summary>
    public static readonly TerminalCommand CloseOtherTabs = "closeOtherTabs";
    /// <summary>
    /// This closes the tabs following the tab at an index. If no index is provided, use the focused tab's index.
    /// </summary>
    public static readonly TerminalCommand CloseTabsAfter = "closeTabsAfter";
    /// <summary>
    /// This makes a copy of the current tab's profile and directory and opens it. This does not include modified/added ENV VARIABLES.
    /// </summary>
    public static readonly TerminalCommand DuplicateTab = "duplicateTab";
    /// <summary>
    /// This opens the tab to the right of the current one.
    /// </summary>
    public static readonly TerminalCommand NextTab = "nextTab";
    /// <summary>
    /// This opens the tab to the left of the current one.
    /// </summary>
    public static readonly TerminalCommand PrevTab = "prevTab";
    /// <summary>
    /// This command will toggle "broadcast mode" for a pane. When broadcast mode is enabled, all input sent to the pane will be sent to all panes in the same tab. This is useful for sending the same input to multiple panes at once.
    /// As with any action, you can also invoke "broadcast mode" by search for "Toggle broadcast input to all panes" in the Command palette.
    /// </summary>
    public static readonly TerminalCommand ToggleBroadcastInput = "toggleBroadcastInput";
    /// <summary>
    /// This command will open the "right-click" context menu for the active pane. This menu has context-relevant actions for managing panes, copying and pasting, and more.
    /// </summary>
    public static readonly TerminalCommand showContextMenu = "showContextMenu";

    /// <summary>
    /// Send arbitrary text input to the shell. As an example the input "text\n" will write "text" followed by a newline to the shell.
    /// ANSI escape sequences may be used, but escape codes like \x1b must be written as \u001b. For instance "\u001b[A" will behave as if the up arrow button had been pressed.
    /// </summary>
    /// <param name="input">The text input to feed into the shell.</param>
    /// <returns>A command that sends text input to the shell.</returns>
    public static TerminalCommand SendInput(string input)
    {
        return new(new Dictionary<string, string>
        {
            { "action", "sendInput" },
            { "input", input }
        });
    }

    /// <summary>
    /// This changes the opacity of the window. If relative is set to true, it will adjust the opacity relative to the current opacity. Otherwise, it will set the opacity directly to the given opacity
    /// </summary>
    /// <param name="opacity"> 	How opaque the terminal should become or how much the opacity should be changed by, depending on the value of relative</param>
    /// <param name="relative"> 	If true, then adjust the current opacity by the given opacity parameter. If false, set the opacity to exactly that value.</param>
    /// <returns>A command that adjusts opacity</returns>
    public static TerminalCommand AdjustOpacity(int opacity, bool? relative = null)
    {
        var result = new Dictionary<string, string>
        {
            { "action", "adjustOpacity" },
            { "opacity", opacity.ToString() },
        };
        if (relative.HasValue)
        {
            result.Add("relative", relative.Value.ToString());
        }
        return new(result);
    }

    /// <summary>
    /// Changes the active color scheme.
    /// </summary>
    /// <param name="scheme">The name of the color scheme to apply.</param>
    /// <returns></returns>
    public static TerminalCommand SetColorScheme(string scheme)
    {
        return new(new Dictionary<string, string>
        {
            { "action", "setColorScheme" },
            { "colorScheme", scheme }
        });
    }

}