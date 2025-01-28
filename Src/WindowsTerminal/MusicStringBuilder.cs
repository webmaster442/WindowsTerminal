using System.Diagnostics;
using System.Text;

namespace Webmaster442.WindowsTerminal;

/// <summary>
/// DECPS music note builder
/// </summary>
public sealed class MusicStringBuilder
{
    private readonly StringBuilder _builder;

    private static int GetNoteIntex(Note note)
    {
        return note switch
        {
            Note.C5 => 1,
            Note.CSharp5 => 2,
            Note.D5 => 3,
            Note.DSharp5 => 4,
            Note.E5 => 5,
            Note.F5 => 6,
            Note.FSharp5 => 7,
            Note.G5 => 8,
            Note.GSharp5 => 9,
            Note.A5 => 10,
            Note.ASharp5 => 11,
            Note.B5 => 12,
            Note.C6 => 13,
            Note.CSharp6 => 14,
            Note.D6 => 15,
            Note.DSharp6 => 16,
            Note.E6 => 17,
            Note.F6 => 18,
            Note.FSharp6 => 19,
            Note.G6 => 20,
            Note.GSharp6 => 21,
            Note.A6 => 22,
            Note.ASharp6 => 23,
            Note.B6 => 24,
            Note.C7 => 25,
            _ => throw new UnreachableException(),
        };
    }

    /// <summary>
    /// Number of remaining notes. DECPS supports up to 16 notes
    /// </summary>
    public int RemainingNotes { get; private set; }

    /// <summary>
    /// Creates a new music string builder
    /// </summary>
    public MusicStringBuilder()
    {
        _builder = new(4096);
        RemainingNotes = 16;
    }

    /// <summary>
    /// Resets the internal state of the music string builder
    /// </summary>
    /// <returns>A MusicStringBuilder to chain formatting</returns>
    public MusicStringBuilder New()
    {
        RemainingNotes = 16;
        _builder.Clear();
        return this;
    }

    /// <summary>
    /// Add a note to the music string
    /// </summary>
    /// <param name="volume">Note volume. Must be between 0 and 7. 0 - Silent, 7 - Lodest</param>
    /// <param name="duration">Note duration. Rounded to the nearest 1/32 seconds</param>
    /// <param name="note">Muiscal note to play</param>
    /// <exception cref="InvalidOperationException">When there are no more remaining notes</exception>
    /// <returns>A MusicStringBuilder to chain formatting</returns>
    public MusicStringBuilder AddNote(int volume, TimeSpan duration, Note note)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(volume, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(volume, 7);

        if (RemainingNotes < 0)
        {
            throw new InvalidOperationException("No more notes can be added");
        }

        int time = (int)Math.Ceiling(duration.TotalSeconds * 32);
        _builder.Append($"\e[1;{time};{GetNoteIntex(note)},~");
        RemainingNotes--;

        return this;
    }

    /// <inheritdoc/>
    public override string ToString()
        => _builder.ToString();
}