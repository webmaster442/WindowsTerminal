// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

using Webmaster442.WindowsTerminal;
using Webmaster442.WindowsTerminal.Sixel.ImageSharp;

TerminalFormattedStringBuilder builder = new();

BasicFormatting();

WaitForKeyPress();

Colors256Demo();

WaitForKeyPress();

Colors24BitDemo();

WaitForKeyPress();

ProgrssbarDemo();

WaitForKeyPress();

MusicDemo();

await FragmentInstallDemo();

ShellIntegrationDemo();

SixelDemo();

void SixelDemo()
{
    var encoder = new SixelEncoder();
    var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
    var img = Image.Load<Rgba32>(imagePath);
    Console.Write(encoder.Encode(img));
}

void MusicDemo()
{
    Console.WriteLine("Music demo");
    MusicStringBuilder music = new();
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.C5);
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.D5);
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.E5);
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.F5);
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.G5);
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.A5);
    music.AddNote(6, TimeSpan.FromSeconds(1), Note.B5);
    Console.Write(music.ToString());
}

void WaitForKeyPress()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

void BasicFormatting()
{
    Console.WriteLine(builder
        .New()
        .WithItalic()
        .AppendLine("This text is italic")
        .ResetFormat());
    Console.WriteLine(builder
        .New()
        .WithUnderline()
        .AppendLine("This text is underlined")
        .ResetFormat());
    Console.WriteLine(builder
        .New()
        .WithInverse()
        .AppendLine("This text is inversed")
        .ResetFormat());
    Console.WriteLine(builder
        .New()
        .WithBold()
        .AppendLine("This text is bold")
        .ResetFormat());
}

void Colors256Demo()
{
    Console.WriteLine("256 colors demo");
    for (int i = 0; i < 16; i++)
    {
        for (int j = 0; j < 16; j++)
        {
            builder
                .WithForegroundColor(i * 16 + j)
                .Append("█");
        }
        builder.AppendLine();
    }
    builder.ResetFormat();
    Console.Write(builder.ToString());
}

void Colors24BitDemo()
{
    Console.WriteLine("24 bit colors demo");

    Console.WriteLine(builder
        .New()
        .WithBackgroundColor("#e2eef9")
        .WithForegroundColor("#000000")
        .WithBold()
        .AppendLine("24 bit color")
        .ResetFormat());
}

void ProgrssbarDemo()
{
    WindowsTerminal.SetWindowTitle("Progressbar demo");

    Console.WriteLine("Normal progress");
    int done = 0;
    for (int i = 0; i < 50; i++)
    {
        WindowsTerminal.SetProgressbar(ProgressbarState.Default, i);
        Thread.Sleep(50);
        done += 2;
    }

    Console.WriteLine("Error 50% progress");
    WindowsTerminal.SetProgressbar(ProgressbarState.Error, 50);
    Thread.Sleep(3000);

    Console.WriteLine("Indeterminate progress");
    WindowsTerminal.SetProgressbar(ProgressbarState.Indeterminate, 0);
    Thread.Sleep(3000);

    Console.WriteLine("Warning 75% progress");
    WindowsTerminal.SetProgressbar(ProgressbarState.Warning, 75);
    Thread.Sleep(3000);

    Console.WriteLine("Hidden progress");
    WindowsTerminal.SetProgressbar(ProgressbarState.Hidden, 0);

    WindowsTerminal.SetWindowTitle("");
}

async Task FragmentInstallDemo()
{

    var fragment = new TerminalFragment()
    {
        Profiles =
        {
            new TerminalProfile
            {
                Name = "Webmaster442.WindowsTerminalDemo",
                CommandLine = Path.Combine(AppContext.BaseDirectory, "Demo.exe"),
            }
        }
    };

    Console.WriteLine("Fragment JSON:");
    Console.WriteLine(fragment.ToJson());

    const string appName = "Webmaster442.WindowsTerminalDemo";
    const string fragmentName = "demoApp.json";
    if (!WindowsTerminal.FragmentExtensions.IsFragmentInstalled(appName, fragmentName))
    {
        Console.WriteLine("Fragment not installed. Install? (Y/N)");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            bool result = await WindowsTerminal.FragmentExtensions.TryInstallFragmentAsync(appName, fragmentName, fragment);
            if (result)
            {
                Console.WriteLine("Fragment installed");
            }
            else
            {
                Console.WriteLine("Fragment installation failed");
            }
        }
    }
    else
    {
        Console.WriteLine("Fragment already installed");
    }
}

void ShellIntegrationDemo()
{
    WindowsTerminal.SetWindowTitle("Shell integration demo");
    WindowsTerminal.ShellIntegration.StartOfPrompt();
    Console.Write("Enter a command >");
    WindowsTerminal.ShellIntegration.CommandStart();
    string? command = Console.ReadLine();
    WindowsTerminal.ShellIntegration.CommandExecuted();
    Console.WriteLine($"Command: {command}");
    WindowsTerminal.ShellIntegration.CommandFinished(0);
}