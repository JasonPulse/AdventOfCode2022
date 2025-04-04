using System.Text.RegularExpressions;
using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using Serilog;

namespace AdventOfCode2022.Year2023.Day1.Part_2;

public class Year2023_Day01_Part2 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }
    public Year2023_Day01_Part2(IInputFileService inputFileService) : base("Day1InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day01_Part2>();
        this._fileService = inputFileService;
    }

    public int CalculateTotal(List<int[]> calibrations)
    {
        var total = 0;
        foreach (var calibration in calibrations)
        {
            total += Convert.ToInt32($"{calibration.First()}{calibration.Last()}");
        }

        return total;
    }
    
    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day1/");
    }
    
    public List<int> ExtractNumbers(string line)
    {
        var rx = @"\d|one|two|three|four|five|six|seven|eight|nine";
        var first = Regex.Match(line, rx).Value;
        var last = Regex.Match(line, rx, RegexOptions.RightToLeft).Value;
        return new List<int>() { ParseMatch(first), ParseMatch(last) };
    }
    
    int ParseMatch(string st) => st switch {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        var d => int.Parse(d)
    };
}