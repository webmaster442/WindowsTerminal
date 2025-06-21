// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Webmaster442.WindowsTerminal.Internals;

internal sealed class GuidToRegistryStringConverter : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string guidString = reader.GetString()!;
            return new Guid(guidString.Trim('{', '}'));
        }
        else
        {
            throw new JsonException("Invalid JSON for Guid");
        }
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{{{value}}}");
    }
}
