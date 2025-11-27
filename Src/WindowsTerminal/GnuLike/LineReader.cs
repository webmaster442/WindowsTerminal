using Webmaster442.WindowsTerminal.Readline;

namespace Webmaster442.WindowsTerminal.GnuLike;

/// <summary>
/// Provides GNU Readline-like functionality for reading lines of input from the console, including support for auto-completion and history.
/// </summary>
/// <remarks>LineReader enables interactive console input scenarios, such as command-line interfaces, by
/// maintaining a history of entered lines and supporting features like password masking and auto-completion. Instances
/// can be customized with different console drivers and auto-complete handlers to fit various environments. This class
/// is not thread-safe; concurrent access should be synchronized externally if required.</remarks>
public class LineReader
{
    private readonly IConsole _consoleDriver;
    private readonly KeyHandler _keyHandler;

    /// <summary>
    /// Gets or sets a value indicating whether empty lines are added to the command history.
    /// </summary>
    public bool AppendEmptyLinesToHistory { get; set; } = false;

    /// <summary>
    /// Gets the collection of history entries associated with the current instance.
    /// </summary>
    public IList<string> History => _keyHandler.History;

    internal LineReader(KeyHandler keyHandler, IConsole consoleDriver)
    {
        _keyHandler = keyHandler;
        _consoleDriver = consoleDriver;
        _keyHandler.SetConsoleDriver(_consoleDriver);
    }

    /// <summary>
    /// Initializes a new instance of the LineReader class using the specified key handler for console input processing.
    /// </summary>
    /// <param name="keyHandler">The key handler to use for processing console input. Cannot be null.</param>
    public LineReader(KeyHandler keyHandler)
    {
        _keyHandler = keyHandler;
        _consoleDriver = new SystemConsole();
        _keyHandler.SetConsoleDriver(_consoleDriver);
    }

    /// <summary>
    /// Initializes a new instance of the LineReader class with the specified auto-complete handler.
    /// </summary>
    /// <remarks>Use this constructor to enable or disable auto-completion functionality for line input. The
    /// auto-complete handler determines the suggestions shown to the user during input operations.</remarks>
    /// <param name="autoCompleteHandler">An optional handler that provides auto-completion suggestions as the user types. If null, auto-completion is
    /// disabled.</param>
    public LineReader(IAutoCompleteHandler? autoCompleteHandler)
        : this(new KeyHandler(new List<string>(), autoCompleteHandler))
    {
    }

    private string GetText(KeyHandler keyHandler)
    {
        ConsoleKeyInfo keyInfo = _consoleDriver.ReadKey(true);
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            keyHandler.Handle(keyInfo);
            keyInfo = _consoleDriver.ReadKey(true);
        }

        _consoleDriver.WriteLine(string.Empty);
        return keyHandler.Text;
    }

    /// <summary>
    /// Reads a line of input from the console after displaying an optional prompt.
    /// </summary>
    /// <returns>A string containing the line of text entered by the user. Returns an empty string if the user submits no input.</returns>
    public string ReadLine(string prompt = "")
    {
        Console.Write(prompt);
        string text = GetText(_keyHandler);

        if (string.IsNullOrEmpty(text) && AppendEmptyLinesToHistory)
        {
            History.Add(text);
        }
        else
        {
            History.Add(text);
        }

        return text;
    }

    /// <summary>
    /// Reads a password from the console input, displaying the specified prompt and masking the input characters.
    /// </summary>
    /// <returns>A string containing the password entered by the user. The string will be empty if no input is provided.</returns>
    public string ReadPassword(string prompt = "")
    {
        Console.Write(prompt);
        _consoleDriver.PasswordMode = true;
        string text = GetText(_keyHandler);
        _consoleDriver.PasswordMode = false;
        return text;
    }

}
