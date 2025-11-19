using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster442.WindowsTerminal.Readline;

/// <summary>
/// Represents a combination of a console key and optional modifier keys used to trigger an action.
/// </summary>
/// <remarks>Use this type to define keyboard shortcuts or hotkeys for console applications. A KeyRegistration
/// specifies both the primary key and any required modifier keys (such as Shift, Alt, or Control) that must be pressed
/// together to activate the associated action.
/// </remarks>
public readonly record struct KeyRegistration
{
    /// <summary>
    /// The console key that triggers the action
    /// </summary>
    public  ConsoleKey Key { get;}

    /// <summary>
    /// Console key modifiers that trigger the action
    /// </summary>
    public ConsoleModifiers Modifiers { get; }

    /// <summary>
    /// Initializes a new instance of the KeyRegistration class with the specified console key and modifier combination.
    /// </summary>
    /// <param name="key">The console key to associate with this registration.</param>
    /// <param name="modifiers">The modifier keys (such as Shift, Alt, or Control) that must be pressed in combination with the console key.</param>
    public KeyRegistration(ConsoleKey key, ConsoleModifiers modifiers = ConsoleModifiers.None)
    {
        Key = key;
        Modifiers = modifiers;
    }
}
