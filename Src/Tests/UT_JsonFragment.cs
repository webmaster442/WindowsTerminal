namespace Webmaster442.WindowsTerminal.Tests;

[TestFixture]
public class UT_JsonFragment
{
    [Test]
    public void ToJsonReturnsExpectedFragmentJsonForBasic()
    {
        var fragment = new TerminalFragment()
        {
            Profiles =
            {
                new TerminalProfile
                {
                    Name = "Webmaster442.WindowsTerminalDemo",
                    CommandLine = "test.exe",
                }
            }
        };

        string expected = """
            {
              "profiles": [
                {
                  "name": "Webmaster442.WindowsTerminalDemo",
                  "commandline": "test.exe",
                  "startingDirectory": "%USERPROFILE%",
                  "backgroundImageOpacity": 1,
                  "opacity": 100
                }
              ],
              "schemes": [],
              "actions": []
            }
            """;

        Assert.That(fragment.ToJson(), Is.EqualTo(expected));
    }

    [Test]
    public void ToJsonReturnsExpectedFragmentJsonForBackgroundAlignmentAndStretch()
    {
        var fragment = new TerminalFragment()
        {
            Profiles =
            {
                new TerminalProfile
                {
                    Name = "Webmaster442.WindowsTerminalDemo",
                    CommandLine = "test.exe",
                    BackgroundImageStretchMode = TerminalBackgroundImageStretchMode.None,
                    BackgroundImageAlignment = TerminalBackgroundImageAlignment.BottomRight,
                }
            }
        };

        string expected = """
            {
              "profiles": [
                {
                  "name": "Webmaster442.WindowsTerminalDemo",
                  "commandline": "test.exe",
                  "startingDirectory": "%USERPROFILE%",
                  "backgroundImageOpacity": 1,
                  "backgroundImageAlignment": "bottomRight",
                  "backgroundImageStretchMode": "none",
                  "opacity": 100
                }
              ],
              "schemes": [],
              "actions": []
            }
            """;

        Assert.That(fragment.ToJson(), Is.EqualTo(expected));
    }

    [Test]
    public void ToJsonReturnsExpectedFragmentJsonBasicAppCommand()
    {
        var fragment = new TerminalFragment()
        {
            Actions =
            {
                new TerminalAction
                {
                    Name = "Test action",
                    Command = TerminalCommand.Quit,
                },
                new TerminalAction
                {
                    Name = "Phone up Bram Stoker",
                    Command = TerminalCommand.SetColorScheme("Dracula"),
                    Id = "Dracula.Draculize",
                }
            }
        };

        string expected = """
            {
              "profiles": [],
              "schemes": [],
              "actions": [
                {
                  "command": "quit",
                  "name": "Test action"
                },
                {
                  "command": {
                    "action": "setColorScheme",
                    "colorScheme": "Dracula"
                  },
                  "name": "Phone up Bram Stoker",
                  "id": "Dracula.Draculize"
                }
              ]
            }
            """;

        var actual = fragment.ToJson();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToJsonReturnsExpectedFragmentJsonThemeSwithcer()
    {
        var fragment = new TerminalFragment()
        {
            Actions =
            {
                new TerminalAction
                {
                    Command = TerminalCommand.SetColorScheme(TerminalSchemes.PurplepeterShecme.Name),
                    Id = "User.SetSchemeToPurplepeter"
                },
                new TerminalAction
                {
                    Command = TerminalCommand.SetColorScheme(TerminalSchemes.Dracula.Name),
                    Id = "User.SetSchemeToDracula",
                }
            }
        };

        string expected = """
            {
              "profiles": [],
              "schemes": [],
              "actions": [
                {
                  "command": {
                    "action": "setColorScheme",
                    "colorScheme": "purplepeter"
                  },
                  "id": "User.SetSchemeToPurplepeter"
                },
                {
                  "command": {
                    "action": "setColorScheme",
                    "colorScheme": "Dracula"
                  },
                  "id": "User.SetSchemeToDracula"
                }
              ]
            }
            """;

        var actual = fragment.ToJson();

        Assert.That(actual, Is.EqualTo(expected));
    }
}
