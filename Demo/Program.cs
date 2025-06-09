// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using Webmaster442.WindowsTerminal;
using Webmaster442.WindowsTerminal.Fragments;
using Webmaster442.WindowsTerminal.ImageSharp;
using Webmaster442.WindowsTerminal.SkiaSharp;
using Webmaster442.WindowsTerminal.Wigets;

TerminalFormattedStringBuilder builder = new();

BasicFormatting();

WaitForKeyPress();

Colors256Demo();

GetPaletteColors();

WaitForKeyPress();

Colors24BitDemo();

WaitForKeyPress();

WaitForKeyPress();

MusicDemo();

await FragmentInstallDemo();

ShellIntegrationDemo();

SixelDemoImageSharp();

WaitForKeyPress();

SixelDemoSkiaSharp();

WaitForKeyPress();

PagerDemo();

WaitForKeyPress();

ProgrssbarDemo();

WaitForKeyPress();

void GetPaletteColors()
{
    Console.Clear();
    Console.WriteLine("Palette colors");
    for (int i = 0; i < 15; i++)
    {
        var (r, g, b) = Terminal.GetPaletteColor(i);
        Console.WriteLine(builder.New()
            .WithForegroundColor(r, g, b)
            .Append("█")
            .ResetFormat()
            .AppendLine($" Color {i}: R:{r} G:{g} B:{b}"));
    }
}

void SixelDemoImageSharp()
{
    Console.Clear();
    Console.WriteLine($"Sixel is supported: {Terminal.IsSixelSupported}");

    Console.WriteLine("512x512, SizeMode = None");
    var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
    var img = ImageSharpSixelImage.FromFile(imagePath);
    Console.Write(img);

    Console.WriteLine("384x128, SizeMode = Fit");
    var fit = ImageSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.Fit
    });
    Console.Write(fit);

    Console.WriteLine("384x128, SizeMode = FitWidth");
    var fitWidth = ImageSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.FitWidth
    });
    Console.Write(fitWidth);

    Console.WriteLine("384x128, SizeMode = FitWidth");
    var fitHeight = ImageSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.FitHeight
    });
    Console.Write(fitHeight);

    Console.WriteLine("384x128, SizeMode = Manual");
    var manual = ImageSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.Manual
    });
    Console.Write(manual);
}

void SixelDemoSkiaSharp()
{
    Console.Clear();
    Console.WriteLine($"Sixel is supported: {Terminal.IsSixelSupported}");

    Console.WriteLine("512x512, SizeMode = None");
    var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
    var img = SkiaSharpSixelImage.FromFile(imagePath);
    Console.Write(img);

    Console.WriteLine("384x128, SizeMode = Fit");
    var fit = SkiaSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.Fit
    });
    Console.Write(fit);

    Console.WriteLine("384x128, SizeMode = FitWidth");
    var fitWidth = SkiaSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.FitWidth
    });
    Console.Write(fitWidth);

    Console.WriteLine("384x128, SizeMode = FitWidth");
    var fitHeight = SkiaSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.FitHeight
    });
    Console.Write(fitHeight);

    Console.WriteLine("384x128, SizeMode = Manual");
    var manual = SkiaSharpSixelImage.FromFile(imagePath, SixelOptions.Default with
    {
        MaxSize = (Width: 384, Height: 128),
        SizeMode = SizeMode.Manual
    });
    Console.Write(manual);
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
    Terminal.SetWindowTitle("Progressbar demo");

    Progressbar progressbar = new();
    progressbar.Show(useAlternateBuffer: true);
    int done = 0;
    for (int i = 0; i <= 50; i++)
    {
        progressbar.Report(done);
        Thread.Sleep(50);
        done += 2;
    }
    progressbar.Hide();
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
    if (!Terminal.FragmentExtensions.IsFragmentInstalled(appName, fragmentName))
    {
        Console.WriteLine("Fragment not installed. Install? (Y/N)");
        if (Console.ReadKey().Key == ConsoleKey.Y)
        {
            bool result = await Terminal.FragmentExtensions.TryInstallFragmentAsync(appName, fragmentName, fragment);
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
    Terminal.SetWindowTitle("Shell integration demo");
    Terminal.ShellIntegration.StartOfPrompt();
    Console.Write("Enter a command >");
    Terminal.ShellIntegration.CommandStart();
    string? command = Console.ReadLine();
    Terminal.ShellIntegration.CommandExecuted();
    Console.WriteLine($"Command: {command}");
    Terminal.ShellIntegration.CommandFinished(0);
}

void PagerDemo()
{
    using var reader = File.OpenText(Path.Combine(AppContext.BaseDirectory, "LoremIpsum.txt"));
    var pager = new Pager(reader);
    pager.Show(useAlternateBuffer: true);
}