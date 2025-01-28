using System.Text.Json;
using System.Text.Json.Serialization;

using Webmaster442.WindowsTerminal.Internals;

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
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
            TypeInfoResolver = TerminalFragmentGenerationContext.Default
        };
        options.Converters.Add(new JsonStringEnumConverter<TerminalBackgroundImageAlignment>(JsonNamingPolicy.CamelCase));
        options.Converters.Add(new JsonStringEnumConverter<TerminalBackgroundImageStretchMode>(JsonNamingPolicy.CamelCase));
        return options;
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
            => Directory.GetFiles(_localFragments, "*.json", SearchOption.AllDirectories);

        /// <summary>
        /// Returns true, if a JSON Fragment extextension is installed
        /// </summary>
        /// <param name="appName">App name that installs the fragment</param>
        /// <param name="fragmentName">fragment json name</param>
        /// <returns>True, if extension is installed</returns>
        public static bool IsFragmentInstalled(string appName, string fragmentName)
            => File.Exists(Path.Combine(_localFragments, appName, Path.ChangeExtension(fragmentName, ".json")));

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
                var filePath = Path.Combine(_localFragments, appName, Path.ChangeExtension(fragmentName, ".json"));
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
                await JsonSerializer.SerializeAsync(stream, terminalFragment, typeof(TerminalFragment), TerminalFragmentGenerationContext.Default);
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
            return await JsonSerializer.DeserializeAsync<TerminalFragment>(stream, TerminalFragmentGenerationContext.Default.TerminalFragment);
        }
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
    /// Check if the current program is running inside the Windows Terminal
    /// </summary>
    /// <returns>True, if App is running inside windows terminal</returns>
    public static bool IsRunningInsideWindowsTerminal()
        => Environment.GetEnvironmentVariable("WT_SESSION") != null;

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
