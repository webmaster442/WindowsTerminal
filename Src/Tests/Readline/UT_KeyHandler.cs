using System;
using System.Collections.Generic;
using System.Text;

using Webmaster442.WindowsTerminal.Readline;

namespace Webmaster442.WindowsTerminal.Tests.Readline;

[TestFixture]
public class UT_KeyHandler
{
    private class TestAutoCompleteHandler : IAutoCompleteHandler
    {
        public char[] Separators { get; set; } = [' ', '.', '/', '\\', ':'];
        public IReadOnlyList<string> GetSuggestions(string text, int index) => ["World", "Angel", "Love"];
    }

    private class TestConsole : IConsole
    {
        public int CursorLeft { get; private set; }

        public int CursorTop { get; private set; }

        public int BufferWidth { get; private set; }

        public int BufferHeight { get; private set; }

        public bool PasswordMode { get; set; }

        public TestConsole()
        {
            CursorLeft = 0;
            CursorTop = 0;
            BufferWidth = 100;
            BufferHeight = 100;
        }

        public void SetBufferSize(int width, int height)
        {
            BufferWidth = width;
            BufferHeight = height;
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
            => new(' ', ConsoleKey.Spacebar, shift: false, alt: false, control: false);

        public void SetCursorPosition(int left, int top)
        {
            CursorLeft = left;
            CursorTop = top;
        }

        public void Write(string value)
            => CursorLeft += value.Length;

        public void WriteLine(string value)
            => CursorLeft += value.Length;
    }

    private TestConsole _console;
    private List<string> _history;
    private KeyHandler _sut;

    private void SendInput(string text)
    {
        foreach (var @char in text)
        {
            var keyInfo = new ConsoleKeyInfo(@char, (ConsoleKey)@char, shift: false, alt: false, control: false);
            _sut.Handle(keyInfo);
        }
    }

    private void SendInput(ConsoleKey key, ConsoleModifiers modifiers)
    {
        var keyInfo = new ConsoleKeyInfo((char)key,
                                         key,
                                         shift: (modifiers & ConsoleModifiers.Shift) != 0,
                                         alt: (modifiers & ConsoleModifiers.Alt) != 0,
                                         control: (modifiers & ConsoleModifiers.Control) != 0);
        _sut.Handle(keyInfo);
    }

    [SetUp]
    public void Setup()
    {
        _console = new TestConsole();
        _history = [.. new string[] { "dotnet run", "git init", "clear" }];
        _sut = new KeyHandler(_history, new TestAutoCompleteHandler());
        _sut.SetConsoleDriver(_console);
        SendInput("Hello");
    }

    [Test]
    public void Handle_WritesRegularChars()
    {
        SendInput(" World");
        Assert.That(_sut.Text, Is.EqualTo("Hello World"));
    }

    [TestCase(ConsoleKey.Backspace, ConsoleModifiers.None)]
    [TestCase(ConsoleKey.H, ConsoleModifiers.Control)]
    public void Handle_Backspace_RemovesCharBeforeCursor(ConsoleKey key, ConsoleModifiers modifiers)
    {
        SendInput(key, modifiers);
        Assert.That(_sut.Text, Is.EqualTo("Hell"));
    }

    [TestCase(ConsoleKey.Delete, ConsoleModifiers.None)]
    [TestCase(ConsoleKey.D, ConsoleModifiers.Control)]
    public void Handle_Delete_RemovesCharAtCursor(ConsoleKey key, ConsoleModifiers modifiers)
    {
        SendInput(ConsoleKey.LeftArrow, ConsoleModifiers.None);
        SendInput(key, modifiers);
        Assert.That(_sut.Text, Is.EqualTo("Hell"));
    }

    [TestCase(ConsoleKey.Delete, ConsoleModifiers.None)]
    [TestCase(ConsoleKey.D, ConsoleModifiers.Control)]
    public void Handle_Delete_AtEnd_DoesNothing(ConsoleKey key, ConsoleModifiers modifiers)
    {
        SendInput(key, modifiers);
        Assert.That(_sut.Text, Is.EqualTo("Hello"));
    }

    [Test]
    public void Handle_Transpose()
    {
        int left = _console.CursorLeft;
        SendInput(ConsoleKey.T, ConsoleModifiers.Control);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_sut.Text, Is.EqualTo("Helol"));
            Assert.That(_console.CursorLeft, Is.EqualTo(left));
        }
    }

    [Test]
    public void Handle_Transpose_LeftOnce_MovesCursorLeft()
    {
        SendInput(ConsoleKey.LeftArrow, ConsoleModifiers.None);
        int left = _console.CursorLeft;
        SendInput(ConsoleKey.T, ConsoleModifiers.Control);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_sut.Text, Is.EqualTo("Helol"));
            Assert.That(_console.CursorLeft, Is.EqualTo(left + 1));
        }
    }

    [Test]
    public void Handle_Transpose_AtStart_DoesNothing()
    {
        SendInput(ConsoleKey.Home, ConsoleModifiers.None);
        int left = _console.CursorLeft;
        SendInput(ConsoleKey.T, ConsoleModifiers.Control);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_sut.Text, Is.EqualTo("Hello"));
            Assert.That(_console.CursorLeft, Is.EqualTo(left));
        }
    }

    [TestCase(ConsoleKey.Home, ConsoleModifiers.None, -1, 0)]
    [TestCase(ConsoleKey.A, ConsoleModifiers.Control, -1, 0)]
    [TestCase(ConsoleKey.Home, ConsoleModifiers.None, 0, 0)]
    [TestCase(ConsoleKey.A, ConsoleModifiers.Control, 0, 0)]
    [TestCase(ConsoleKey.LeftArrow, ConsoleModifiers.None, 0, 0)]
    [TestCase(ConsoleKey.LeftArrow, ConsoleModifiers.None, 1, 0)]
    [TestCase(ConsoleKey.B, ConsoleModifiers.Control, 0, 0)]
    [TestCase(ConsoleKey.B, ConsoleModifiers.Control, 1, 0)]
    [TestCase(ConsoleKey.RightArrow, ConsoleModifiers.None, 0, 1)]
    [TestCase(ConsoleKey.RightArrow, ConsoleModifiers.None, -1, 5)]
    [TestCase(ConsoleKey.F, ConsoleModifiers.Control, 0, 1)]
    [TestCase(ConsoleKey.F, ConsoleModifiers.Control, -1, 5)]
    public void Handle_Move(ConsoleKey key,
                            ConsoleModifiers modifiers,
                            int startPos,
                            int expectedPosition)
    {
        if (startPos >= 0)
            _sut.SetCursorPos(startPos);

        SendInput(key, modifiers);
        Assert.That(_console.CursorLeft, Is.EqualTo(expectedPosition));
    }

}
