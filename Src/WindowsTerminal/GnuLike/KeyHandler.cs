using System.Text;

namespace Webmaster442.WindowsTerminal.GnuLike;

/// <summary>
/// Provides interactive command-line input handling, including cursor movement, text editing, command history
/// navigation, and auto-completion support for console applications.
/// </summary>
public class KeyHandler
{

    private readonly StringBuilder _text;
    private readonly IAutoCompleteHandler? _autoCompleteHandler;
    private readonly IReadOnlyDictionary<KeyRegistration, Action> _keyActions;
    private IConsole _consoleDriver;

    private int _cursorPos;
    private int _cursorLimit;
    private int _historyIndex;
    private ConsoleKeyInfo _keyInfo;
    private IReadOnlyList<string>? _completions;
    private int _completionStart;
    private int _completionsIndex;

    internal void SetCursorPos(int pos)
    {
        _cursorPos = pos;
        _consoleDriver.SetCursorPosition(pos, _consoleDriver.CursorTop);
    }

    /// <summary>
    /// Determines whether the current cursor position is at the start of a line.
    /// </summary>
    /// <returns>true if the cursor is at the beginning of the line; otherwise, false.</returns>
    protected bool IsStartOfLine()
        => _cursorPos == 0;

    /// <summary>
    /// Determines whether the cursor has reached the end of the current line.
    /// </summary>
    /// <returns>true if the cursor position is at the end of the line; otherwise, false.</returns>
    protected bool IsEndOfLine()
        => _cursorPos == _cursorLimit;

    /// <summary>
    /// Determines whether the console cursor is positioned at the end of the current buffer line.
    /// </summary>
    /// <returns>true if the cursor is at the last column of the buffer; otherwise, false.</returns>
    protected bool IsEndOfBuffer()
        => _consoleDriver.CursorLeft == _consoleDriver.BufferWidth - 1;

    /// <summary>
    /// Determines whether the control is currently operating in auto-complete mode.
    /// </summary>
    /// <returns>true if auto-complete mode is active; otherwise, false.</returns>
    protected bool IsInAutoCompleteMode()
        => _completions != null;

    /// <summary>
    /// Moves the cursor one position to the left.
    /// </summary>
    protected void MoveCursorLeft()
        => MoveCursorLeft(1);

    /// <summary>
    /// Moves the cursor to the left by the specified number of positions within the console buffer.
    /// </summary>
    /// <param name="count">The number of positions to move the cursor to the left. Must be non-negative and not greater than the current cursor position.</param>
    protected void MoveCursorLeft(int count)
    {
        if (count > _cursorPos)
            count = _cursorPos;

        if (count > _consoleDriver.CursorLeft)
            _consoleDriver.SetCursorPosition(_consoleDriver.BufferWidth - 1, _consoleDriver.CursorTop - 1);
        else
            _consoleDriver.SetCursorPosition(_consoleDriver.CursorLeft - count, _consoleDriver.CursorTop);

        _cursorPos -= count;
    }

    /// <summary>
    /// Moves the cursor one position to the right within the current input buffer.
    /// </summary>
    protected void MoveCursorRight()
    {
        if (IsEndOfLine())
            return;

        if (IsEndOfBuffer())
            _consoleDriver.SetCursorPosition(0, _consoleDriver.CursorTop + 1);
        else
            _consoleDriver.SetCursorPosition(_consoleDriver.CursorLeft + 1, _consoleDriver.CursorTop);

        _cursorPos++;
    }

    /// <summary>
    /// Moves the cursor to the end of the current line.
    /// </summary>
    protected void MoveCursorEnd()
    {
        while (!IsEndOfLine())
            MoveCursorRight();
    }

    /// <summary>
    /// Clears all characters from the current input line.
    /// </summary>
    protected void ClearLine()
    {
        MoveCursorEnd();
        Backspace(_cursorPos);
    }

    /// <summary>
    /// Writes the specified string to the output, replacing any existing content on the current line.
    /// </summary>
    /// <param name="str">The string to write to the output. If null or empty, the line will be cleared and no characters will be written.</param>
    protected void WriteNewString(string str)
    {
        ClearLine();
        foreach (char character in str)
            WriteChar(character);
    }

    /// <summary>
    /// Writes each character of the specified string to the output destination.
    /// </summary>
    /// <param name="str">The string to write. If <paramref name="str"/> is null or empty, no characters are written.</param>
    protected void WriteString(string str)
    {
        foreach (char character in str)
            WriteChar(character);
    }

