// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

namespace Webmaster442.WindowsTerminal.Tests;

[TestFixture]
public class UT_Color
{
    [TestCase("#000000", 0, 0, 0)]
    [TestCase("rgb(0, 0, 0)", 0, 0, 0)]
    [TestCase("hsl(0, 0%, 0%)", 0, 0, 0)]
    [TestCase("#ffffff", 255, 255, 255)]
    [TestCase("rgb(255, 255, 255)", 255, 255, 255)]
    [TestCase("hsl(0, 0%, 100%)", 255, 255, 255)]
    [TestCase("#262335", 38, 35, 53)]
    [TestCase("rgb(38, 35, 53)", 38, 35, 53)]
    [TestCase("hsl(250, 20%, 17%)", 38, 35, 53)]
    public void ToRrbParsesSupported(string rgb, byte r, byte g, byte b)
    {
        var result = Color.Parse(rgb, null);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.R, Is.EqualTo(r));
            Assert.That(result.G, Is.EqualTo(g));
            Assert.That(result.B, Is.EqualTo(b));
        }
    }
}
