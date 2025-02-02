using System.Diagnostics;
using System.Text;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Quantization;

namespace Webmaster442.WindowsTerminal;

//Based on: https://github.com/trackd/Sixel
/// <summary>
/// Sixel image protocol encoder
/// </summary>
public static class Sixel
{
    private const char SIXELEMPTY = '?';
    private const char SIXELCOLORSTART = '#';
    private const char SIXELREPEAT = '!';
    private const char SIXELDECGCR = '$';
    private const char SIXELDECGNL = '-';
    private const string SIXELSTART = $"\eP0;1q";
    private const string SIXELEND = $"\e\\";
    private const string SIXELTRANSPARENTCOLOR = "#0;2;0;0;0";
    private const string SIXELRASTERATTRIBUTES = "\"1;1;";

    private static string GetControlSequenceResponse(string controlSequence)
    {
        char? c;
        var response = string.Empty;

        Console.Write($"\e{controlSequence}");
        do
        {
            c = Console.ReadKey(true).KeyChar;
            response += c;
        } while (c != 'c' && Console.KeyAvailable);

        return response;
    }

    private static (int width, int hegiht) GetTerminalWindowSize()
    {
        var response = GetControlSequenceResponse("[16t");

        try
        {
            var parts = response.Split(';', 't');
            return (width: int.Parse(parts[2]) * Console.WindowWidth, hegiht: int.Parse(parts[1]) * Console.WindowHeight);
        }
        catch
        {
            // Return the default Windows Terminal size
            // if we can't get the size from the terminal.
            return (width: 10 * Console.WindowWidth, hegiht: 20 * Console.WindowHeight);
        }
    }

    /// <summary>
    /// Converts an image to a Sixel string
    /// </summary>
    /// <param name="image">Image to convert</param>
    /// <param name="maxSize">Max size. If not specified, Terminal Window size is used</param>
    /// <returns>Image encoded as a sixel string. Can be displayed With Console.Write</returns>
    public static string ImageToSixel(Image<Rgba32> image, (int width, int height)? maxSize = null)
    {
        var terminalSize = GetTerminalWindowSize();

        if (!maxSize.HasValue)
        {
            maxSize = terminalSize;
        }

        int cellWidth = Console.WindowWidth;
        image.Mutate(ctx =>
        {
            ctx.Resize(new ResizeOptions()
            {
                Sampler = KnownResamplers.Bicubic,
                Size = CalculateSize(image, maxSize.Value),
                PremultiplyAlpha = false,
            });

            // Sixel supports 256 colors max
            ctx.Quantize(new OctreeQuantizer(new()
            {
                MaxColors = 256,
            }));
        });
        var targetFrame = image.Frames[0];
        return FrameToSixelString(targetFrame);
    }

    private static Size CalculateSize(Image<Rgba32> image, (int width, int height) maxSizeConstraint)
    {
        if (image.Width > maxSizeConstraint.width)
        {
            var ratio = (double)maxSizeConstraint.width / image.Width;
            return new Size(maxSizeConstraint.width, (int)Math.Round(image.Height * ratio));
        }
        else if (image.Height > maxSizeConstraint.height)
        {
            var ratio = (double)maxSizeConstraint.height / image.Height;
            return new Size((int)Math.Round(image.Width * ratio), maxSizeConstraint.height);
        }
        else
        {
            return new Size(image.Width, image.Height);
        }
    }

    private static string FrameToSixelString(ImageFrame<Rgba32> frame)
    {
        var sixelBuilder = new StringBuilder();
        var palette = new Dictionary<Rgba32, int>();
        var colorCounter = 1;
        sixelBuilder.StartSixel(frame.Width, frame.Height);
        frame.ProcessPixelRows(accessor =>
        {
            for (var y = 0; y < accessor.Height; y++)
            {
                var pixelRow = accessor.GetRowSpan(y);
                // The way sixel works, this bitshift starting from the SIXELEMPTY constant
                // will give us the correct character to use for the current row.
                // Every six rows we swap back to the "empty character + 1" after adding a newline
                // character to the string.
                var c = (char)(SIXELEMPTY + (1 << (y % 6)));
                var lastColor = -1;
                var repeatCounter = 0;
                foreach (ref var pixel in pixelRow)
                {
                    if (!palette.TryGetValue(pixel, out var colorIndex))
                    {
                        colorIndex = colorCounter++;
                        palette[pixel] = colorIndex;
                        sixelBuilder.AddColorToPalette(pixel, colorIndex);
                    }
                    var colorId = pixel.A == 0 ? 0 : colorIndex;
                    if (colorId == lastColor || repeatCounter == 0)
                    {
                        lastColor = colorId;
                        repeatCounter++;
                        continue;
                    }
                    if (repeatCounter > 1)
                    {
                        sixelBuilder.AppendRepeatEntry(lastColor, repeatCounter, c);
                    }
                    else
                    {
                        sixelBuilder.AppendSixelEntry(lastColor, c);
                    }
                    lastColor = colorId;
                    repeatCounter = 1;
                }
                if (repeatCounter > 1)
                {
                    sixelBuilder.AppendRepeatEntry(lastColor, repeatCounter, c);
                }
                else
                {
                    sixelBuilder.AppendSixelEntry(lastColor, c);
                }
                sixelBuilder.Append(SIXELDECGCR);
                if (y % 6 == 5)
                {
                    sixelBuilder.Append(SIXELDECGNL);
                }
            }
        });
        sixelBuilder.Append(SIXELEND);

        Debug.WriteLine(sixelBuilder.Length);

        return sixelBuilder.ToString();
    }

    private static void AddColorToPalette(this StringBuilder sixelBuilder,
                                          Rgba32 pixel,
                                          int colorIndex)
    {
        var r = (int)Math.Round(pixel.R / 255.0 * 100);
        var g = (int)Math.Round(pixel.G / 255.0 * 100);
        var b = (int)Math.Round(pixel.B / 255.0 * 100);

        sixelBuilder.Append(SIXELCOLORSTART)
                    .Append(colorIndex)
                    .Append(";2;")
                    .Append(r)
                    .Append(';')
                    .Append(g)
                    .Append(';')
                    .Append(b);
    }

    private static void AppendRepeatEntry(this StringBuilder sixelBuilder,
                                          int color,
                                          int repeatCounter,
                                          char e)
    {
        sixelBuilder.Append(SIXELCOLORSTART)
                    .Append(color)
                    .Append(SIXELREPEAT)
                    .Append(repeatCounter)
                    .Append(color != 0 ? e : SIXELEMPTY);
    }

    private static void AppendSixelEntry(this StringBuilder sixelBuilder, int color, char e)
    {
        sixelBuilder.Append(SIXELCOLORSTART)
                    .Append(color)
                    .Append(color != 0 ? e : SIXELEMPTY);
    }

    private static void StartSixel(this StringBuilder sixelBuilder, int width, int height)
    {
        sixelBuilder.Append(SIXELSTART)
                    .Append(SIXELRASTERATTRIBUTES)
                    .Append(width)
                    .Append(';')
                    .Append(height)
                    .Append(SIXELTRANSPARENTCOLOR);
    }
}