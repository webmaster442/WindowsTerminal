[`< Back`](./)

---

# TerminalProfile

Namespace: Webmaster442.WindowsTerminal

A profile is a set of settings that can be applied to a terminal window.

```csharp
public class TerminalProfile : System.IEquatable`1[[Webmaster442.WindowsTerminal.TerminalProfile, Webmaster442.WindowsTerminal, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null]]
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>
Implements [IEquatable&lt;TerminalProfile&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute), [RequiredMemberAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.requiredmemberattribute)

## Properties

### **EqualityContract**

```csharp
protected Type EqualityContract { get; }
```

#### Property Value

[Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

### **Name**

This is the name of the profile that will be displayed in the dropdown menu.

```csharp
public string Name { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **CommandLine**

This is the executable used in the profile.

```csharp
public string CommandLine { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **StartingDirectory**

This is the directory the shell starts in when it is loaded.

```csharp
public string StartingDirectory { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Icon**

This sets the icon that displays within the tab, dropdown menu, jumplist, and tab switcher.

```csharp
public string Icon { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **TabTitle**

If set, this will replace the name as the title to pass to the shell on startup. 
 Some shells (like bash) may choose to ignore this initial value, while others (Command Prompt, PowerShell) may 
 use this value over the lifetime of the application.

```csharp
public string TabTitle { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Elevate**

If set, this profile will automatically open up in an "elevated" window (running as Administrator) by default.

```csharp
public bool Elevate { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Hidden**

If hidden is set to true, the profile will not appear in the list of profiles. 
 This can be used to hide default profiles and dynamically generated profiles

```csharp
public bool Hidden { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **ColorScheme**

This is the name of the color scheme used in the profile. Color schemes are defined in the schemes object.

```csharp
public string ColorScheme { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **UseAcrylic**

When this is set to true, the window will have an acrylic background. When it's set to false, the window will have a plain, untextured background.

```csharp
public bool UseAcrylic { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **BackgroundImage**

This sets the file location of the image to draw over the window background. The background image can be a .jpg, .png, or .gif file. "desktopWallpaper" will set the background image to the desktop's wallpaper.

```csharp
public string BackgroundImage { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **BackgroundImageOpacity**

This sets the transparency of the background image.

```csharp
public double BackgroundImageOpacity { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **BackgroundImageAlignment**

This sets how the background image aligns to the boundaries of the window.

```csharp
public TerminalBackgroundImageAlignment BackgroundImageAlignment { get; set; }
```

#### Property Value

[TerminalBackgroundImageAlignment](./webmaster442.windowsterminal.terminalbackgroundimagealignment.md)<br>

### **BackgroundImageStretchMode**

This sets how the background image is resized to fill the window.

```csharp
public TerminalBackgroundImageStretchMode BackgroundImageStretchMode { get; set; }
```

#### Property Value

[TerminalBackgroundImageStretchMode](./webmaster442.windowsterminal.terminalbackgroundimagestretchmode.md)<br>

### **Opacity**

This sets the transparency of the window for the profile.
 This accepts an integer value from 0-100, representing a "percent opaque".
 100 is "fully opaque", 50 is semi-transparent, and 0 is fully transparent.

```csharp
public int Opacity { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **ShowMarksOnScrollbar**

Show marks on the scrollbar. Enable this option for shell integration.

```csharp
public bool ShowMarksOnScrollbar { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **AutoMarkPrompts**

Atuo mark prompts. Enable this option for shell integration.

```csharp
public bool AutoMarkPrompts { get; set; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Font**

Font settings for the profile

```csharp
public TerminalFont Font { get; set; }
```

#### Property Value

[TerminalFont](./webmaster442.windowsterminal.terminalfont.md)<br>

## Constructors

### **TerminalProfile()**

#### Caution

Constructors of types with required members are not supported in this version of your compiler.

---

Creates a new instance of the TerminalProfile class.

```csharp
public TerminalProfile()
```

### **TerminalProfile(TerminalProfile)**

```csharp
protected TerminalProfile(TerminalProfile original)
```

#### Parameters

`original` [TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>

## Methods

### **CreateAnaconda3(String)**

Crates a Terminal profile for Anaconda3

```csharp
public static TerminalProfile CreateAnaconda3(string installPath)
```

#### Parameters

`installPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Anaconda3 install path.

#### Returns

[TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>
A terminal profile configured for Anaconda3.

### **CreateCmder(String)**

Crates a Terminal profile for Cmder

```csharp
public static TerminalProfile CreateCmder(string installPath)
```

#### Parameters

`installPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Cmder install path.

#### Returns

[TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>
A terminal profile configured for Cmder

### **CreateCygwin(String)**

Creates a Terminal profile for Cygwin

```csharp
public static TerminalProfile CreateCygwin(string installPath)
```

#### Parameters

`installPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Cygwin install path.

#### Returns

[TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>
A terminal profile configured for Cygwin

### **CreateFarManager(String)**

Creates a Terminal profile for Far Manager

```csharp
public static TerminalProfile CreateFarManager(string installPath)
```

#### Parameters

`installPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Far manager install path.

#### Returns

[TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>
A terminal profile configured for Far

### **CreateGitBash(String)**

Creates a Terminal profile for Git Bash

```csharp
public static TerminalProfile CreateGitBash(string installPath)
```

#### Parameters

`installPath` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Git bash install path

#### Returns

[TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>
A terminal profile configured for git bash

### **ToString()**

```csharp
public string ToString()
```

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **PrintMembers(StringBuilder)**

```csharp
protected bool PrintMembers(StringBuilder builder)
```

#### Parameters

`builder` [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

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

### **Equals(TerminalProfile)**

```csharp
public bool Equals(TerminalProfile other)
```

#### Parameters

`other` [TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>

#### Returns

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **&lt;Clone&gt;$()**

```csharp
public TerminalProfile <Clone>$()
```

#### Returns

[TerminalProfile](./webmaster442.windowsterminal.terminalprofile.md)<br>

---

[`< Back`](./)