    /// <summary>
    /// Writes the current key character to the output if it is not a control character.
    /// </summary>
    /// <remarks>This method ignores control characters and only writes printable key characters. It is
    /// typically used to process user input from a key event, ensuring that only displayable characters are
    /// written.</remarks>
    protected void WriteChar()
    {
        if (!char.IsControl(_keyInfo.KeyChar))
            WriteChar(_keyInfo.KeyChar);
    }

    /// <summary>
    /// Writes the specified character at the current cursor position in the text buffer and updates the console display
    /// accordingly.
    /// </summary>
    /// <param name="c">The character to write at the current cursor position.</param>
    protected void WriteChar(char c)
    {
        if (IsEndOfLine())
        {
            _text.Append(c);
            _consoleDriver.Write(c.ToString());
            _cursorPos++;
        }
        else
        {
            int left = _consoleDriver.CursorLeft;
            int top = _consoleDriver.CursorTop;
            string str = _text.ToString()[_cursorPos..];
            _text.Insert(_cursorPos, c);
            _consoleDriver.Write(c.ToString() + str);
            _consoleDriver.SetCursorPosition(left, top);
            MoveCursorRight();
        }

        _cursorLimit++;
    }

    /// <summary>
    /// Removes a single character from the current input, simulating a backspace operation.
    /// </summary>
    protected void Backspace()
        => Backspace(1);

    /// <summary>
    /// Deletes the specified number of characters to the left of the cursor position in the current text buffer.
    /// </summary>
    /// <param name="count">The number of characters to remove. If greater than the number of characters before the cursor, only the
    /// available characters will be deleted.</param>
    protected void Backspace(int count)
    {
        if (count <= 0)
            return;

        if (count > _cursorPos)
            count = _cursorPos;

        MoveCursorLeft(count);

        int index = _cursorPos;

        _text.Remove(index, count);

        int tailLength = _text.Length - index;
        string tail = tailLength > 0 ? _text.ToString(index, tailLength) : string.Empty;

        int left = _consoleDriver.CursorLeft;
        int top = _consoleDriver.CursorTop;

        if (tail.Length > 0)
            _consoleDriver.Write(tail);

        if (count > 0)
            _consoleDriver.Write(new string(' ', count));

        _consoleDriver.SetCursorPosition(left, top);
        _cursorLimit -= count;
        if (_cursorLimit < 0)
            _cursorLimit = 0;
    }

    /// <summary>
    /// Deletes the character at the current cursor position within the text buffer, if not at the end of the line.
    /// </summary>
    protected void Delete()
    {
        if (IsEndOfLine())
            return;

        int index = _cursorPos;
        _text.Remove(index, 1);
        string replacement = _text.ToString()[index..];
        int left = _consoleDriver.CursorLeft;
        int top = _consoleDriver.CursorTop;
        _consoleDriver.Write(string.Format("{0} ", replacement));
        _consoleDriver.SetCursorPosition(left, top);
        _cursorLimit--;
    }

    /// <summary>
    /// Moves the cursor to the beginning of the input line.
    /// </summary>
    protected void MoveCursorHome()
        => MoveCursorLeft(_cursorPos);

    /// <summary>
    /// Transposes the character at the current cursor position with the preceding character in the text buffer.
    /// </summary>
    protected void TransposeChars()
    {
        // local helper functions
        bool AlmostEndOfLine() => _cursorLimit - _cursorPos == 1;
        int IncrementIf(Func<bool> expression, int index) => expression() ? index + 1 : index;
        int DecrementIf(Func<bool> expression, int index) => expression() ? index - 1 : index;

        if (IsStartOfLine()) { return; }

        var firstIdx = DecrementIf(IsEndOfLine, _cursorPos - 1);
        var secondIdx = DecrementIf(IsEndOfLine, _cursorPos);

        char secondChar = _text[secondIdx];
        _text[secondIdx] = _text[firstIdx];
        _text[firstIdx] = secondChar;

        var left = IncrementIf(AlmostEndOfLine, _consoleDriver.CursorLeft);
        var cursorPosition = IncrementIf(AlmostEndOfLine, _cursorPos);

        WriteNewString(_text.ToString());

        _consoleDriver.SetCursorPosition(left, _consoleDriver.CursorTop);
        _cursorPos = cursorPosition;

        MoveCursorRight();
    }

