[`< Back`](./)

---

# ProgressbarState

Namespace: Webmaster442.WindowsTerminal

Windows terminal progress bar state

```csharp
public enum ProgressbarState
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) → [ProgressbarState](./webmaster442.windowsterminal.progressbarstate.md)<br>
Implements [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [ISpanFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.ispanformattable), [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable), [IConvertible](https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible)

## Fields

| Name | Value | Description |
| --- | --: | --- |
| Hidden | 0 | default state, and indicates that the progress bar should be hidden. Use this state when the command is complete, to clear out any progress state. |
| Default | 1 | default state, and indicates that the progress bar should be shown in the default color. |
| Error | 2 | Indicates that the progress bar should be shown in an error state. |
| Indeterminate | 3 | Indicates that the progress bar should be shown in an indeterminate state.  This is useful for commands that don't have a progress value, but are still running. This state ignores the progress value. |
| Warning | 4 | Indicates that the progress bar should be shown in a warning state. |

---

[`< Back`](./)
