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

### **GetPaletteColor(Int32)**

Get the specified color of the current terminal palette

```csharp
public static ValueTuple<byte, byte, byte> GetPaletteColor(int colorIndex)
```

#### Parameters

`colorIndex` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Color index to get. Must be between 0 and 15

#### Returns

[ValueTuple&lt;Byte, Byte, Byte&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-3)<br>
24 bit RGB color

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

### **GetCurrentSessionId()**

Get the current session id

```csharp
public static string GetCurrentSessionId()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The current windows Session id. Returns null, if program is not running in Windows Terminal

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
