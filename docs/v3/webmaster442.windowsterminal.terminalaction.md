[`< Back`](./)

---

# TerminalAction

Namespace: Webmaster442.WindowsTerminal

A terminal action

```csharp
public class TerminalAction
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalAction](./webmaster442.windowsterminal.terminalaction.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [RequiredMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.requiredmemberattribute)

## Properties

### **Command**

This is the command executed when the associated keys are pressed.

```csharp
public TerminalCommand Command { get; set; }
```

#### Property Value

[TerminalCommand](./webmaster442.windowsterminal.terminalcommand.md)<br>

### **Name**

This sets the name that will appear in the command palette. If one isn't provided, the terminal will attempt to automatically generate a name.

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Id**

This sets the id of this action. If one isn't provided, the terminal will generate an ID for this action. The ID is used to refer to this action when creating keybindings.

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **TerminalAction()**

#### Caution

Constructors of types with required members are not supported in this version of your compiler.

---

```csharp
public TerminalAction()
```

---

[`< Back`](./)
