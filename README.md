# Webmaster442.WindowsTerminal

![logo](https://raw.githubusercontent.com/webmaster442/WindowsTerminal/main/Img/128x128.png)

A Windows Terminal Interaction libary

## Installation

Via NuGet: https://www.nuget.org/packages/Webmaster442.WindowsTerminal

Sixel support requires one of the following addon packages:

* https://www.nuget.org/packages/Webmaster442.WindowsTerminal.ImageSharp/ - Uses SixLabors.ImageSharp
* https://www.nuget.org/packages/Webmaster442.WindowsTerminal.SkiaSharp/ - Uses SkiaSharp

Two flavors are provided to allow users to pick their preferred image processing library without forcing a dependency on one or the other.

Via .NET Cli:

```bash
dotnet add package Webmaster442.WindowsTerminal
```

For sixel graphics support, add one of the following packages:

```bash
dotnet add package Webmaster442.WindowsTerminal.ImageSharp
```

or

```bash
dotnet add package Webmaster442.WindowsTerminal.SkiaSharp
```

## Features

**Install a terminal Fragment extension**

```csharp
const string appName = "Webmaster442.WindowsTerminalDemo";
const string fragmentName = "demoApp.json";
if (!Terminal.FragmentExtensions.IsFragmentInstalled(appName, fragmentName))
{
    bool result = await Terminal.FragmentExtensions.TryInstallFragmentAsync(appName, fragmentName, new TerminalFragment()
    {
        Profiles = 
        {
            new TerminalProfile
            {
                Name = "Webmaster442.WindowsTerminalDemo",
                CommandLine = Path.Combine(AppContext.BaseDirectory, "Demo.exe"),
                StartingDirectory = EnvironmentVariables.HomePath,
            }
        }
    });
}
else
{
    Console.WriteLine("Fragment already installed");
}
```

**Send shell integration marks**

```csharp
Terminal.SetWindowTitle("Shell integration demo");
Terminal.ShellIntegration.StartOfPrompt();
Console.Write("Enter a command >");
Terminal.ShellIntegration.CommandStart();
string? command = Console.ReadLine();
Terminal.ShellIntegration.CommandExecuted();
Console.WriteLine($"Command: {command}");
Terminal.ShellIntegration.CommandFinished(0);
```

**Set window title and Display progress bar:**

```csharp
Terminal.SetWindowTitle("Progressbar demo");
Terminal.SetProgressbar(ProgressbarState.Default, 50);
```

**Write Formatted string to the terminal:**

```csharp
TerminalFormattedStringBuilder builder = new();
Console.WriteLine(builder
    .New()
    .WithBackgroundColor("#e2eef9")
    .WithForegroundColor("#000000")
    .WithBold()
    .AppendLine("24 bit color")
    .ResetFormat());
```

**Create a DECPS sound:**

```csharp
MusicStringBuilder music = new();
music.AddNote(6, TimeSpan.FromSeconds(1), Note.C5);
music.AddNote(6, TimeSpan.FromSeconds(1), Note.D5);
music.AddNote(6, TimeSpan.FromSeconds(1), Note.E5);
music.AddNote(6, TimeSpan.FromSeconds(1), Note.F5);
music.AddNote(6, TimeSpan.FromSeconds(1), Note.G5);
music.AddNote(6, TimeSpan.FromSeconds(1), Note.A5);
music.AddNote(6, TimeSpan.FromSeconds(1), Note.B5);
Console.Write(music.ToString());
```

**Create a Sixel image:**

Note : This feature requires the `Webmaster442.WindowsTerminal.ImageSharp` or `Webmaster442.WindowsTerminal.SkiaSharp` package.

```csharp

Console.WriteLine($"Sixel is supported: {Terminal.IsSixelSupported}");

var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
var img = ImageSharpSixelImage.FromFile(imagePath);
Console.Write(img);

var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
var img = SkiaSharpSixelImage.FromFile(imagePath);
Console.Write(img);
```
