// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Webmaster442.WindowsTerminal.Internals;

namespace Webmaster442.WindowsTerminal.Fragments;

/// <summary>
/// A profile is a set of settings that can be applied to a terminal window.
/// </summary>
public record class TerminalProfile
{
    /// <summary>
    /// Crates a Terminal profile for Anaconda3
    /// </summary>
    /// <param name="installPath">Anaconda3 install path.</param>
    /// <returns>A terminal profile configured for Anaconda3.</returns>
    public static TerminalProfile CreateAnaconda3(string installPath = "%USERPROFILE%\\Anaconda3")
    {
        return new TerminalProfile
        {
            Name = "Anaconda3",
            CommandLine = $"cmd.exe /k \"{Path.Combine(installPath, "Scripts", "activate.bat")} {installPath}\"",
            Icon = Path.Combine(installPath, "Menu", "anaconda-navigator.ico"),
            StartingDirectory = EnvironmentVariables.UserProfile
        };
    }

    /// <summary>
    /// Crates a Terminal profile for Cmder
    /// </summary>
    /// <param name="installPath">Cmder install path.</param>
    /// <returns>A terminal profile configured for Cmder</returns>
    public static TerminalProfile CreateCmder(string installPath = "%CMDER_ROOT%")
    {
        return new TerminalProfile
        {
            Name = "cmder",
            CommandLine = $"cmd.exe /k {Path.Combine(installPath, "vendor", "init.bat")}",
            Icon = Path.Combine(installPath, "icons", "cmder.ico"),
            StartingDirectory = EnvironmentVariables.UserProfile
        };
    }

    /// <summary>
    /// Creates a Terminal profile for Cygwin
    /// </summary>
    /// <param name="installPath">Cygwin install path.</param>
    /// <returns>A terminal profile configured for Cygwin</returns>
    public static TerminalProfile CreateCygwin(string installPath = "%HOMEDRIVE%\\cygwin64")
    {
        return  new TerminalProfile
        {
            Name = "Cygwin",
            CommandLine = $"{Path.Combine(installPath, "bin", "bash")} --login -i",
            Icon = Path.Combine(installPath, "Cygwin.ico"),
            StartingDirectory = Path.Combine(installPath, "bin")
        };
    }

    /// <summary>
    /// Creates a Terminal profile for Far Manager
    /// </summary>
    /// <param name="installPath">Far manager install path.</param>
    /// <returns>A terminal profile configured for Far</returns>
    public static TerminalProfile CreateFarManager(string installPath = "%ProgramFiles%\\Far Manager")
    {
        return new TerminalProfile
        {
            Name = "Far Manager",
            CommandLine = Path.Combine(installPath, "Far.exe"),
            UseAcrylic = false,
            StartingDirectory = EnvironmentVariables.UserProfile
        };
    }

    /// <summary>
    /// Creates a Terminal profile for Git Bash
    /// </summary>
    /// <param name="installPath">Git bash install path</param>
    /// <returns>A terminal profile configured for git bash</returns>
    public static TerminalProfile CreateGitBash(string installPath = "%ProgramFiles%\\Git")
    {
        return new TerminalProfile
        {
            Name = "Git Bash",
            CommandLine = $"{Path.Combine(installPath, "bin", "bash.exe")} -li",
            Icon = Path.Combine(installPath, "mingw64", "share", "git", "git-for-windows.ico"),
            StartingDirectory = EnvironmentVariables.UserProfile
        };
    }

    /// <summary>
    /// This is the name of the profile that will be displayed in the dropdown menu.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// This is the executable used in the profile.
    /// </summary>
    [JsonPropertyName("commandline")]
    public required string CommandLine { get; init; }

    /// <summary>
    /// This is the directory the shell starts in when it is loaded.
    /// </summary>
    [JsonPropertyName("startingDirectory")]
    public string StartingDirectory { get; init; }

