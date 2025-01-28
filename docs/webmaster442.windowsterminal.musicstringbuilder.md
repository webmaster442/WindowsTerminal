[`< Back`](./)

---

# MusicStringBuilder

Namespace: Webmaster442.WindowsTerminal

DECPS music note builder

```csharp
public sealed class MusicStringBuilder
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MusicStringBuilder](./webmaster442.windowsterminal.musicstringbuilder)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **RemainingNotes**

Number of remaining notes. DECPS supports up to 16 notes

```csharp
public int RemainingNotes { get; private set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

## Constructors

### **MusicStringBuilder()**

Creates a new music string builder

```csharp
public MusicStringBuilder()
```

## Methods

### **New()**

Resets the internal state of the music string builder

```csharp
public MusicStringBuilder New()
```

#### Returns

[MusicStringBuilder](./webmaster442.windowsterminal.musicstringbuilder)<br>
A MusicStringBuilder to chain formatting

### **AddNote(Int32, TimeSpan, Note)**

Add a note to the music string

```csharp
public MusicStringBuilder AddNote(int volume, TimeSpan duration, Note note)
```

#### Parameters

`volume` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Note volume. Must be between 0 and 7. 0 - Silent, 7 - Lodest

`duration` [TimeSpan](https://docs.microsoft.com/en-us/dotnet/api/system.timespan)<br>
Note duration. Rounded to the nearest 1/32 seconds

`note` [Note](./webmaster442.windowsterminal.note)<br>
Muiscal note to play

#### Returns

[MusicStringBuilder](./webmaster442.windowsterminal.musicstringbuilder)<br>
A MusicStringBuilder to chain formatting

#### Exceptions

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>
When there are no more remaining notes

### **ToString()**

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

---

[`< Back`](./)
