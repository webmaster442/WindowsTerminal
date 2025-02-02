# Webmaster442.WindowsTerminal.Sixel

![logo](https://raw.githubusercontent.com/webmaster442/WindowsTerminal/main/Img/128x128.png)

A Windows Terminal Interaction libary Sixel extension.

This libary allows you to display an image in the Terminal using the Sixel protocol. Note: Sixel protocol is not supported by all terminals. Windows Terminal supports Sixel images in the 1.22 or latest versions.

Example usage:

```csharp
Console.WriteLine($"Sixel is supported: {Sixel.IsSupported}");

var imagePath = Path.Combine(AppContext.BaseDirectory, "512x512.png");
var img = Sixel.ImageToSixel(imagePath);
Console.Write(img);
```