[`< Back`](./)

---

# TerminalFormattedStringBuilder

Namespace: Webmaster442.WindowsTerminal

Formatted text output builder

```csharp
public sealed class TerminalFormattedStringBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Constructors

### **TerminalFormattedStringBuilder()**

Create a new instance of TerminalFormattedStringBuilder

```csharp
public TerminalFormattedStringBuilder()
```

## Methods

### **New()**

Clear internal buffer

```csharp
public TerminalFormattedStringBuilder New()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **ResetFormat()**

Reset all formatting

```csharp
public TerminalFormattedStringBuilder ResetFormat()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithForegroundColor(TerminalColor)**

Set foreground color to a standard color

```csharp
public TerminalFormattedStringBuilder WithForegroundColor(TerminalColor color)
```

#### Parameters

`color` [TerminalColor](./webmaster442.windowsterminal.terminalcolor.md)<br>
Color to use

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithForegroundColor(ConsoleColor)**

Set foreground color to a standard color

```csharp
public TerminalFormattedStringBuilder WithForegroundColor(ConsoleColor color)
```

#### Parameters

`color` ConsoleColor<br>
Color to use

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithForegroundColor(String)**

Set foreground color to a 24 bit RGB color

```csharp
public TerminalFormattedStringBuilder WithForegroundColor(string color)
```

#### Parameters

`color` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
color in hex format (E.g: #ffffff) or rgb format (E.g: rgb(255, 255, 255)) or hsl format. (E.g: hsl(0, 0%, 100%))

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
The color was not one of the supported formats.

### **WithForegroundColor(Byte, Byte, Byte)**

Set foreground color to a 24 bit RGB color

```csharp
public TerminalFormattedStringBuilder WithForegroundColor(byte r, byte g, byte b)
```

#### Parameters

`r` [Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
red value

`g` [Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
green value

`b` [Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
blue value

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithForegroundColor(Int32)**

Set foreground color to a 256 color index.
 Color index must be between 0 and 255

```csharp
public TerminalFormattedStringBuilder WithForegroundColor(int index)
```

#### Parameters

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
color index to use

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithBackgroundColor(TerminalColor)**

Set background color to a standard color

```csharp
public TerminalFormattedStringBuilder WithBackgroundColor(TerminalColor color)
```

#### Parameters

`color` [TerminalColor](./webmaster442.windowsterminal.terminalcolor.md)<br>
Color to use

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithBackgroundColor(ConsoleColor)**

Set background color to a standard color

```csharp
public TerminalFormattedStringBuilder WithBackgroundColor(ConsoleColor color)
```

#### Parameters

`color` ConsoleColor<br>
Color to use

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithBackgroundColor(String)**

Set background color to a 24 bit RGB color

```csharp
public TerminalFormattedStringBuilder WithBackgroundColor(string color)
```

#### Parameters

`color` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
color in hex format (E.g: #000000) or rgb format (E.g: rgb(0, 0, 0)) or hsl format. (E.g: hsl(0, 0%, 0%))

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

#### Exceptions

[FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception)<br>
The color was not one of the supported formats.

### **WithBackgroundColor(Byte, Byte, Byte)**

Set background color to a 24 bit RGB color

```csharp
public TerminalFormattedStringBuilder WithBackgroundColor(byte r, byte g, byte b)
```

#### Parameters

`r` [Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
red value

`g` [Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
green value

`b` [Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
blue value

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithBackgroundColor(Int32)**

Set background color to a 256 color index.
 Color index must be between 0 and 255

```csharp
public TerminalFormattedStringBuilder WithBackgroundColor(int index)
```

#### Parameters

`index` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
color index to use

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithBold()**

Set text to bold

```csharp
public TerminalFormattedStringBuilder WithBold()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithItalic()**

Set text to italic

```csharp
public TerminalFormattedStringBuilder WithItalic()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithUnderline()**

Set text to underline

```csharp
public TerminalFormattedStringBuilder WithUnderline()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithInverse()**

Inverts text foreground and background colors

```csharp
public TerminalFormattedStringBuilder WithInverse()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **Append(String)**

Append a text to the formatted string

```csharp
public TerminalFormattedStringBuilder Append(string text)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
text

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **Append(Char)**

Appends the string representation of a specified System.Char object to this instance.

```csharp
public TerminalFormattedStringBuilder Append(char chr)
```

#### Parameters

`chr` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The UTF-16-encoded code unit to append.

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **Append(Char, Int32)**

Appends a specified number of copies of the string representation of a Unicode character to this instance.

```csharp
public TerminalFormattedStringBuilder Append(char chr, int repeatCount)
```

#### Parameters

`chr` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The UTF-16-encoded code unit to append.

`repeatCount` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The number of times to append chr.

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **Append(Object)**

Appends the string representation of a specified object to this instance.

```csharp
public TerminalFormattedStringBuilder Append(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
object to append

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **AppendLine(String)**

Append a line to the formatted string

```csharp
public TerminalFormattedStringBuilder AppendLine(string text)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
text

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **AppendLine()**

Append a line to the formatted string

```csharp
public TerminalFormattedStringBuilder AppendLine()
```

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **AppendFormat(String, Object[])**

Appends the string returned by processing a composite format string, which contains zero or more format items,
 to this instance. Each format item is replaced by the string representation of a corresponding argument in a parameter array.

```csharp
public TerminalFormattedStringBuilder AppendFormat(string format, Object[] args)
```

#### Parameters

`format` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
A composite format string.

`args` [Object[]](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
An array of objects to format.

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **AppendJoin&lt;T&gt;(Char, IEnumerable&lt;T&gt;)**

Concatenates and appends the members of a collection, using the specified separator between each member.

```csharp
public TerminalFormattedStringBuilder AppendJoin<T>(char separator, IEnumerable<T> values)
```

#### Type Parameters

`T`<br>
The type of the members of values.

#### Parameters

`separator` [Char](https://docs.microsoft.com/en-us/dotnet/api/system.char)<br>
The character to use as a separator. separator is included in the concatenated and appended strings only if values has more than one element.

`values` IEnumerable&lt;T&gt;<br>
A collection that contains the objects to concatenate and append to the current TerminalFormattedStringBuilder

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **AppendJoin&lt;T&gt;(String, IEnumerable&lt;T&gt;)**

Concatenates and appends the members of a collection, using the specified separator between each member.

```csharp
public TerminalFormattedStringBuilder AppendJoin<T>(string separator, IEnumerable<T> values)
```

#### Type Parameters

`T`<br>
The type of the members of values.

#### Parameters

`separator` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The string to use as a separator. separator is included in the concatenated and appended strings only if values has more than one element.

`values` IEnumerable&lt;T&gt;<br>
A collection that contains the objects to concatenate and append to the current TerminalFormattedStringBuilder

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **WithNerdFont(Int32)**

Append a nerd font icon to the output. Terminal needs to have a nerd font installed
 Cheat sheet: https://www.nerdfonts.com/cheat-sheet

```csharp
public TerminalFormattedStringBuilder WithNerdFont(int nerdFont)
```

#### Parameters

`nerdFont` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Nerd font icon codepoint to display

#### Returns

[TerminalFormattedStringBuilder](./webmaster442.windowsterminal.terminalformattedstringbuilder.md)<br>
A TerminalFormattedStringBuilder to chain formatting

### **ToString()**

Convert the formatted string to a string

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
a string with ANSI escape codes

---

[`< Back`](./)
