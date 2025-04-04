using System.Linq;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day4;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using UnitTests.Year2023.Day3;

namespace UnitTests.Year2023.Day4;

public class Day4_Tests
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
        _log = Log.ForContext<Day3_Tests>();
    }

    [TestCase("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", ExpectedResult = 13)]
    public int TestExamplePart1(string input)
    {
        var day = new Year2023_Day04(new InputFileService());
        var inputLines = input.Split('\n');
        return day.CreateAndCalculateScratchers(inputLines);

    }

    [Test]
    public void TestPart1()
    {
        var day = new Year2023_Day04(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var total = day.CreateAndCalculateScratchers(inputLines);
        _log.Information("Total Was {Total}", total);
    }

    [TestCase(
        "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        ExpectedResult = 30)]
    public int TestExamplePart2(string input)
    {
        var day = new Year2023_Day04(new InputFileService());
        var inputLines = input.Split('\n');
        return day.CreateAndCalculateNumberOfScracthers(inputLines);
    }

    [Test]
    public void TestPart2()
    {
        var day = new Year2023_Day04(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var total = day.CreateAndCalculateNumberOfScracthers(inputLines);
        _log.Information("Total Was {Total}", total);
    }
}