    /// <summary>
    /// Initiates the auto-complete operation by displaying the first available completion at the current cursor
    /// position.
    /// </summary>
    protected void StartAutoComplete()
    {
        if (_completions == null)
            return;

        Backspace(_cursorPos - _completionStart);
        _completionsIndex = 0;
        WriteString(_completions[_completionsIndex]);
    }

    /// <summary>
    /// Advances to the next available auto-completion suggestion and updates the input accordingly.
    /// </summary>
    protected void NextAutoComplete()
    {
        if (_completions == null)
            return;

        Backspace(_cursorPos - _completionStart);

        _completionsIndex++;

        if (_completionsIndex == _completions.Count)
            _completionsIndex = 0;

        WriteString(_completions[_completionsIndex]);
    }

    /// <summary>
    /// Cycles to the previous item in the auto-completion list and updates the input with its value.
    /// </summary>
    protected void PreviousAutoComplete()
    {
        if (_completions == null)
            return;

        Backspace(_cursorPos - _completionStart);

        _completionsIndex--;

        if (_completionsIndex == -1)
            _completionsIndex = _completions.Count - 1;

        WriteString(_completions[_completionsIndex]);
    }

    /// <summary>
    /// Navigates to the previous entry in the input history and updates the current input with its value.
    /// </summary>
    protected void PrevHistory()
    {
        if (_historyIndex > 0)
        {
            _historyIndex--;
            WriteNewString(History[_historyIndex]);
        }
    }

    /// <summary>
    /// Advances to the next entry in the input history, updating the current line accordingly.
    /// </summary>
    protected void NextHistory()
    {
        if (_historyIndex < History.Count)
        {
            _historyIndex++;
            if (_historyIndex == History.Count)
                ClearLine();
            else
                WriteNewString(History[_historyIndex]);
        }
    }

    /// <summary>
    /// Deletes the word immediately preceding the current cursor position within the text buffer.
    /// </summary>
    protected void CutPreviousWord()
    {
        while (!IsStartOfLine() && _text[_cursorPos - 1] != ' ')
            Backspace();
    }

    /// <summary>
    /// Removes all text from the current cursor position to the start of the line.
    /// </summary>
    protected void CutTextToTheStartOfLine()
        => Backspace(_cursorPos);

    /// <summary>
    /// Removes all text from the current cursor position to the end of the line.
    /// </summary>
    protected void CutTextToTheEndOfLine()
    {
        int pos = _cursorPos;
        MoveCursorEnd();
        Backspace(_cursorPos - pos);
    }

    /// <summary>
    /// Resets the auto-complete state, clearing any existing completion results and preparing for a new completion
    /// sequence.
    /// </summary>
    protected void ResetAutoComplete()
    {
        _completions = null;
        _completionsIndex = 0;
    }

    private void CommandLineCompetition()
    {
        if (IsInAutoCompleteMode())
        {
            NextAutoComplete();
        }
        else
        {
            if (_autoCompleteHandler == null || !IsEndOfLine())
                return;

            string text = _text.ToString();

            _completionStart = text.LastIndexOfAny(_autoCompleteHandler.Separators);
            _completionStart = _completionStart == -1 ? 0 : _completionStart + 1;

            _completions = _autoCompleteHandler.GetSuggestions(text, _completionStart);
            _completions = _completions?.Count == 0 ? null : _completions;

            if (_completions == null)
                return;

            StartAutoComplete();
        }
    }

    private void BackwardsCommandLineCompetition()
    {
        if (IsInAutoCompleteMode())
            PreviousAutoComplete();
    }

    /// <summary>
    /// Gets the current text content represented by this instance.
    /// </summary>
    public string Text
        => _text.ToString();

    /// <summary>
    /// Gets the collection of history entries associated with the current instance.
    /// </summary>
    public IList<string> History { get; }


