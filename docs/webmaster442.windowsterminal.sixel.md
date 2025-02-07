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

### **ImageToSixel(String, Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(string file, Nullable<ValueTuple<int, int>> maxSize)
```

#### Parameters

`file` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
An image file path to load and then encode to sixel

`maxSize` [Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Max size. If not specified, Terminal Window size is used

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Byte[], Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Byte[] data, Nullable<ValueTuple<int, int>> maxSize)
```

#### Parameters

`data` [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)<br>
An image data as a byte array that will be encoded

`maxSize` [Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Max size. If not specified, Terminal Window size is used

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Stream, Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Stream stream, Nullable<ValueTuple<int, int>> maxSize)
```

#### Parameters

`stream` [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)<br>
An image data as a stram that will be encoded

`maxSize` [Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Max size. If not specified, Terminal Window size is used

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

### **ImageToSixel(Image&lt;Rgba32&gt;, Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;)**

Converts an image to a Sixel string

```csharp
public static string ImageToSixel(Image<Rgba32> image, Nullable<ValueTuple<int, int>> maxSize)
```

#### Parameters

`image` Image&lt;Rgba32&gt;<br>
Image to convert

`maxSize` [Nullable&lt;ValueTuple&lt;Int32, Int32&gt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Max size. If not specified, Terminal Window size is used

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Image encoded as a sixel string. Can be displayed With Console.Write

---

[`< Back`](./)
