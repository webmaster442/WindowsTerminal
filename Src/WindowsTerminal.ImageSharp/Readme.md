# Webmaster442.WindowsTerminal.ImageSharp

ImageSharp implementaton of the `ISixelImage` interface for use with the Windows Terminal allowing for rendering of Sixel images in the terminal.

## Usage

```csharp
var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
var img = ImageSharpSixelImage.FromFile(imagePath);
Console.Write(img);
```