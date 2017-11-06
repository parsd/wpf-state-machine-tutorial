using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace WpfStateMachineTutorial.Serialization
{
  /// <summary>
  /// A single frame in an animation sequence.
  /// </summary>
  public class Frame : IDisposable
  {
    public Frame(Image image, TimeSpan displayTime)
    {
      Image = image ?? throw new ArgumentNullException(nameof(image));
      DisplayTime = displayTime;
    }

    #region Finalizer/IDisposable

    /// <summary>
    /// Finalizer.
    /// </summary>
    ~Frame()
    {
      Dispose(disposing: false);
    }

    /// <summary>
    /// Disposes of this object and the owned <see cref="Image"/>.
    /// </summary>
    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose implementation.
    /// </summary>
    /// <param name="disposing"><b>true</b> if called by <see cref="Dispose()"/>
    /// method; <b>false</b> if called from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
      if (!IsDisposed && disposing)
      {
        Image.Dispose();
      }
    }

    /// <summary>
    /// Gets whether this object has been disposed.
    /// </summary>
    // To detect redundant calls
    public bool IsDisposed => Image?.PixelFormat == PixelFormat.DontCare; // to detect disposed images

    #endregion

    /// <summary>
    /// Gets the image of this frame.
    /// </summary>
    public Image Image { get; private set; }

    /// <summary>
    /// Gets or sets the time this frame is displayed.
    /// </summary>
    public TimeSpan DisplayTime
    {
      get => _displayTime;
      set
      {
        if (value.TotalMilliseconds <= 0)
          throw new ArgumentException("Display time must be greater than 0s");

        _displayTime = value;
      }
    }
    private TimeSpan _displayTime;
  }
}
