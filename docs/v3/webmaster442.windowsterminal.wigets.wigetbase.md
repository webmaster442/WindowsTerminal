[`< Back`](./)

---

# WigetBase

Namespace: Webmaster442.WindowsTerminal.Wigets

Base class for wigets

```csharp
public abstract class WigetBase
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [WigetBase](./webmaster442.windowsterminal.wigets.wigetbase.md)

## Properties

### **IsShowing**

Gets if the wiget is currently shown.

```csharp
protected bool IsShowing { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **IsAlternateBuffer**

Gets if the wiget is currently shown in the alternate buffer.

```csharp
protected bool IsAlternateBuffer { get; private set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **WigetBase()**

```csharp
protected WigetBase()
```

## Methods

### **Show(Boolean)**

Shows the wiget. If useAlternateBuffer is true, the wiget will be shown in the alternate buffer.

```csharp
public void Show(bool useAlternateBuffer)
```

#### Parameters

`useAlternateBuffer` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
id set to true the wiget will be shown in the alternate buffer.

### **Hide()**

Hides the wiget

```csharp
public void Hide()
```

### **OnShow()**

An overridable method that is called when the wiget is shown

```csharp
public abstract void OnShow()
```

### **OnHide()**

An overridable method that is called when the wiget is hidden

```csharp
public abstract void OnHide()
```

---

[`< Back`](./)
