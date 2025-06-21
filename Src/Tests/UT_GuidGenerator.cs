namespace Webmaster442.WindowsTerminal.Tests;
internal class UT_GuidGenerator
{
    [TestCase("This is a test", "f3a31a6a-b762-5bb2-b179-574009ad928a")]
    [TestCase("Foobar", "04237446-90aa-54f8-991f-007342ffe8d4")]
    public void GenerateByName_ReturnsExpectedGuid(string name, string expected)
    {
        Guid generated = Internals.GuidGenerator.GenerateByName(name);
        Guid expectedGuid = new(expected);
        Assert.That(generated, Is.EqualTo(expectedGuid));
    }
}
