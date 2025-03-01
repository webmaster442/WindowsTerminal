namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Progress bar display
/// </summary>
public class Progressbar : IProgress<int>, IProgress<double>, IProgress<float>
{
    private double _progress;
    private int _top;
    private bool _isShown;
    private const int Height = 3;

    /// <summary>
    /// An overridable method that is called when the progress bar is shown
    /// </summary>
    protected virtual void OnShown() { }

    /// <summary>
    /// An overridable method that is called when the progress bar is hidden
    /// </summary>
    protected virtual void OnHidden() { }

    /// <summary>
    /// An overridable method that is called when the progress bar is updated
    /// </summary>
    protected virtual void OnProgressChanged() { }

    private void Initialize()
        => _top = (Console.WindowHeight - Height) / 2;

    private void Draw(double progress)
    {
        if (!_isShown) Show();

        Console.SetCursorPosition(0, _top);
        int barWidth = Console.WindowWidth - 2;
        int fillWidth = (int)(progress * barWidth);

        TerminalFormattedStringBuilder output = new();
        for (int i = 0; i < (Height-1); i++)
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
    public void Hide()
    {
        _isShown = false;
        WindowsTerminal.SwitchToMainBuffer();
        WindowsTerminal.SetProgressbar(ProgressbarState.Hidden, 0);
        OnHidden();
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

    /// <summary>
    /// Show the progress bar
    /// </summary>
    public void Show()
    {
        WindowsTerminal.SwitchToAlternateBuffer();
        Initialize();
        Console.Clear();
        _isShown = true;
        Draw(0);
        OnShown();
    }
}