    /// <summary>
    /// Creates a read-only mapping of keyboard key registrations to their associated command actions.
    /// </summary>
    /// <remarks>The returned dictionary associates specific keyboard keys and modifier combinations with
    /// command actions such as cursor movement, text editing, and command line operations. This mapping is typically
    /// used to handle user input in interactive console scenarios. The dictionary is intended to be used as a static
    /// set of key bindings and should not be modified.</remarks>
    /// <returns>An <see cref="IReadOnlyDictionary{KeyRegistration, Action}"/> containing key registrations as keys and their
    /// corresponding command actions as values.</returns>
    protected IReadOnlyDictionary<KeyRegistration, Action> CreateRegistrations()
    {
        return new Dictionary<KeyRegistration, Action>
        {
            { new KeyRegistration(ConsoleKey.LeftArrow), MoveCursorLeft },
            { new KeyRegistration(ConsoleKey.B, ConsoleModifiers.Control), MoveCursorLeft },
            { new KeyRegistration(ConsoleKey.Home), MoveCursorHome },
            { new KeyRegistration(ConsoleKey.A, ConsoleModifiers.Control), MoveCursorHome },
            { new KeyRegistration(ConsoleKey.End), MoveCursorEnd },
            { new KeyRegistration(ConsoleKey.E, ConsoleModifiers.Control), MoveCursorEnd },
            { new KeyRegistration(ConsoleKey.RightArrow), MoveCursorRight },
            { new KeyRegistration(ConsoleKey.F, ConsoleModifiers.Control), MoveCursorRight },
            { new KeyRegistration(ConsoleKey.Backspace), Backspace },
            { new KeyRegistration(ConsoleKey.H, ConsoleModifiers.Control), Backspace },
            { new KeyRegistration(ConsoleKey.Delete), Delete },
            { new KeyRegistration(ConsoleKey.D, ConsoleModifiers.Control), Delete },
            { new KeyRegistration(ConsoleKey.L, ConsoleModifiers.Control), ClearLine },
            { new KeyRegistration(ConsoleKey.Escape), ClearLine },
            { new KeyRegistration(ConsoleKey.UpArrow), PrevHistory },
            { new KeyRegistration(ConsoleKey.P, ConsoleModifiers.Control), PrevHistory },
            { new KeyRegistration(ConsoleKey.DownArrow), NextHistory },
            { new KeyRegistration(ConsoleKey.N, ConsoleModifiers.Control), NextHistory },
            { new KeyRegistration(ConsoleKey.T, ConsoleModifiers.Control), TransposeChars },
            { new KeyRegistration(ConsoleKey.W, ConsoleModifiers.Control), CutPreviousWord },
            { new KeyRegistration(ConsoleKey.U, ConsoleModifiers.Control), CutTextToTheStartOfLine },
            { new KeyRegistration(ConsoleKey.K, ConsoleModifiers.Control), CutTextToTheEndOfLine  },
            { new KeyRegistration(ConsoleKey.Tab), CommandLineCompetition  },
            { new KeyRegistration(ConsoleKey.Tab, ConsoleModifiers.Shift), BackwardsCommandLineCompetition }
        };
    }

    internal void SetConsoleDriver(IConsole console)
    {
        _consoleDriver = console;
    }

    /// <summary>
    /// Initializes a new instance of the KeyHandler class with the specified command history and optional auto-complete
    /// handler.
    /// </summary>
    /// <param name="history">A list of previously entered command strings used for history navigation and recall. Cannot be null.</param>
    /// <param name="autoCompleteHandler">An optional handler that provides auto-completion suggestions for user input. If null, auto-completion is
    /// disabled.</param>
    public KeyHandler(IList<string> history, IAutoCompleteHandler? autoCompleteHandler)
    {
        _consoleDriver = null!;
        History = history;
        _autoCompleteHandler = autoCompleteHandler;
        _historyIndex = History.Count;
        _text = new StringBuilder();
        _keyActions = CreateRegistrations();
    }

    /// <summary>
    /// Processes the specified console key input and performs the associated action or writes the character to the
    /// console.
    /// </summary>
    /// <remarks>If the key corresponds to a registered action, that action is executed. Otherwise, the
    /// character is written to the console. When in auto-complete mode, pressing any key other than Tab will reset the
    /// auto-complete state.</remarks>
    /// <param name="keyInfo">The key information representing the user's input, including the key pressed and any modifier keys.</param>
    public void Handle(ConsoleKeyInfo keyInfo)
    {
        _keyInfo = keyInfo;

        // If in auto complete mode and Tab wasn't pressed
        if (IsInAutoCompleteMode() && _keyInfo.Key != ConsoleKey.Tab)
            ResetAutoComplete();

        var lookupKey = new KeyRegistration(_keyInfo.Key, _keyInfo.Modifiers);

        if (_keyActions.TryGetValue(lookupKey, out Action? action))
        {
            action.Invoke();
            return;
        }

        WriteChar();
    }
}
