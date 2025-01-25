﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Windows terminal interaction class
/// </summary>
public static class WindowsTerminal
{
    private static readonly string _localFragments = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows Terminal", "Fragments");

    private static readonly JsonSerializerOptions _serializerOptions = CreateOptions();

    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        return options;
    }

    /// <summary>
    /// Get all local fragment files
    /// </summary>
    /// <returns>an array of terminal json fragments present in the LocalApplicationData</returns>
    public static string[] GetLocalFragments()
        => Directory.GetFiles(_localFragments, "*.json", SearchOption.AllDirectories);

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
            var fragmentFolder = Path.Combine(_localFragments, appName);
            if (!Directory.Exists(fragmentFolder))
            {
                Directory.CreateDirectory(fragmentFolder);
            }
            var filePath = Path.Combine(fragmentFolder, Path.ChangeExtension(fragmentName, ".json"));
            using var stream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(stream, terminalFragment, _serializerOptions);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Read a terminal fragment from the LocalApplicationData
    /// </summary>
    /// <param name="appName">App name</param>
    /// <param name="fragmentName">fragment json file name</param>
    /// <returns>Terminal fragment data</returns>
    public static async Task<TerminalFragment?> ReadFragmentAsync(string appName, string fragmentName)
    {
        var filePath = Path.Combine(_localFragments, appName, Path.ChangeExtension(fragmentName, ".json"));
        if (!File.Exists(filePath))
        {
            return null;
        }
        using var stream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<TerminalFragment>(stream, _serializerOptions);
    }

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

    /// <summary>
    /// Shell integration escape code writing
    /// </summary>
    public static class ShellIntegration
    {
        /// <summary>
        /// Signal start of prompt
        /// </summary>
        public static void StartOfPrompt()
            => Console.Write("\e]133;A\a");

        /// <summary>
        /// Signal end of prompt, the start of the commandline
        /// </summary>
        public static void CommandStart()
            => Console.Write("\e]133;B\a");

        /// <summary>
        /// The start of the command output / the end of the commandline
        /// </summary>
        public static void CommandExecuted()
            => Console.Write($"\e]133;C\a");

        /// <summary>
        /// Signal the end of the command
        /// </summary>
        /// <param name="exitCode">Command exit code</param>
        public static void CommandFinished(int exitCode)
            => Console.Write($"\e]133;D;{exitCode}\a");
    }
}
