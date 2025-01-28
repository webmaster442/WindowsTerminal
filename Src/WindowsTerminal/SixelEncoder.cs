// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Text;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Sixel Image encoder
/// </summary>
public sealed class SixelEncoder
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

    /// <summary>
    /// Get the cell size of the terminal
    /// </summary>
    /// <returns>A tupple containing cell width and height</returns>
    public (int width, int hegiht) GetCellSize()
    {
        var response = GetControlSequenceResponse("[16t");

        try
        {
            var parts = response.Split(';', 't');
            return (width: int.Parse(parts[2]), hegiht: int.Parse(parts[1]));
        }
        catch
        {
            // Return the default Windows Terminal size
            // if we can't get the size from the terminal.
            return (width: 10, hegiht: 20);
        }
    }

    private void AddColorToPalette(Color pixel, int colorIndex)
    {
        var r = (int)Math.Round(pixel.R / 255.0 * 100);
        var g = (int)Math.Round(pixel.G / 255.0 * 100);
        var b = (int)Math.Round(pixel.B / 255.0 * 100);

        _buffer
            .Append(SIXELCOLORSTART)
            .Append(colorIndex)
            .Append(";2;")
            .Append(r)
            .Append(';')
            .Append(g)
            .Append(';')
            .Append(b);
    }

    private void AppendRepeatEntry(int color,
                                          int repeatCounter,
                                          char e)
    {
        _buffer
            .Append(SIXELCOLORSTART)
            .Append(color)
            .Append(SIXELREPEAT)
            .Append(repeatCounter)
            .Append(color != 0 ? e : SIXELEMPTY);
    }

    private void AppendSixelEntry(int color, char e)
    {
        _buffer
            .Append(SIXELCOLORSTART)
            .Append(color)
            .Append(color != 0 ? e : SIXELEMPTY);
    }

    private void StartSixel(int width, int height)
    {
        _buffer
            .Append(SIXELSTART)
            .Append(SIXELRASTERATTRIBUTES)
            .Append(width)
            .Append(';')
            .Append(height)
            .Append(SIXELTRANSPARENTCOLOR);
    }

    private readonly StringBuilder _buffer;

    /// <summary>
    /// Creates a new instance of the Sixel encoder
    /// </summary>
    public SixelEncoder()
    {
        _buffer = new StringBuilder(32 * 1024);
    }

    /// <summary>
    /// Encode an image to a sixel string
    /// </summary>
    /// <param name="imageData">Image data to encode</param>
    /// <returns>A sixel encoded sting, that can be displayed</returns>
    public string Encode(IImageData imageData)
    {
        _buffer.Clear();
        var palette = new Dictionary<Color, int>();
        var colorCounter = 1;
        StartSixel(imageData.Width, imageData.Height);
        for (int y = 0; y < imageData.Height; y++)
        {
            var c = (char)(SIXELEMPTY + (1 << (y % 6)));
            var lastColor = -1;
            var repeatCounter = 0;
            for (int x = 0; x < imageData.Width; x++)
            {
                var pixel = imageData.Pixels[x, y];
                if (!palette.TryGetValue(pixel, out var colorIndex))
                {
                    colorIndex = colorCounter++;
                    palette[pixel] = colorIndex;
                    AddColorToPalette(pixel, colorIndex);
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
                    AppendRepeatEntry(lastColor, repeatCounter, c);
                }
                else
                {
                    AppendSixelEntry(lastColor, c);
                }
                lastColor = colorId;
                repeatCounter = 1;
            }
            if (repeatCounter > 1)
            {
                AppendRepeatEntry(lastColor, repeatCounter, c);
            }
            else
            {
                AppendSixelEntry(lastColor, c);
            }
            _buffer.Append(SIXELDECGCR);
            if (y % 6 == 5)
            {
                _buffer.Append(SIXELDECGNL);
            }
        }
        _buffer.Append(SIXELEND);
        return _buffer.ToString();
    }
}
