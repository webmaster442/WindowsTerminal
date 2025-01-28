[`< Back`](./)

---

# InstallDetector

Namespace: Webmaster442.WindowsTerminal

Detects installed applications

```csharp
public static class InstallDetector
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [InstallDetector](./webmaster442.windowsterminal.installdetector)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Fields

### **WindowsTerminalExe**

The name of the Windows Terminal executable

```csharp
public static string WindowsTerminalExe;
```

### **PowershellCoreExe**

The name of the Powershell Core executable

```csharp
public static string PowershellCoreExe;
```

### **VsCodeExe**

The name of the Visual Studio Code executable

```csharp
public static string VsCodeExe;
```

## Methods

### **GetInstallResult()**

Gets the installation status of various applications

```csharp
public static InstallResult GetInstallResult()
```

#### Returns

[InstallResult](./webmaster442.windowsterminal.installresult)<br>
An InstallResult

---

[`< Back`](./)
