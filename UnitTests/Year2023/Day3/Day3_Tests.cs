using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day3;
using NUnit.Framework;
using Serilog;
using Serilog.Events;

namespace UnitTests.Year2023.Day3;

public class Day3_Tests
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

    [TestCase("467..114..\n...*......\n..35..633.\n......#...\n617*592...\n.....+.58.\n..........\n......755.\n...$.*....\n.664.598..", ExpectedResult = 4361)]
    public int TestExamplePart1(string input)
    {
        
        var day = new Year2023_Day03(new InputFileService());
        var inputLines = input.Split('\n');
        var adjacent = day.CalculateIsAdjacent(inputLines, day.GetNumbers(inputLines.ToArray()));
        return adjacent.Sum();
    }
    
    [TestCase(ExpectedResult = 550934)]
    public int TestPart1()
    {
        var day = new Year2023_Day03(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var adjacent = day.CalculateIsAdjacent(inputLines, day.GetNumbers(inputLines.ToArray()));

        var total = adjacent.Sum();
        
        _log.Information("Total Was {Total}", total);
        return total;
    }

    [Test]
    public void TestOtherSolution()
    {
        var day = new Year2023_Day03(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var res = day.PartOne(inputLines);
        _log.Information("Response was {Res}", res);
    }
    
    [Test]
    public void TestOtherSolutionPart2()
    {
        var day = new Year2023_Day03(new InputFileService());
        var inputLines = day.LoadInputData().ToArray();
        var res = day.PartTwo(inputLines);
        _log.Information("Response was {Res}", res);
    }
}