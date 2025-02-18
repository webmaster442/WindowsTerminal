[`< Back`](./)

---

# SizeMode

Namespace: Webmaster442.WindowsTerminal

Controls image sizing mode

```csharp
public enum SizeMode
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) → [SizeMode](./webmaster442.windowsterminal.sizemode.md)<br>
Implements [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [ISpanFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.ispanformattable), [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable), [IConvertible](https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible)

## Fields

| Name | Value | Description |
| --- | --: | --- |
| None | 0 | No resize is performed |
| Fit | 1 | Downsize to the minimum size that fits into the maximum size by keeping aspect ratio |
| FitWidth | 2 | Downsize to fit with of the maximum size by keeping aspect ratio |
| FitHeight | 3 | Downsize to fit height of the maximum size by keeping aspect ratio |
| Manual | 4 | Manual size mode. Image is resized to the specified maximum size. |

---

[`< Back`](./)
