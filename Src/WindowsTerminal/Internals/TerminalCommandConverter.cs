// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

using Webmaster442.WindowsTerminal.Fragments;

namespace Webmaster442.WindowsTerminal.Internals;

internal sealed class TerminalCommandConverter : JsonConverter<TerminalCommand>
{
    public override TerminalCommand? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString() ?? string.Empty;
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            Dictionary<string, string> dict = ReadDictionary(ref reader);
            return new TerminalCommand(dict);
        }
        else
        {
            throw new JsonException("Invalid JSON for TerminalCommand");
        }
    }

    public override void Write(Utf8JsonWriter writer, TerminalCommand value, JsonSerializerOptions options)
    {
        if (value.Command != null && value.Actions == null)
        {
            writer.WriteStringValue(value.Command);
        }
        else if (value.Actions != null && value.Command == null)
        {
            WriteDictionary(writer, value.Actions);
        }
        else
        {
            throw new UnreachableException("Command and Actions are set both times");
        }
    }

    private static Dictionary<string, string> ReadDictionary(ref Utf8JsonReader reader)
    {
        var dict = new Dictionary<string, string>();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                break;

            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            string key = reader.GetString()!;

            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            string value = reader.GetString()!;
            dict[key] = value;
        }
        return dict;
    }

    private static void WriteDictionary(Utf8JsonWriter writer, Dictionary<string, string> dictionary)
    {
        writer.WriteStartObject();
        foreach (var kvp in dictionary)
        {
            writer.WriteString(kvp.Key, kvp.Value);
        }
        writer.WriteEndObject();
    }
}
