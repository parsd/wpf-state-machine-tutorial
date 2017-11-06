using System.Drawing;
using System.Drawing.Imaging;

namespace TestStateMachineTutorial
{
  /// <summary>
  /// Helper methods use in various tests.
  /// </summary>
  public static class Helper
  {
    /// <summary>
    /// Creates an RGB image with a gray background.
    /// </summary>
    /// <param name="grayValue">The background intensity from 0..255.</param>
    /// <returns>Newly created image.</returns>
    public static Image CreateTestImageWithBackground(int grayValue)
    {
      // will throw if grayValue is out of bounds (saves additional input check)
      // -- also if we order it this way we need not doing manual clean-up 
      //    of the created image
      var background = Color.FromArgb(
          red: grayValue,
          green: grayValue,
          blue: grayValue);

      var image = new Bitmap(64, 48, PixelFormat.Format24bppRgb);

      using (var gfx = Graphics.FromImage(image))
      {
        gfx.Clear(background);
      }

      return image;
    }
  }
}
