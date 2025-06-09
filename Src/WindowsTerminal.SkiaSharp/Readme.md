# Webmaster442.WindowsTerminal.SkiaSharp

SkiaSharp implementaton of the `ISixelImage` interface for use with the Windows Terminal allowing for rendering of Sixel images in the terminal.

## Usage

```csharp
var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
var img = SkiaSharpSixelImage.FromFile(imagePath);
Console.Write(img);
```