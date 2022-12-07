using AdventOfCode2022.Year2022.Day_6.Services;
using NUnit.Framework;

namespace UnitTests.Day_6;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Sample1()
    {
        var detector = new PacketDetector();
        Assert.That(detector.StartOfPacket("mjqjpqmgbljsphdztnvjfqwrcgsmlb"), Is.EqualTo(7));
    }
    
    [Test]
    public void Sample2()
    {
        var detector = new PacketDetector();
        Assert.That(detector.StartOfPacket("bvwbjplbgvbhsrlpgdmjqwftvncz"), Is.EqualTo(5));
    }
    
    [Test]
    public void Sample3()
    {
        var detector = new PacketDetector();
        Assert.That(detector.StartOfPacket("nppdvjthqldpwncqszvftbrmjlhg"), Is.EqualTo(6));
    }
    
    [Test]
    public void Sample4()
    {
        var detector = new PacketDetector();
        Assert.That(detector.StartOfPacket("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"), Is.EqualTo(10));
    }
    
    [Test]
    public void Sample5()
    {
        var detector = new PacketDetector();
        Assert.That(detector.StartOfPacket("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"), Is.EqualTo(11));
    }
}