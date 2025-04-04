using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2023.Day2.Part_1;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using UnitTests.Year2023.Day1;

namespace UnitTests.Year2023.Day2;

public class Day2_Tests
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
        _log = Log.ForContext<Day2_Tests>();
        
    }

    [TestCase(12, 14, 13, ExpectedResult = 8)]
    public int CheckExamplePart1(int maxRed, int maxBlue, int maxGreen)
    {
        var day = new Year2023_Day02_Part1(new InputFileService());
        day.CreateGames("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
        int total = 0;
        foreach (var game in day.Games)
        {
            if (game.GamePossible(maxBlue, maxRed, maxGreen))
            {
                total += game.GameId;
            }
        }

        return total;
    }
    
    [Test]
    public void TestPart1()
    {
        var day = new Year2023_Day02_Part1(new InputFileService());
        day.CreateGames();
        
        int total = 0;
        foreach (var game in day.Games)
        {
            if (game.GamePossible(14, 12, 13))
            {
                total += game.GameId;
            }
        }
        
        _log.Information("Total Was {Total}", total);
    }
    
    [TestCase(ExpectedResult = 2286)]
    public int CheckExamplePart2()
    {
        var day = new Year2023_Day02_Part1(new InputFileService());
        day.CreateGames("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green");
        int total = 0;
        foreach (var game in day.Games)
        {
            var max = game.MinimumRequered();
            total += max[0] * max[1] * max[2];
        }

        return total;
    }
    
    [Test]
    public void TestPart2()
    {
        var day = new Year2023_Day02_Part1(new InputFileService());
        day.CreateGames();
        
        int total = 0;
        foreach (var game in day.Games)
        {
            var max = game.MinimumRequered();
            total += max[0] * max[1] * max[2];
        }
        
        _log.Information("Total Was {Total}", total);
    }
}