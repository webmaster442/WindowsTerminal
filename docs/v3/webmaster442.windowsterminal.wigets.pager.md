[`< Back`](./)

---

# Pager

Namespace: Webmaster442.WindowsTerminal.Wigets

Allows to display text in a paginated way

```csharp
public class Pager : WigetBase
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [WigetBase](./webmaster442.windowsterminal.wigets.wigetbase.md) → [Pager](./webmaster442.windowsterminal.wigets.pager.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **IsShowing**

Gets if the wiget is currently shown.

```csharp
protected bool IsShowing { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsAlternateBuffer**

Gets if the wiget is currently shown in the alternate buffer.

```csharp
protected bool IsAlternateBuffer { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **Pager(TextReader, PagerOptions)**

Creates a new pager. The pager will read the text from the reader and paginate it

```csharp
public Pager(TextReader reader, PagerOptions options)
```

#### Parameters

`reader` [TextReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader)<br>
A Text reader that supplies the text

`options` [PagerOptions](./webmaster442.windowsterminal.wigets.pageroptions.md)<br>
Pager options

### **Pager(String, PagerOptions)**

Creates a new pager. The pager will paginate the text

```csharp
public Pager(string text, PagerOptions options)
```

#### Parameters

`text` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Text to paginate

`options` [PagerOptions](./webmaster442.windowsterminal.wigets.pageroptions.md)<br>
Pager options

## Methods

### **OnHide()**

Hides the pager

```csharp
public void OnHide()
```

### **OnShow()**

Shows the pager

```csharp
public void OnShow()
```

---

[`< Back`](./)
