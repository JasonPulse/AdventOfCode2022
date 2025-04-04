using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using Serilog;

namespace AdventOfCode2022.Year2023.Day6;

public class Year2023_Day06 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }

    
    public Year2023_Day06(IInputFileService inputFileService) : base("Day6InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day06>();
        this._fileService = inputFileService;
    
    }
    
    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day6/");
    }

    public int ProcessInput(string[] data)
    {
        var time = data[0].Split(':')[1];
        var distance = data[1].Split(':')[1];
        var timeArr = time.Split(' ').ToList();
        var distArr = distance.Split(' ').ToList();
        timeArr.RemoveAll(string.IsNullOrEmpty);
        distArr.RemoveAll(string.IsNullOrEmpty);

        List<Race> Races = new List<Race>();
        
        for (int i = 0; i < timeArr.Count; i++)
        {
            Races.Add(new Race(int.Parse(timeArr[i]), int.Parse(distArr[i])));    
        }

        var m = 1;
        var valid = Races.Select(x => x.GetNumberOfValidWins()).ToList();
        foreach (var i in valid)
        {
            m *= i;
        }

        return m;
    }
    
    public int ProcessInputPart2(string[] data)
    {
        var time = data[0].Split(':')[1];
        var distance = data[1].Split(':')[1];
        var timeArr = time.Replace(" ", string.Empty);
        var distArr = distance.Replace(" ", string.Empty);

        List<Race> Races = new List<Race>();
        
        Races.Add(new Race(long.Parse(timeArr), long.Parse(distArr)));    

        var m = 1;
        var valid = Races.Select(x => x.GetNumberOfValidWins()).ToList();
        foreach (var i in valid)
        {
            m *= i;
        }

        return m;
    }

    record Race(long Time, long Distance)
    {
        public int GetNumberOfValidWins()
        {
            var validWins = 0;

            for (int i = 0; i < Time; i++)
            {
                if ((Time - i) * i - Distance > 0)
                {
                    validWins++;
                }
            }

            return validWins;
        }
    }
}