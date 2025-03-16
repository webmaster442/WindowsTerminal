namespace Webmaster442.WindowsTerminal.Wigets;

/// <summary>
/// Progress bar display
/// </summary>
public class Progressbar : WigetBase, IProgress<int>, IProgress<double>, IProgress<float>
{
    private const int Height = 3;
    private double _progress;
    private int _top;
    private void Draw(double progress)
    {
        if (!IsShowing) return;

        Console.SetCursorPosition(0, _top);
        int barWidth = Console.WindowWidth - 2;
        int fillWidth = (int)(progress * barWidth);

        TerminalFormattedStringBuilder output = new();
        for (int i = 0; i < Height - 1; i++)
        {
            output
                .Append(' ')
                .WithForegroundColor(TerminalColor.Green)
                .Append(new string('█', fillWidth))
                .ResetFormat()
                .Append(new string(' ', barWidth - fillWidth))
                .Append(' ');
        }

        output.AppendLine($"{progress:p}".PadLeft(Console.WindowWidth / 2));

        Console.Write(output.ToString());
        WindowsTerminal.SetProgressbar(ProgressbarState.Default, (int)Math.Ceiling(progress * 100));
        OnProgressChanged();
    }

    private void Initialize()
            => _top = (Console.WindowHeight - Height) / 2;

    /// <summary>
    /// An overridable method that is called when the progress bar is updated
    /// </summary>
    protected virtual void OnProgressChanged() { }

    /// <summary>
    /// Create a new progress bar
    /// </summary>
    public Progressbar()
    {
        Initialize();
    }

    /// <summary>
    /// Hide the progress bar
    /// </summary>
    public override void OnHide()
    {
        WindowsTerminal.SetProgressbar(ProgressbarState.Hidden, 0);
        Console.Clear();
    }

    /// <summary>
    /// Show the progress bar
    /// </summary>
    public override void OnShow()
    {
        Initialize();
        Console.Clear();
        Draw(0);
    }

    /// <summary>
    /// Reports a progress update.
    /// </summary>
    /// <param name="value">The value of the updated progress.</param>
    public void Report(double value)
    {
        _progress = Math.Clamp(value, 0, 1);
        Draw(_progress);
    }

    /// <summary>
    /// Reports a progress update.
    /// </summary>
    /// <param name="value">The value of the updated progress.</param>
    public void Report(float value)
        => Report((double)value);

    /// <summary>
    /// Reports a progress update.
    /// </summary>
    /// <param name="value">The value of the updated progress.</param>
    public void Report(int value)
        => Draw(Math.Clamp(value, 0, 100) / 100.0);
}
