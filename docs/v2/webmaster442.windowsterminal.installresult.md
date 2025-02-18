[`< Back`](./)

---

# InstallResult

Namespace: Webmaster442.WindowsTerminal

Represents the Installation status of various applications

```csharp
public sealed class InstallResult : System.IEquatable`1[[Webmaster442.WindowsTerminal.InstallResult, Webmaster442.WindowsTerminal, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InstallResult](./webmaster442.windowsterminal.installresult.md)<br>
Implements [IEquatable&lt;InstallResult&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **TerminalPath**

The path to the Windows Terminal executable

```csharp
public string TerminalPath { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PowershellCorePath**

The path to the Powershell Core executable

```csharp
public string PowershellCorePath { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **VsCodePath**

The path to the Visual Studio Code executable

```csharp
public string VsCodePath { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **IsWindowsTerminalInstalled**

Indicates if Windows Terminal is installed

```csharp
public bool IsWindowsTerminalInstalled { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsPsCoreInstalled**

Indicates if Powershell Core is installed

```csharp
public bool IsPsCoreInstalled { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsVSCodeInstalled**

Indicates if Visual Studio Code is installed

```csharp
public bool IsVSCodeInstalled { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **InstallResult()**

```csharp
public InstallResult()
```

## Methods

### **ToString()**

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

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

### **Equals(InstallResult)**

```csharp
public bool Equals(InstallResult other)
```

#### Parameters

`other` [InstallResult](./webmaster442.windowsterminal.installresult.md)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **&lt;Clone&gt;$()**

```csharp
public InstallResult <Clone>$()
```

#### Returns

[InstallResult](./webmaster442.windowsterminal.installresult.md)<br>

---

[`< Back`](./)
