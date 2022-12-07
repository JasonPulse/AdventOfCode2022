using AdventOfCode2022.Year2022.Day_6.Services;
using NUnit.Framework;

namespace UnitTests.Day_6;

public class MessageDetectorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Sample1()
    {
        var detector = new MessageDetector();
        Assert.That(detector.StartOfMessage("mjqjpqmgbljsphdztnvjfqwrcgsmlb"), Is.EqualTo(19));
    }
    
    [Test]
    public void Sample2()
    {
        var detector = new MessageDetector();
        Assert.That(detector.StartOfMessage("bvwbjplbgvbhsrlpgdmjqwftvncz"), Is.EqualTo(23));
    }
    
    [Test]
    public void Sample3()
    {
        var detector = new MessageDetector();
        Assert.That(detector.StartOfMessage("nppdvjthqldpwncqszvftbrmjlhg"), Is.EqualTo(23));
    }
    
    [Test]
    public void Sample4()
    {
        var detector = new MessageDetector();
        Assert.That(detector.StartOfMessage("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"), Is.EqualTo(29));
    }
    
    [Test]
    public void Sample5()
    {
        var detector = new MessageDetector();
        Assert.That(detector.StartOfMessage("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"), Is.EqualTo(26));
    }
}