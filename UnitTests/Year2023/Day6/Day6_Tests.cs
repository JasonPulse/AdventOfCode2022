using System.Linq;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day6;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using UnitTests.Year2023.Day3;

namespace UnitTests.Year2023.Day6;

public class Day6_Tests
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
        _log = Log.ForContext<Day6_Tests>();
    }

    [TestCase("Time:      7  15   30\nDistance:  9  40  200", ExpectedResult = 288)]
    public int TestPart1Example(string input)
    {
        var day = new Year2023_Day06(new InputFileService());
        var inputLines = input.Split('\n');
        return day.ProcessInput(inputLines);
    }
    
    [Test]
    public void TestPart1()
    {
        var day = new Year2023_Day06(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var data = day.ProcessInput(inputLines);
        _log.Information("Total Was {Total}", data);
    }
    
    [TestCase("Time:      7  15   30\nDistance:  9  40  200", ExpectedResult = 71503)]
    public int TestPart2Example(string input)
    {
        var day = new Year2023_Day06(new InputFileService());
        var inputLines = input.Split('\n');
        return day.ProcessInputPart2(inputLines);
    }
    
    [Test]
    public void TestPart2()
    {
        var day = new Year2023_Day06(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var data = day.ProcessInputPart2(inputLines);
        _log.Information("Total Was {Total}", data);
    }
}