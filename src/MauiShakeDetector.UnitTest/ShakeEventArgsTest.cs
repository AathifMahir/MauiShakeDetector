using FluentAssertions;

namespace MauiShakeDetector.UnitTest;
public class ShakeEventArgsTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void NoOfShakesShouldBeEqualInShakeDetectedEventArgs(int noOfShakes)
    {
        var eventArgs = new ShakeDetectedEventArgs(noOfShakes);
        eventArgs.NoOfShakes.Should().Be(noOfShakes);
    }
}
