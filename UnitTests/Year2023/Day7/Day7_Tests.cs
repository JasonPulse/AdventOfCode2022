using System.Linq;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day7;
using NUnit.Framework;
using Serilog;
using Serilog.Events;

namespace UnitTests.Year2023.Day7;

public class Day7_Tests
{
    private ILogger _log { get; set; }
    [OneTimeSetUp]
    public void Setup()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        _log = Log.ForContext<Day7_Tests>();
    }

    [TestCase("32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483", ExpectedResult = 6440)]
    public int TestExamplePart1(string input)
    {
        var day = new Year2023_Day07(new InputFileService());
        var inputLines = input.Split('\n');
        day.ProcessInput(inputLines);
        return day.GetWinnings();
    }
    
    [Test]
    public void TestPart1()
    {
        var day = new Year2023_Day07(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        day.ProcessInput(inputLines);
        var data = day.GetWinnings();
        _log.Information("Total Was {Total}", data);
    }

    [TestCase("32T3K 765\nT55J5 684\nKK677 28\nKTJJT 220\nQQQJA 483", ExpectedResult = 5905)]
    public int TestExamplePart2(string input)
    {
        var day = new Year2023_Day07(new InputFileService());
        var inputLines = input.Split('\n');
        day.ProcessInput(inputLines);
        return day.GetWinnings();
    }
}