[`< Back`](./)

---

# TerminalFragment

Namespace: Webmaster442.WindowsTerminal

Represents a terminal fragment

```csharp
public sealed class TerminalFragment
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalFragment](./webmaster442.windowsterminal.terminalfragment)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Profiles**

Profiles in the fragment

```csharp
public List<TerminalProfile> Profiles { get; }
```

#### Property Value

[List&lt;TerminalProfile&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

### **Schemes**

Schemes in the fragment

```csharp
public List<TerminalScheme> Schemes { get; }
```

#### Property Value

[List&lt;TerminalScheme&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>

## Constructors

### **TerminalFragment()**

```csharp
public TerminalFragment()
```

## Methods

### **ToJson()**

Convert this instance to a JSON string

```csharp
public string ToJson()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Object data as JSON

---

[`< Back`](./)
