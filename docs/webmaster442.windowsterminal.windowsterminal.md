[`< Back`](./)

---

# WindowsTerminal

Namespace: Webmaster442.WindowsTerminal

Windows terminal interaction class

```csharp
public static class WindowsTerminal
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [WindowsTerminal](./webmaster442.windowsterminal.windowsterminal.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Methods

### **SetProgressbar(ProgressbarState, Int32)**

Set the progressbar state

```csharp
public static void SetProgressbar(ProgressbarState progressbarState, int value)
```

#### Parameters

`progressbarState` [ProgressbarState](./webmaster442.windowsterminal.progressbarstate.md)<br>
Progress bar state

`value` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
progress bar value

### **IsRunningInsideWindowsTerminal()**

Check if the current program is running inside the Windows Terminal

```csharp
public static bool IsRunningInsideWindowsTerminal()
```

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
True, if App is running inside windows terminal

### **SetWindowTitle(String)**

Set the window title

```csharp
public static void SetWindowTitle(string title)
```

#### Parameters

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Title to set

### **SwitchToAlternateBuffer()**

Switch to alternate buffer

```csharp
public static void SwitchToAlternateBuffer()
```

### **SwitchToMainBuffer()**

Switch to main buffer

```csharp
public static void SwitchToMainBuffer()
```

---

[`< Back`](./)
