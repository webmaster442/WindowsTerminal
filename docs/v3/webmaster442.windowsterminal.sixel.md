[`< Back`](./)

---

# Sixel

Namespace: Webmaster442.WindowsTerminal

Sixel image protocol encoder

```csharp
public static class Sixel
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Sixel](./webmaster442.windowsterminal.sixel.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [ExtensionAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute)

## Properties

### **IsSupported**

Check if sixel is supported

```csharp
public static bool IsSupported { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Methods

### **GetTerminalWindowSize()**

Get the terminal window size in pixels

```csharp
public static ValueTuple<int, int> GetTerminalWindowSize()
```

#### Returns

[ValueTuple&lt;Int32, Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-2)<br>
A value tuple with the terminal window size

### **ImageToSixel(String, SixelOptions)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(string file, SixelOptions options)
```

#### Parameters

`file` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
An image file path to load and then encode to sixel

`options` [SixelOptions](./webmaster442.windowsterminal.sixeloptions.md)<br>
Sixel conversion options

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(String)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(string file)
```

#### Parameters

`file` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
An image file path to load and then encode to sixel

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Byte[], SixelOptions)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Byte[] data, SixelOptions options)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
An image data as a byte array that will be encoded

`options` [SixelOptions](./webmaster442.windowsterminal.sixeloptions.md)<br>
Sixel conversion options

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Byte[])**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Byte[] data)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
An image data as a byte array that will be encoded

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Stream, SixelOptions)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Stream stream, SixelOptions options)
```

#### Parameters

`stream` [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)<br>
An image data as a stram that will be encoded

`options` [SixelOptions](./webmaster442.windowsterminal.sixeloptions.md)<br>
Sixel conversion options

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Stream)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Stream stream)
```

#### Parameters

`stream` [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)<br>
An image data as a stram that will be encoded

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Image&lt;Rgba32&gt;, SixelOptions)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Image<Rgba32> image, SixelOptions options)
```

#### Parameters

`image` Image&lt;Rgba32&gt;<br>
Image to convert

`options` [SixelOptions](./webmaster442.windowsterminal.sixeloptions.md)<br>
Sixel conversion options

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Image&lt;Rgba32&gt;)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Image<Rgba32> image)
```

#### Parameters

`image` Image&lt;Rgba32&gt;<br>
Image to convert

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

---

[`< Back`](./)
