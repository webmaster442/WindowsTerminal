[`< Back`](./)

---

# PagerOptions

Namespace: Webmaster442.WindowsTerminal.Wigets

Pager options

```csharp
public sealed class PagerOptions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PagerOptions](./webmaster442.windowsterminal.wigets.pageroptions.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **Default**

Default pager options

```csharp
public static PagerOptions Default;
```

## Properties

### **LineFormatter**

Line formatter. Before displaying a line, this function will be called to format the line

```csharp
public Func<string, string> LineFormatter { get; set; }
```

#### Property Value

[Func&lt;String, String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>

### **PageHeight**

Gets or sets the height of the page

```csharp
public int PageHeight { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **PageWidth**

Gets or sets the width of the page

```csharp
public int PageWidth { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **PagerOptions()**

```csharp
public PagerOptions()
```

---

[`< Back`](./)
