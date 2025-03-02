[`< Back`](./)

---

# Progressbar

Namespace: Webmaster442.WindowsTerminal.Wigets

Progress bar display

```csharp
public class Progressbar : WigetBase, System.IProgress`1[[System.Int32, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], System.IProgress`1[[System.Double, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], System.IProgress`1[[System.Single, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [WigetBase](./webmaster442.windowsterminal.wigets.wigetbase.md) → [Progressbar](./webmaster442.windowsterminal.wigets.progressbar.md)<br>
Implements [IProgress&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iprogress-1), [IProgress&lt;Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iprogress-1), [IProgress&lt;Single&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iprogress-1)

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

### **Progressbar()**

Create a new progress bar

```csharp
public Progressbar()
```

## Methods

### **OnProgressChanged()**

An overridable method that is called when the progress bar is updated

```csharp
protected void OnProgressChanged()
```

### **OnHide()**

Hide the progress bar

```csharp
public void OnHide()
```

### **OnShow()**

Show the progress bar

```csharp
public void OnShow()
```

### **Report(Double)**

Reports a progress update.

```csharp
public void Report(double value)
```

#### Parameters

`value` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The value of the updated progress.

### **Report(Single)**

Reports a progress update.

```csharp
public void Report(float value)
```

#### Parameters

`value` [Single](https://docs.microsoft.com/en-us/dotnet/api/system.single)<br>
The value of the updated progress.

### **Report(Int32)**

Reports a progress update.

```csharp
public void Report(int value)
```

#### Parameters

`value` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
The value of the updated progress.

---

[`< Back`](./)
