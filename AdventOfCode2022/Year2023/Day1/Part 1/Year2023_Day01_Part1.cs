using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using Serilog;

namespace AdventOfCode2022.Year2023.Day1;

public class Year2023_Day01_Part1 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }
    public Year2023_Day01_Part1(IInputFileService inputFileService) : base("Day1InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day01_Part1>();
        this._fileService = inputFileService;
    }

    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day1/");
    }

    public void CalculateTotal()
    {
        
        var data = LoadInputData();
        
        int total = 0;
        foreach (var s in data)
        {
            var num = GetNumbers(s);
            var t = Convert.ToInt32($"{num[0]}{num.Last()}");
            total += t;
        }
        
        _log.Information("Total Was {Total}", total);
    }
    
    public int[] GetNumbers(string data)
    {
        try
        {
            var numbers = new string(data.Where(char.IsDigit).ToArray());
            return numbers.ToList().Select(c => c - '0').ToArray();
        }
        catch (Exception e)
        {
            _log.Error(e, "Unable to extract numbers");
            return [];
        }
    }
}