[`< Back`](./)

---

# TerminalFont

Namespace: Webmaster442.WindowsTerminal

Represents a font used in the terminal

```csharp
public sealed class TerminalFont
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalFont](./webmaster442.windowsterminal.terminalfont)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Face**

This is the name of the font face used in the profile. The terminal will try to fallback to Consolas if this can't be found or is invalid.

```csharp
public string Face { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Size**

This sets the profile's font size in points.

```csharp
public int Size { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Weight**

This sets the weight (lightness or heaviness of the strokes) for the profile's font.

```csharp
public TerminalFontWeight Weight { get; set; }
```

#### Property Value

[TerminalFontWeight](./webmaster442.windowsterminal.terminalfontweight)<br>

## Constructors

### **TerminalFont()**

```csharp
public TerminalFont()
```

---

[`< Back`](./)
