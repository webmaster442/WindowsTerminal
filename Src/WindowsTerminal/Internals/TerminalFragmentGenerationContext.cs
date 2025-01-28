using System.Text.Json;
using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal.Internals;

[JsonSourceGenerationOptions(
    ReadCommentHandling = JsonCommentHandling.Skip,
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(TerminalFragment))]
[JsonSerializable(typeof(TerminalBackgroundImageAlignment))]
[JsonSerializable(typeof(TerminalBackgroundImageStretchMode))]
[JsonSerializable(typeof(TerminalProfile))]
[JsonSerializable(typeof(TerminalScheme))]
[JsonSerializable(typeof(TerminalFont))]
[JsonSerializable(typeof(TerminalFontWeight))]
internal partial class TerminalFragmentGenerationContext : JsonSerializerContext
{
}