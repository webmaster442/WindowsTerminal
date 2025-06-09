using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Represents a color in RGB format.
/// </summary>
public readonly partial record struct Color : IParsable<Color>
{
    [GeneratedRegex("^#[0-9a-fA-F]{6}$")]
    private static partial Regex HexRgbFormat();

    [GeneratedRegex(@"^hsl\(\s*(\d+)\s*,\s*(\d+)%\s*,\s*(\d+)%\s*\)$")]
    private static partial Regex HslFormat();

    [GeneratedRegex(@"^rgb\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*\)$")]
    private static partial Regex RgbFormat();

    /// <summary>
    /// Gets the Red component.
    /// </summary>
    public byte R { get; }

    /// <summary>
    /// Gets the Green component.
    /// </summary>
    public byte G { get; }

    /// <summary>
    /// Gets the Blue component.
    /// </summary>
    public byte B { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Color"/> struct with the specified RGB values.
    /// </summary>
    /// <param name="r">The red component.</param>
    /// <param name="g">The green component.</param>
    /// <param name="b">The blue component.</param>
    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    /// <summary>
    /// Parse a color from a string representation.
    /// </summary>
    /// <param name="s">string representation. Supported formats are: Supported are: rgb(r, g, b), ##rrggbb and hsl(h, s%, l%)</param>
    /// <param name="provider">format provider</param>
    /// <returns>A color in RGB space</returns>
    /// <exception cref="FormatException">Invalid format was specified</exception>
    public static Color Parse(string s, IFormatProvider? provider)
    {
        if (HexRgbFormat().IsMatch(s))
        {
            byte[] value = Convert.FromHexString(s.AsSpan(1));
            return new(value[0], value[1], value[2]);
        }
        else if (RgbFormat().IsMatch(s))
        {
            try
            {
                var match = RgbFormat().Match(s);
                return new(byte.Parse(match.Groups[1].Value), byte.Parse(match.Groups[2].Value), byte.Parse(match.Groups[3].Value));
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid Rrb format. Must be rgb(r, g, b). r, g, b values must be between 0-255", ex);
            }
        }
        else if (HslFormat().IsMatch(s))
        {
            var match = HslFormat().Match(s);
            try
            {
                double hue = double.Parse(match.Groups[1].Value);
                double saturation = double.Parse(match.Groups[2].Value);
                double light = double.Parse(match.Groups[3].Value);
                return FromHsl(hue, saturation, light);
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid Hsl format. Must be: hsl(h, s%, l%)", ex);
            }
        }
        else
        {
            throw new FormatException("Invalid colror format. Supported are: rgb(r, g, b), ##rrggbb and hsl(h, s%, l%)");
        }
    }

    /// <summary>
    /// Try to Parse a color from a string representation.
    /// </summary>
    /// <param name="s">string representation. Supported formats are: Supported are: rgb(r, g, b), ##rrggbb and hsl(h, s%, l%)</param>
    /// <param name="provider">format provider</param>
    /// <param name="result">A color in RGB space</param>
    /// <returns>true, if parsing was successfull, otherwise false</returns>
    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Color result)
    {
        if (string.IsNullOrEmpty(s))
        {
            result = default;
            return false;
        }
        try
        {
            result = Parse(s, provider);
            return true;
        }
        catch (FormatException)
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Create a color from its HSL representation.
    /// </summary>
    /// <param name="hue">Color Hue</param>
    /// <param name="saturation">Color saturation</param>
    /// <param name="light">Color light</param>
    /// <returns>A color in RGB space</returns>
    public static Color FromHsl(double hue, double saturation, double light)
    {
        static double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 1;
            if (t > 1) t -= 1;
            if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
            if (t < 1.0 / 2.0) return q;
            if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
            return p;
        }

        double h = hue / 360.0;
        double s = saturation / 100.0;
        double l = light / 100.0;

        double r = l, g = l, b = l;

        if (s != 0)
        {
            double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            double p = 2 * l - q;
            r = HueToRgb(p, q, h + 1.0 / 3.0);
            g = HueToRgb(p, q, h);
            b = HueToRgb(p, q, h - 1.0 / 3.0);
        }

        return new((byte)Math.Ceiling(r * 255), (byte)Math.Ceiling(g * 255), (byte)Math.Ceiling(b * 255));
    }
}