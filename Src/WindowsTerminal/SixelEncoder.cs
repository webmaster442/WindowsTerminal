using System.Text;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Sixel image protocol encoder
/// Based on: https://github.com/trackd/Sixel
/// </summary>
public static class SixelEncoder
{
    private const char SIXELEMPTY = '?';
    private const char SIXELCOLORSTART = '#';
    private const char SIXELREPEAT = '!';
    private const char SIXELDECGCR = '$';
    private const char SIXELDECGNL = '-';
    private const string SIXELSTART = "\eP0;1q";
    private const string SIXELEND = "\e\\";
    private const string SIXELTRANSPARENTCOLOR = "#0;2;0;0;0";
    private const string SIXELRASTERATTRIBUTES = "\"1;1;";

    private static void AddColorToPalette(this StringBuilder sixelBuilder, Color pixel, int colorIndex)
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

    /// <summary>
    /// Encode an ISixelImage into a Sixel string.
    /// ISixelImage is an interface that represents an RGB image that can be encoded into Sixel format.
    /// Implmentations of ISixelImage are in Webmaster442.WindowsTerminal.ImageSharp package and WindowsTerminal.SkiaSharp package.
    /// </summary>
    /// <param name="image">An ISixelImage to encode</param>
    /// <returns>Sixel encoded string</returns>
    public static string Encode(ISixelImage image)
    {
        static int AllocateSize(ISixelImage image)
            => (image.Width / 6) * image.Height;

        var sixelBuilder = new StringBuilder(AllocateSize(image));
        var palette = new Dictionary<Color, int>();
        var colorCounter = 1;
        sixelBuilder.StartSixel(image.Width, image.Height);

        for (var y = 0; y < image.Height; y++)
        {
            // The way sixel works, this bitshift starting from the SIXELEMPTY constant
            // will give us the correct character to use for the current row.
            // Every six rows we swap back to the "empty character + 1" after adding a newline
            // character to the string.
            var c = (char)(SIXELEMPTY + (1 << (y % 6)));
            var lastColor = -1;
            var repeatCounter = 0;
            for (int x = 0; x < image.Width; x++)
            {
                var pixel = image.GetColor(x, y);
                if (!palette.TryGetValue(pixel, out var colorIndex))
                {
                    colorIndex = colorCounter++;
                    palette[pixel] = colorIndex;
                    sixelBuilder.AddColorToPalette(pixel, colorIndex);
                }
                var colorId = colorIndex;
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
        sixelBuilder.Append(SIXELEND);
        return sixelBuilder.ToString();
    }
}
