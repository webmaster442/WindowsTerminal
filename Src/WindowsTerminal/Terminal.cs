﻿// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text;
using System.Text.Json;

using Webmaster442.WindowsTerminal.Fragments;
using Webmaster442.WindowsTerminal.Internals;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Windows terminal interaction class
/// </summary>
public static class Terminal
{
    private static readonly string LocalFragments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows Terminal", "Fragments");

    /// <summary>
    /// Checks if the current output is UTF8 or not
    /// </summary>
    public static bool IsOutputUtf8
        => Console.OutputEncoding.CodePage == Encoding.UTF8.CodePage;

    /// <summary>
    /// Get the current session id
    /// </summary>
    /// <returns>The current windows Session id. Returns null, if program is not running in Windows Terminal</returns>
    public static string? GetCurrentSessionId()
        => Environment.GetEnvironmentVariable("WT_SESSION");

    /// <summary>
    /// Get the specified color of the current terminal palette
    /// </summary>
    /// <param name="colorIndex">Color index to get. Must be between 0 and 15</param>
    /// <returns>24 bit RGB color</returns>
    public static (byte r, byte g, byte b) GetPaletteColor(int colorIndex)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(colorIndex, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(colorIndex, 15);
        string response = GetControlSequenceResponse($"\u001B]4;{colorIndex};?\u0007");
        if (string.IsNullOrEmpty(response))
            return (0, 0, 0);

        var parts = response.Split([':', ';', '/', '\u001b'], StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 6)
            return (0, 0, 0);

        return (byte.Parse(parts[3][..2], System.Globalization.NumberStyles.HexNumber),
                byte.Parse(parts[4][..2], System.Globalization.NumberStyles.HexNumber),
                byte.Parse(parts[5][..2], System.Globalization.NumberStyles.HexNumber));
    }

    /// <summary>
    /// Check if the current program is running inside the Windows Terminal
    /// </summary>
    /// <returns>True, if App is running inside windows terminal</returns>
    public static bool IsRunningInsideWindowsTerminal()
        => Environment.GetEnvironmentVariable("WT_SESSION") != null;

