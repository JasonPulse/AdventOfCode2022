using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Year2023.Day1;
using Serilog;

namespace AdventOfCode2022.Year2023.Day2.Part_1;

public class Year2023_Day02_Part1: BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }
    public List<GameSettings> Games { get; set; }
    public Year2023_Day02_Part1(IInputFileService inputFileService) : base("Day2InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day01_Part1>();
        this._fileService = inputFileService;
    }

    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day2/");
    }

    public void CreateGames(string input = "")
    {
        List<string> data;
        data = string.IsNullOrEmpty(input) ? LoadInputData().ToList() : input.Split(LineSplitter).ToList();
        
        var games = new List<GameSettings>();
        foreach (var s in data)
        {
            var game = new GameSettings();
            var gm = Convert.ToInt32(s.Split(':')[0].Replace("Game", ""));
            var gamesdata = s.Split(':')[1].Split(';');
            foreach (var gdata in gamesdata)
            {
                var singleData = gdata.Split(',');
                foreach (var s1 in singleData)
                {
                    if (s1.Contains("red"))
                    {
                        game.Red.Add(Convert.ToInt32(s1.Replace("red", string.Empty)));
                        continue;
                    }

                    if (s1.Contains("blue"))
                    {
                        game.Blue.Add(Convert.ToInt32(s1.Replace("blue", string.Empty)));
                        continue;
                    }

                    if (s1.Contains("green"))
                    {
                        game.Green.Add(Convert.ToInt32(s1.Replace("green", string.Empty)));
                    }
                }
            }
            game.GameId = gm;
            games.Add(game);
        }

        this.Games = games;
    }

}