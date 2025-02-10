namespace Webmaster442.WindowsTerminal;

/// <summary>
/// Controls image sizing mode
/// </summary>
public enum SizeMode
{
    /// <summary>
    /// No resize is performed
    /// </summary>
    None,
    /// <summary>
    /// Downsize to the minimum size that fits into the maximum size by keeping aspect ratio
    /// </summary>
    Fit,
    /// <summary>
    /// Downsize to fit with of the maximum size by keeping aspect ratio
    /// </summary>
    FitWidth,
    /// <summary>
    /// Downsize to fit height of the maximum size by keeping aspect ratio
    /// </summary>
    FitHeight,
    /// <summary>
    /// Manual size mode. Image is resized to the specified maximum size.
    /// </summary>
    Manual,
}
