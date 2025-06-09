// --------------------------------------------------------------------------
// Copyright (c) 2024-2025 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// --------------------------------------------------------------------------

using Webmaster442.WindowsTerminal.Fragments;

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
                  "backgroundImageStretchMode": "uniformToFill",
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
                    "scheme": "Dracula"
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
}
