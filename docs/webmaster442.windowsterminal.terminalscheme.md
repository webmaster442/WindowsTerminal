[`< Back`](./)

---

# TerminalScheme

Namespace: Webmaster442.WindowsTerminal

Represents a color scheme for Windows Terminal

```csharp
public class TerminalScheme : System.IEquatable`1[[Webmaster442.WindowsTerminal.TerminalScheme, Webmaster442.WindowsTerminal, Version=1.1.1.0, Culture=neutral, PublicKeyToken=null]]
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalScheme](./webmaster442.windowsterminal.terminalscheme)<br>
Implements [IEquatable&lt;TerminalScheme&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [RequiredMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.requiredmemberattribute)

## Properties

### **EqualityContract**

```csharp
protected Type EqualityContract { get; }
```

#### Property Value

[Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

### **Name**

The name of the scheme

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Black**

Black color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Black { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Red**

Red color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Red { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Green**

Green color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Green { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Yellow**

Yellow color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Yellow { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Blue**

Blue color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Blue { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Purple**

Purple color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Purple { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Cyan**

Cyan color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Cyan { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **White**

White color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string White { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightBlack**

Bright black color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightBlack { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightRed**

Bright red color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightRed { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightGreen**

Bright green color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightGreen { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightYellow**

Bright yellow color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightYellow { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightBlue**

Bright blue color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightBlue { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightPurple**

Bright purple color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightPurple { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightCyan**

Bright cyan color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightCyan { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BrightWhite**

Bright white color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string BrightWhite { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Background**

Background color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Background { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Foreground**

Foreground color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string Foreground { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CursorColor**

Cursor color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string CursorColor { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SelectionBackground**

Selection background color. Accepts a string in hex format "#rgb" or "#rrggbb"

```csharp
public string SelectionBackground { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **TerminalScheme(TerminalScheme)**

```csharp
protected TerminalScheme(TerminalScheme original)
```

#### Parameters

`original` [TerminalScheme](./webmaster442.windowsterminal.terminalscheme)<br>

### **TerminalScheme()**

#### Caution

Constructors of types with required members are not supported in this version of your compiler.

---

```csharp
public TerminalScheme()
```

## Methods

### **ToString()**

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PrintMembers(StringBuilder)**

```csharp
protected bool PrintMembers(StringBuilder builder)
```

#### Parameters

`builder` [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **GetHashCode()**

```csharp
public int GetHashCode()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Equals(Object)**

```csharp
public bool Equals(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Equals(TerminalScheme)**

```csharp
public bool Equals(TerminalScheme other)
```

#### Parameters

`other` [TerminalScheme](./webmaster442.windowsterminal.terminalscheme)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **&lt;Clone&gt;$()**

```csharp
public TerminalScheme <Clone>$()
```

#### Returns

[TerminalScheme](./webmaster442.windowsterminal.terminalscheme)<br>

---

[`< Back`](./)
