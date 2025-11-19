namespace Webmaster442.WindowsTerminal.Readline;

/// <summary>
/// Defines a handler that provides auto-complete suggestions for text input, supporting configurable word separators.
/// </summary>
/// <remarks>Implementations of this interface can be used to supply context-aware suggestions in text editors,
/// command prompts, or other input fields. The <see cref="Separators"/> property determines how the input text is split
/// into tokens for suggestion purposes.</remarks>
public interface IAutoCompleteHandler
{
    /// <summary>
    /// Gets or sets the array of characters used to separate input values during parsing operations.
    /// </summary>
    char[] Separators { get; set; }

    /// <summary>
    /// Returns a list of suggested completions based on the specified input text and cursor position.
    /// </summary>
    /// <param name="text">The input text for which suggestions are to be generated. Cannot be null.</param>
    /// <param name="index">The zero-based index within the input text that indicates the current cursor position. Must be between 0 and the
    /// length of <paramref name="text"/>.</param>
    /// <returns>A read-only list of strings containing suggestion candidates relevant to the specified position in the input
    /// text. The list will be empty if no suggestions are available.</returns>
    IReadOnlyList<string> GetSuggestions(string text, int index);
}
