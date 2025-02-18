using Webmaster442.WindowsTerminal.Internals;

namespace Webmaster442.WindowsTerminal.Tests;

[TestFixture]
public class UT_Extensions
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
        var result = Extensions.ToRgb(rgb);
        Assert.Multiple(() =>
        {
            Assert.That(result.r, Is.EqualTo(r));
            Assert.That(result.g, Is.EqualTo(g));
            Assert.That(result.b, Is.EqualTo(b));
        });
    }
}