    /// <summary>
    /// Set the progressbar state
    /// </summary>
    /// <param name="progressbarState">Progress bar state</param>
    /// <param name="value">progress bar value</param>
    public static void SetProgressbar(ProgressbarState progressbarState, int value)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(value, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, 100);
        Console.Write($"\e]9;4;{(int)progressbarState};{value}\a");
    }

    /// <summary>
    /// Set the window title
    /// </summary>
    /// <param name="title">Title to set</param>
    public static void SetWindowTitle(string title)
        => Console.Write($"\e]0;{title}\a");

    /// <summary>
    /// Switch to alternate buffer
    /// </summary>
    public static void SwitchToAlternateBuffer()
        => Console.Write("\e[?1049h");

    /// <summary>
    /// Switch to main buffer
    /// </summary>
    public static void SwitchToMainBuffer()
        => Console.Write("\e[?1049l");

    internal static string GetControlSequenceResponse(string controlSequence)
    {
        var response = new StringBuilder();

        try
        {
            Console.Write(controlSequence);
            Thread.Sleep(20);
            while (Console.KeyAvailable)
            {
                char? c = Console.ReadKey(true).KeyChar;
                response.Append(c);
            }
            return response.ToString();
        }
        catch (IOException)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Get the terminal window size in pixels
    /// </summary>
    /// <returns>A value tuple with the terminal window size</returns>
    public static (int width, int hegiht) GetTerminalWindowSize()
    {
        static (int width, int hegiht) DefaultSize()
            => (width: 10 * Console.WindowWidth, hegiht: 20 * Console.WindowHeight);

        var response = GetControlSequenceResponse("\e[16t");

        try
        {
            var parts = response.Split(';', 't');
            return parts.Length > 2
                ? (width: int.Parse(parts[2]) * Console.WindowWidth, hegiht: int.Parse(parts[1]) * Console.WindowHeight)
                : DefaultSize();
        }
        catch (FormatException)
        {
            return DefaultSize();
        }
    }

    /// <summary>
    /// Check if sixel is supported
    /// </summary>
    public static bool IsSixelSupported
    {
        get
        {
            string response = GetControlSequenceResponse("\e[c");
            var parts = response.Split(';');
            return parts.Length > 2 && parts[1] == "4";
        }
    }

    /// <summary>
    /// Fragment extension management
    /// </summary>
    public static class FragmentExtensions
    {

        /// <summary>
        /// Get all local fragment files
        /// </summary>
        /// <returns>an array of terminal json fragments present in the LocalApplicationData</returns>
        public static string[] GetLocalFragments()
            => Directory.GetFiles(LocalFragments, "*.json", SearchOption.AllDirectories);

        /// <summary>
        /// Returns true, if a JSON Fragment extextension is installed
        /// </summary>
        /// <param name="appName">App name that installs the fragment</param>
        /// <param name="fragmentName">fragment json name</param>
        /// <returns>True, if extension is installed</returns>
        public static bool IsFragmentInstalled(string appName, string fragmentName)
            => File.Exists(Path.Combine(LocalFragments, appName, Path.ChangeExtension(fragmentName, ".json")));

        /// <summary>
        /// Read a terminal fragment from the LocalApplicationData
        /// </summary>
        /// <param name="appName">App name</param>
        /// <param name="fragmentName">fragment json file name</param>
        /// <returns>Terminal fragment data</returns>
        public static async Task<TerminalFragment?> ReadFragmentAsync(string appName, string fragmentName)
        {
            var filePath = Path.Combine(LocalFragments, appName, Path.ChangeExtension(fragmentName, ".json"));
            if (!File.Exists(filePath))
            {
                return null;
            }
            await using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<TerminalFragment>(stream, TerminalFragmentGenerationContext.Default.TerminalFragment);
        }

        /// <summary>
        /// Try to install a terminal fragment in the LocalApplicationData
        /// </summary>
        /// <param name="appName">App name</param>
        /// <param name="fragmentName">fragment json file name</param>
        /// <param name="terminalFragment">terminal fragment data</param>
        /// <returns>true, if installation was successfull</returns>
        public static async Task<bool> TryInstallFragmentAsync(string appName, string fragmentName, TerminalFragment terminalFragment)
        {
            try
            {
                var fragmentFolder = Path.Combine(LocalFragments, appName);
                if (!Directory.Exists(fragmentFolder))
                {
                    Directory.CreateDirectory(fragmentFolder);
                }
                var filePath = Path.Combine(fragmentFolder, Path.ChangeExtension(fragmentName, ".json"));
                await using var stream = File.Create(filePath);
                await JsonSerializer.SerializeAsync(stream, terminalFragment, typeof(TerminalFragment), TerminalFragmentGenerationContext.Default);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Try to remove a terminal fragment from the LocalApplicationData
        /// </summary>
        /// <param name="appName">App name that installed the fragment</param>
        /// <param name="fragmentName">fragment json name</param>
        /// <returns>true, if fragment was removed. False if remove failed or fragment does not exist</returns>
        public static bool TryRemoveFragment(string appName, string fragmentName)
        {
            try
            {
                var filePath = Path.Combine(LocalFragments, appName, Path.ChangeExtension(fragmentName, ".json"));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    /// <summary>
    /// Shell integration escape code writing
    /// </summary>
    public static class ShellIntegration
    {
        /// <summary>
        /// The start of the command output / the end of the commandline
        /// </summary>
        public static void CommandExecuted()
            => Console.Write("\e]133;C\a");

        /// <summary>
        /// Signal the end of the command
        /// </summary>
        /// <param name="exitCode">Command exit code</param>
        public static void CommandFinished(int exitCode)
            => Console.Write($"\e]133;D;{exitCode}\a");

        /// <summary>
        /// Signal end of prompt, the start of the commandline
        /// </summary>
        public static void CommandStart()
            => Console.Write("\e]133;B\a");

        /// <summary>
        /// Signal start of prompt
        /// </summary>
        public static void StartOfPrompt()
            => Console.Write("\e]133;A\a");
    }
}
