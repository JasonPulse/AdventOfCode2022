using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day1;
using AdventOfCode2022.Year2023.Day1.Part_2;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace UnitTests.Year2023.Day1;

[TestFixture]
public class Day1_Tests
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
        _log = Log.ForContext<Day1_Tests>();
        
    }
    [TestCase( "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet", ExpectedResult = 142)]
    public int CheckExampleCodePart1(params string[] input)
    {
        var day = new Year2023_Day01_Part1(new InputFileService());

        int total = 0;
        foreach (var s in input)
        {
            var num = day.GetNumbers(s);
            var t = Convert.ToInt32($"{num[0]}{num.Last()}");
            total += t;
        }

        return total;

    }

    [Test]
    public void TestPart1()
    {
        var day = new Year2023_Day01_Part1(new InputFileService());
        var data = day.LoadInputData();
        
        int total = 0;
        foreach (var s in data)
        {
            var num = day.GetNumbers(s);
            //_log.Information("Numbers are {Num}", num);
            var t = Convert.ToInt32($"{num[0]}{num.Last()}");
            total += t;
        }
        
        _log.Information("Total Was {Total}", total);
    }
    
    [TestCase( "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen", ExpectedResult = 281)]
    public int CheckExampleCodePart2(params string[] input)
    {
        var day = new Year2023_Day01_Part2(new InputFileService());
        var data = new List<int[]>();

        foreach (var s in input)
        {
            data.Add(day.ExtractNumbers(s).ToArray());
        }

        var total = day.CalculateTotal(data);

        return total;

    }

    [Test]
    public void TestPart2()
    {
        var day = new Year2023_Day01_Part2(new InputFileService());
        var data = new List<int[]>();
        var input = day.LoadInputData();

        foreach (var s in input)
        {
            data.Add(day.ExtractNumbers(s).ToArray());
        }

        var total = day.CalculateTotal(data);
        _log.Information("Total Was {Total}", total);
    }
    
}