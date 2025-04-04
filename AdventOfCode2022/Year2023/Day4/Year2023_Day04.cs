using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;

using Serilog;


namespace AdventOfCode2022.Year2023.Day4;

public class Year2023_Day04 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }

    public Year2023_Day04(IInputFileService inputFileService) : base("Day4InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day04>();
        this._fileService = inputFileService;
    }
    
    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day4/");
    }

    public int CreateAndCalculateScratchers(string[] line)
    {
        List<Scratcher> scratchers = new List<Scratcher>();
        foreach (var s in line)
        {
            var split = s.Split(':');
            var cardNumber = Convert.ToInt32(split[0].Replace("Card", String.Empty));
            var winners = split[1].Split('|')[0].Split(' ').ToList();
            var cardNumbers = split[1].Split('|')[1].Split(' ').ToList();
            winners.RemoveAll(string.IsNullOrEmpty);
            cardNumbers.RemoveAll(string.IsNullOrEmpty);
            scratchers.Add(new Scratcher(cardNumber, winners.Select(x => int.Parse(x)).ToList(), cardNumbers.Select(x => int.Parse(x)).ToList()));
        }

        return scratchers.Sum(x => x.Points);
    }

    public int CreateAndCalculateNumberOfScracthers(string[] lines)
    {
        List<Scratcher> scratchers = new List<Scratcher>();
        foreach (var s in lines)
        {
            var split = s.Split(':');
            var cardNumber = Convert.ToInt32(split[0].Replace("Card", String.Empty));
            var winners = split[1].Split('|')[0].Split(' ').ToList();
            var cardNumbers = split[1].Split('|')[1].Split(' ').ToList();
            winners.RemoveAll(string.IsNullOrEmpty);
            cardNumbers.RemoveAll(string.IsNullOrEmpty);
            scratchers.Add(new Scratcher(cardNumber, winners.Select(x => int.Parse(x)).ToList(), cardNumbers.Select(x => int.Parse(x)).ToList()));
        }

        foreach (var scratcher in scratchers)
        {
            scratcher.Copies++;
            if (scratcher.WinningCount > 0)
            {

                for (int i = 1; i <= scratcher.WinningCount; i++)
                {
                    var s = scratchers.FirstOrDefault(x => x.CardNumber == scratcher.CardNumber + i);
                    if (s != null)
                    {
                        s.Copies += scratcher.Copies;
                    }
                }

            }
        }

        return scratchers.Select(x => x.Copies).Sum();
    }

    record Scratcher(int CardNumber, List<int> Winners, List<int> Numbers)
    {
        public int Points => this.GetCardPoints(Winners, Numbers);
        public int Copies { get; set; }
        public int WinningCount => Numbers.FindAll(Winners.Contains).Count;

        private int GetCardPoints(List<int> winners, List<int> numbers)
        {
            var con = numbers.FindAll(winners.Contains);
            if (con.Count == 1)
            {
                return 1;
            }
            if (con.Count > 1)
            {
                return Double(con.Count);
            }

            return 0;
        }

        private int Double(int numberOfTimes)
        {
            int x = 1;
            for (int i = 1; i < numberOfTimes; i++)
            {
                x += x;
            }

            return x;
        }
    }
}