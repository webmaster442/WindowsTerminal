// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Numerics;
using System.Text.RegularExpressions;

namespace Webmaster442.WindowsTerminal.Internals;

internal static partial class Extensions
{
    public static T Restrict<T>(this T value, T minValue, T maxValue) where T : IComparisonOperators<T, T, bool>
    {
        if (value < minValue)
            return minValue;

        if (value > maxValue)
            return maxValue;

        return value;
    }

    public static (byte r, byte g, byte b) ToRgb(this string stringValue)
    {
        if (HexRgbFormat().IsMatch(stringValue))
        {
            byte[] value = Convert.FromHexString(stringValue.AsSpan(1));
            return (value[0], value[1], value[2]);
        }
        else if (RgbFormat().IsMatch(stringValue))
        {
            try
            {
                var match = RgbFormat().Match(stringValue);
                return (byte.Parse(match.Groups[1].Value), byte.Parse(match.Groups[2].Value), byte.Parse(match.Groups[3].Value));
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid Rrb format. Must be rgb(r, g, b). r, g, b values must be between 0-255", ex);
            }
        }
        else if (HslFormat().IsMatch(stringValue))
        {
            var match = HslFormat().Match(stringValue);
            try
            {
                double hue = double.Parse(match.Groups[1].Value);
                double saturation = double.Parse(match.Groups[2].Value);
                double light = double.Parse(match.Groups[3].Value);
                return HslToRgb(hue, saturation, light);
            }
            catch (Exception ex)
            {
                throw new FormatException("Invalid Hsl format. Must be: hsl(h, s%, l%)", ex);
            }
        }
        else
            throw new FormatException("Invalid colror format. Supported are: rgb(r, g, b), ##rrggbb and hsl(h, s%, l%)");
    }

    private static (byte r, byte g, byte b) HslToRgb(double hue, double saturation, double light)
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

        return ((byte)Math.Ceiling(r * 255), (byte)Math.Ceiling(g * 255), (byte)Math.Ceiling(b * 255));
    }

    [GeneratedRegex("^#[0-9a-fA-F]{6}$")]
    private static partial Regex HexRgbFormat();

    [GeneratedRegex(@"^hsl\(\s*(\d+)\s*,\s*(\d+)%\s*,\s*(\d+)%\s*\)$")]
    private static partial Regex HslFormat();

    [GeneratedRegex(@"^rgb\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*\)$")]
    private static partial Regex RgbFormat();
}
