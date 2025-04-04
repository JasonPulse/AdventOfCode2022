using System.Linq;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day5;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using UnitTests.Year2023.Day3;

namespace UnitTests.Year2023.Day5;

public class Day5_Tests
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

    [TestCase(
        "seeds: 79 14 55 13\n\nseed-to-soil map:\n50 98 2\n52 50 48\n\nsoil-to-fertilizer map:\n0 15 37\n37 52 2\n39 0 15\n\nfertilizer-to-water map:\n49 53 8\n0 11 42\n42 0 7\n57 7 4\n\nwater-to-light map:\n88 18 7\n18 25 70\n\nlight-to-temperature map:\n45 77 23\n81 45 19\n68 64 13\n\ntemperature-to-humidity map:\n0 69 1\n1 0 69\n\nhumidity-to-location map:\n60 56 37",
        ExpectedResult = 46)]
    public long TestExamplePart1(string input)
    {
        var day = new Year2023_Day05(new InputFileService());
        var inputLines = input.Split('\n');
        var data = day.ParseData(inputLines);
        return data.ProcessLocations();
    }
    
    [Test]
    public void TestPart1()
    {
        var day = new Year2023_Day05(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var data = day.ParseData(inputLines);
        var total = data.ProcessLocations();
        _log.Information("Total Was {Total}", total);
    }
}