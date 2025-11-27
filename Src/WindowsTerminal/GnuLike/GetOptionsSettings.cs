namespace Webmaster442.WindowsTerminal.GnuLike;

/// <summary>
/// Provides configuration settings for parsing option-value pairs
/// </summary>
public class GetOptionsSettings
{
    /// <summary>
    /// Gets or sets the character used to separate an option name from its value in command-line arguments.
    /// </summary>
    public char OptionValueSeperator { get; set; }

    /// <summary>
    /// Gets or sets the equality comparer used to determine whether two string keys are equal.
    /// </summary>
    public IEqualityComparer<string>? Comparer { get; set; }

    /// <summary>
    /// Initializes a new instance of the GetOptionsSettings class with default values.
    /// </summary>
    public GetOptionsSettings()
    {
        OptionValueSeperator = '-';
        Comparer = null;
    }
}
