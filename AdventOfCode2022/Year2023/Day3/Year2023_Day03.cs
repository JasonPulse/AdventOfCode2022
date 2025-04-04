using System.Text.RegularExpressions;
using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Year2023.Day1;
using AdventOfCode2022.Year2023.Day2.Part_1;
using Serilog;

namespace AdventOfCode2022.Year2023.Day3;

public class Year2023_Day03 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }
    public List<GameSettings> Games { get; set; }

    public Year2023_Day03(IInputFileService inputFileService) : base("Day3InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day01_Part1>();
        this._fileService = inputFileService;
    }

    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day3/");
    }

    public List<NumberData> GetNumbers(string[] lines)
    {
        var numbers = new List<NumberData>();
        foreach (var line in lines)
        {
            var s = line.Split('.');
            foreach (var s1 in s)
            {
                var str = s1;
                if (str.Length <= 0)
                {
                    continue;
                }

                if (!Char.IsDigit(str[0]))
                {
                    str = str.Remove(0, 1);
                    if (str.Length <= 0)
                    {
                        continue;
                    }
                }

                if (!Char.IsDigit(str.Last()))
                {
                    str = str.Remove(s1.Length - 1, 1);
                }

                if (CheckDoubleNumber(lines, str, line, numbers))
                {
                    continue;
                }

                var index = line.IndexOf(str, StringComparison.Ordinal);
                var nd = new NumberData()
                {
                    Number = Convert.ToInt32(str),
                    Positions = Enumerable.Range(index - 1, str.Length + 2).ToList(),
                    LineNumber = lines.ToList().IndexOf(line)
                };
                numbers.Add(nd);
            }
        }

        return numbers;
    }

    private bool CheckDoubleNumber(string[] lines, string str, string line, List<NumberData> numbers)
    {
        foreach (var ch in str)
        {
            if (!Char.IsDigit(ch))
            {
                // checking for instances of 617*592
                var doubleNumber = str.Split(ch);
                foreach (var num in doubleNumber)
                {
                    var ind = line.IndexOf(num, StringComparison.Ordinal);
                    var n = new NumberData()
                    {
                        Number = Convert.ToInt32(num),
                        Positions = Enumerable.Range(ind - 1, num.Length + 2).ToList(),
                        LineNumber = lines.ToList().IndexOf(line)
                    };
                    numbers.Add(n);
                }

                return true;
            }
        }

        return false;
    }

    public List<int> CalculateIsAdjacent(string[] lines, List<NumberData> numbers)
    {
        List<NumberData> adjacent = new List<NumberData>();
        Dictionary<int, List<int>> Symbols = new();
        for (int i = 0; i < lines.Length; i++)
        {
            var symbols = DetectSymbol(lines[i]).ToList();
            if (symbols.Count <= 0)
            {
                continue;
            }

            Symbols.Add(i, symbols);
        }

        foreach (var sy in Symbols)
        {
            // Check 9 positions around symbol for a digit if we find it add to adjcent
            foreach (var i in sy.Value)
            {

                var numNeg = numbers.FindAll(x => x.LineNumber == sy.Key - 1 && x.Positions.Contains(i));
                foreach (var ng in numNeg.Where(ng => !adjacent.Contains(ng)))
                {
                    adjacent.Add(ng);
                }


                var num = numbers.FindAll(x => x.LineNumber == sy.Key && x.Positions.Contains(i));
                foreach (var ng in num.Where(ng => !adjacent.Contains(ng)))
                {
                    adjacent.Add(ng);
                }


                var numPos = numbers.FindAll(x => x.LineNumber == sy.Key + 1 && x.Positions.Contains(i));
                foreach (var ng in numPos.Where(ng => !adjacent.Contains(ng)))
                {
                    adjacent.Add(ng);
                }
            }
        }

        return adjacent.Select(x => x.Number).ToList();
    }

    public int[] DetectSymbol(string line)
    {
        var symbols = new List<int>();
        for (int i = 0; i < line.Length; i++)
        {
            if (!char.IsDigit(line[i]))
            {
                if (line[i] != '.')
                {
                    // Symbol location
                    symbols.Add(i);
                }
            }
        }

        return symbols.ToArray();
    }

    public class NumberData()
    {
        public int Number { get; set; }
        public List<int> Positions { get; set; }
        public int LineNumber { get; set; }
    }

    public object PartOne(string[] rows)
    {
        var symbols = Parse(rows, new Regex(@"[^.0-9]"));
        var nums = Parse(rows, new Regex(@"\d+"));

        return (
            from n in nums
            where symbols.Any(s => Adjacent(s, n))
            select n.Int
        ).Sum();
    }

    public object PartTwo(string[] rows)
    {
        var gears = Parse(rows, new Regex(@"\*"));
        var numbers = Parse(rows, new Regex(@"\d+"));

        return (
            from g in gears
            let neighbours = from n in numbers where Adjacent(n, g) select n.Int
            where neighbours.Count() == 2
            select neighbours.First() * neighbours.Last()
        ).Sum();
    }

    bool Adjacent(Part p1, Part p2) =>
        Math.Abs(p2.Irow - p1.Irow) <= 1 &&
        p1.Icol <= p2.Icol + p2.Text.Length &&
        p2.Icol <= p1.Icol + p1.Text.Length;

    Part[] Parse(string[] rows, Regex rx) => (
        from irow in Enumerable.Range(0, rows.Length)
        from match in rx.Matches(rows[irow])
        select new Part(match.Value, irow, match.Index)
    ).ToArray();

    record Part(string Text, int Irow, int Icol)
    {
        public int Int => int.Parse(Text);
    }
}