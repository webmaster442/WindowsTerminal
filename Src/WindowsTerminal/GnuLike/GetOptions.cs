namespace Webmaster442.WindowsTerminal.GnuLike;

/// <summary>
/// Simple GNU-like option parser
/// </summary>
public static class GetOptions
{
    /// <summary>
    /// Parses a list of command-line arguments into options, switches, and positional arguments according to the
    /// specified parsing settings.
    /// </summary>
    /// <param name="arguments">The collection of command-line argument strings to parse. Each element represents a single argument as provided
    /// to the application.</param>
    /// <param name="settings">The settings that control how options and switches are identified and compared. If <see langword="null"/> is
    /// specified, default settings are used.</param>
    /// <returns>A <see cref="ParsedOptions"/> instance containing the parsed options, switches, and positional arguments
    /// extracted from the input.</returns>
    public static ParsedOptions Parse(IReadOnlyList<string> arguments, GetOptionsSettings? settings = null)
    {
        if (settings == null)
            settings = new GetOptionsSettings();

        var options = new Dictionary<string, string>(settings.Comparer);
        var switches = new HashSet<string>(settings.Comparer);
        var args = new List<string>();

        int i = 0;
        while (i < arguments.Count)
        {
            string current = arguments[i];
            string? next = i + 1 < arguments.Count ? arguments[i + 1] : null;

            if (current.StartsWith(settings.OptionValueSeperator))
            {
                if (next != null)
                {
                    options.Add(current.TrimStart(settings.OptionValueSeperator), next);
                    i += 2;
                }
                else
                {
                    switches.Add(current.TrimStart(settings.OptionValueSeperator));
                    i++;
                }
            }
            else
            {
                args.Add(current);
                i++;
            }
        }

        return new ParsedOptions
        {
            Options = options,
            Switches = switches,
            Arguments = args
        };

    }
}
