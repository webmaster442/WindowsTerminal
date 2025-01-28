using System.Text.Json;
using System.Text.Json.Serialization;

using Webmaster442.WindowsTerminal.Internals;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Represents a terminal fragment
/// </summary>
public sealed class TerminalFragment
{
    /// <summary>
    /// Profiles in the fragment
    /// </summary>
    [JsonPropertyName("profiles")]
    public List<TerminalProfile> Profiles { get; } = new();

    /// <summary>
    /// Schemes in the fragment
    /// </summary>
    [JsonPropertyName("schemes")]
    public List<TerminalScheme> Schemes { get; } = new();

    /// <summary>
    /// Convert this instance to a JSON string
    /// </summary>
    /// <returns>Object data as JSON</returns>
    public string ToJson()
    {
        return JsonSerializer.Serialize(this, typeof(TerminalFragment), TerminalFragmentGenerationContext.Default);
    }
}
