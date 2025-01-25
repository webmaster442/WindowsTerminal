# Webmaster442.WindowsTerminal

![logo](Img/128x128.png)

A Windows Terminal Interaction libary

## Features

**Install a terminal Fragment extension**

```csharp
const string appName = "Webmaster442.WindowsTerminalDemo";
const string fragmentName = "demoApp.json";
if (!WindowsTerminal.FragmentExtensions.IsFragmentInstalled(appName, fragmentName))
{
    bool result = await WindowsTerminal.FragmentExtensions.TryInstallFragmentAsync(appName, fragmentName, new TerminalFragment()
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
WindowsTerminal.SetWindowTitle("Shell integration demo");
WindowsTerminal.ShellIntegration.StartOfPrompt();
Console.Write("Enter a command >");
WindowsTerminal.ShellIntegration.CommandStart();
string? command = Console.ReadLine();
WindowsTerminal.ShellIntegration.CommandExecuted();
Console.WriteLine($"Command: {command}");
WindowsTerminal.ShellIntegration.CommandFinished(0);
```

**Set window title and Display progress bar:**

```csharp
WindowsTerminal.SetWindowTitle("Progressbar demo");
WindowsTerminal.SetProgressbar(ProgressbarState.Default, 50);
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