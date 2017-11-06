using NUnit.Framework;
using System;
using WpfStateMachineTutorial.Serialization;

namespace TestStateMachineTutorial
{
  [TestFixture]
  public class TestFrame
  {
    [Test]
    public void CreateAndDispose()
    {
      var testImage = Helper.CreateTestImageWithBackground(42);

      var displayTime = TimeSpan.FromSeconds(.5);

      Frame frame = null;
      Assert.That(
        () => { frame = new Frame(testImage, displayTime); },
        Throws.Nothing);

      Assert.That(frame.Image, Is.EqualTo(testImage));
      Assert.That(frame.DisplayTime, Is.EqualTo(displayTime));
      Assert.That(frame.IsDisposed, Is.False);

      Assert.That(() => frame.Dispose(), Throws.Nothing);
      Assert.That(frame.IsDisposed);
    }

    [Test]
    public void CreateWithNullImage()
    {
      Assert.That(() => new Frame(null, TimeSpan.FromSeconds(1)), Throws.ArgumentNullException);
    }

    [Test]
    public void CreateWithInvalidDisplayTime()
    {
      using (var testImage = Helper.CreateTestImageWithBackground(42))
      {
        Assert.That(() => new Frame(testImage, TimeSpan.FromSeconds(0)), Throws.ArgumentException);
      }
    }

    [Test]
    public void SetInvalidDisplayTime()
    {
      using (var frame = new Frame(Helper.CreateTestImageWithBackground(42), TimeSpan.FromSeconds(1)))
      {
        Assert.That(() => frame.DisplayTime = TimeSpan.FromSeconds(-1), Throws.ArgumentException);
      }
    }
  }
}
