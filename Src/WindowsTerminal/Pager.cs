using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Allows to display text in a paginated way
/// </summary>
public sealed class Pager
{
    private readonly List<Page> _pages;
    private readonly PagerOptions _options;

    /// <summary>
    /// Creates a new pager. The pager will read the text from the reader and paginate it
    /// </summary>
    /// <param name="reader">A Text reader that supplies the text</param>
    /// /// <param name="options">Pager options</param>
    public Pager(TextReader reader, PagerOptions? options = default)
    {
        if (options == default)
            options = PagerOptions.Default;

        _options = options;
        _pages = new();
        AddPages(reader);
    }

    /// <summary>
    /// Creates a new pager. The pager will paginate the text
    /// </summary>
    /// <param name="text">Text to paginate</param>
    /// <param name="options">Pager options</param>
    public Pager(string text, PagerOptions? options = default)
    {
        if (options == default)
            options = PagerOptions.Default;

        _options = options;
        _pages = new();
        using var reader = new StringReader(text);
        AddPages(reader);
    }

    /// <summary>
    /// Shows the pager
    /// </summary>
    public void Show()
    {
        int currentPage = 0;
        while (true)
        {
            Console.Clear();
            foreach (var line in _pages[currentPage])
            {
                Console.WriteLine(_options.LineFormatter(line));
            }
            var navbar = $"{currentPage + 1} of {_pages.Count} | esc/q: quit | up: previous | down: next";
            Console.WriteLine("═".PadLeft(_options.PageWidth, '═'));
            Console.Write(navbar);

            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                case ConsoleKey.Q:
                    return;
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.PageUp:
                    currentPage = Math.Max(0, currentPage - 1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.PageDown:
                    currentPage = Math.Min(_pages.Count - 1, currentPage + 1);
                    break;
            }
        }
    }

    private void AddPages(TextReader reader)
    {
        Page current = new(_options.PageHeight);
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.Length <= _options.PageWidth)
            {
                if (!current.TryAdd(line))
                {
                    _pages.Add(current);
                    current = new Page(_options.PageHeight);
                    current.TryAdd(line);
                }
                continue;
            }

            var linesToAdd = line.Chunk(_options.PageWidth).Select(c => new string(c));
            foreach (var toAdd in linesToAdd)
            {
                if (!current.TryAdd(toAdd))
                {
                    _pages.Add(current);
                    current = new Page(_options.PageHeight);
                    current.TryAdd(toAdd);
                }
            }
        }
        _pages.Add(current);
    }

    private class Page : IEnumerable<string>
    {
        private readonly string[] _lines;
        private int _index;

        public Page(int count)
        {
            _lines = new string[count];
        }

        public IEnumerator<string> GetEnumerator()
            => ((IEnumerable<string>)_lines).GetEnumerator();

        public bool TryAdd(string line)
        {
            if (_index < _lines.Length)
            {
                _lines[_index++] = line;
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => _lines.GetEnumerator();
    }
}
