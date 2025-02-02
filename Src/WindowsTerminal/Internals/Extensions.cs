// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using System.Numerics;

namespace Webmaster442.WindowsTerminal.Internals;

internal static class Extensions
{
    public static T Restrict<T>(this T value, T minValue, T maxValue) where T : IComparisonOperators<T, T, bool>
    {
        if (value < minValue)
            return minValue;

        if (value > maxValue)
            return maxValue;

        return value;
    }
}