    /// <summary>
    /// This sets the icon that displays within the tab, dropdown menu, jumplist, and tab switcher.
    /// </summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>
    /// If set, this will replace the name as the title to pass to the shell on startup.
    /// Some shells (like bash) may choose to ignore this initial value, while others (Command Prompt, PowerShell) may
    /// use this value over the lifetime of the application.
    /// </summary>
    [JsonPropertyName("tabTitle")]
    public string? TabTitle { get; init; }

    /// <summary>
    /// If set, this profile will automatically open up in an "elevated" window (running as Administrator) by default.
    /// </summary>
    [JsonPropertyName("elevate")]
    public bool Elevate { get; init; }

    /// <summary>
    /// If hidden is set to true, the profile will not appear in the list of profiles.
    /// This can be used to hide default profiles and dynamically generated profiles
    /// </summary>
    [JsonPropertyName("hidden")]
    public bool Hidden { get; init; }

    /// <summary>
    /// This is the name of the color scheme used in the profile. Color schemes are defined in the schemes object.
    /// </summary>
    /// <seealso cref="TerminalSchemes"/>
    /// <seealso cref="TerminalScheme"/>
    [JsonPropertyName("colorScheme")]
    public string? ColorScheme { get; init; }

    /// <summary>
    /// When this is set to true, the window will have an acrylic background. When it's set to false, the window will have a plain, untextured background.
    /// </summary>
    [JsonPropertyName("useAcrylic")]
    public bool UseAcrylic { get; init; }

    /// <summary>
    /// This sets the file location of the image to draw over the window background. The background image can be a .jpg, .png, or .gif file. "desktopWallpaper" will set the background image to the desktop's wallpaper.
    /// </summary>
    [JsonPropertyName("backgroundImage")]
    public string? BackgroundImage { get; init; }

    /// <summary>
    /// This sets the transparency of the background image.
    /// </summary>
    [JsonPropertyName("backgroundImageOpacity")]
    public double BackgroundImageOpacity
    {
        get => field;
        init => field = value.Restrict(0, 1.0);
    }

    /// <summary>
    /// This sets how the background image aligns to the boundaries of the window.
    /// </summary>
    [JsonPropertyName("backgroundImageAlignment")]
    public TerminalBackgroundImageAlignment BackgroundImageAlignment { get; init; }

    /// <summary>
    /// This sets how the background image is resized to fill the window.
    /// </summary>
    [JsonPropertyName("backgroundImageStretchMode")]
    public TerminalBackgroundImageStretchMode BackgroundImageStretchMode { get; init; }

    /// <summary>
    /// This sets the transparency of the window for the profile.
    /// This accepts an integer value from 0-100, representing a "percent opaque".
    /// 100 is "fully opaque", 50 is semi-transparent, and 0 is fully transparent.
    /// </summary>
    [JsonPropertyName("opacity")]
    public int Opacity
    {
        get => field;
        init => field = value.Restrict(0, 100);
    }

    /// <summary>
    /// Show marks on the scrollbar. Enable this option for shell integration.
    /// </summary>
    [JsonPropertyName("showMarksOnScrollbar")]
    public bool ShowMarksOnScrollbar { get; init; }

    /// <summary>
    /// Atuo mark prompts. Enable this option for shell integration.
    /// </summary>
    [JsonPropertyName("autoMarkPrompts")]
    public bool AutoMarkPrompts { get; init; }

    /// <summary>
    /// Font settings for the profile
    /// </summary>
    [JsonPropertyName("font")]
    public TerminalFont? Font { get; init; }

    /// <summary>
    /// Creates a new instance of the TerminalProfile class.
    /// </summary>
    public TerminalProfile()
    {
        StartingDirectory = EnvironmentVariables.UserProfile;
        BackgroundImageStretchMode = TerminalBackgroundImageStretchMode.UniformToFill;
        BackgroundImageAlignment = TerminalBackgroundImageAlignment.Center;
        BackgroundImageOpacity = 1.0;
        Opacity = 100;
    }
}
