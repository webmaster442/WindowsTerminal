[`< Back`](./)

---

# SixelOptions

Namespace: Webmaster442.WindowsTerminal

Controls image to sixel conversion options

```csharp
public struct SixelOptions
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [SixelOptions](./webmaster442.windowsterminal.sixeloptions.md)<br>
Implements [IEquatable&lt;SixelOptions&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)

## Fields

### **Default**

Default options

```csharp
public static SixelOptions Default;
```

## Properties

### **MaxSize**

Maximum size. If the image is greater than this size, it will be resized
 in a way specified by the SizeMode property. If null, then terminal window size is used.

```csharp
public Nullable<ValueTuple<int, int>> MaxSize { get; set; }
```

#### Property Value

[Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>

### **SizeMode**

Gets or sets the image sizeing mode

```csharp
public SizeMode SizeMode { get; set; }
```

#### Property Value

[SizeMode](./webmaster442.windowsterminal.sizemode.md)<br>

### **Colors**

Gets or sets the number of colors to use in the sixel image
 Maximum is 256

```csharp
public int Colors { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **SixelOptions()**

Creates a new instance of SixelOptions

```csharp
SixelOptions()
```

## Methods

### **ToString()**

```csharp
string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **GetHashCode()**

```csharp
int GetHashCode()
```

#### Returns

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Equals(Object)**

```csharp
bool Equals(object obj)
```

#### Parameters

`obj` [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Equals(SixelOptions)**

```csharp
bool Equals(SixelOptions other)
```

#### Parameters

`other` [SixelOptions](./webmaster442.windowsterminal.sixeloptions.md)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

---

[`< Back`](./)
