[`< Back`](./)

---

# TerminalBackgroundImageStretchMode

Namespace: Webmaster442.WindowsTerminal

This sets how the background image is resized to fill the window.

```csharp
public enum TerminalBackgroundImageStretchMode
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) → [TerminalBackgroundImageStretchMode](./webmaster442.windowsterminal.terminalbackgroundimagestretchmode.md)<br>
Implements [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [ISpanFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.ispanformattable), [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable), [IConvertible](https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible)<br>
Attributes JsonConverterAttribute

## Fields

| Name | Value | Description |
| --- | --: | --- |
| None | 0 | The image is not resized. |
| Fill | 1 | The image is resized to fill the destination dimensions. The aspect ratio is not preserved. |
| Uniform | 2 | The image is resized to fit in the destination dimensions while it preserves its native aspect ratio. |
| UniformToFill | 3 | The image is resized to fill the destination dimensions while it preserves its native aspect ratio. If the aspect ratio of the destination rectangle differs from the source, the source content is clipped to fit in the destination dimensions. |

---

[`< Back`](./)
