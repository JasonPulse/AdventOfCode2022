using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;

namespace AdventOfCode2022.Year2022.Day_1;

public class Day1 : BaseDay
{
    public Dictionary<int, int> ElfsInventory { get; set; }

    public Day1(IInputFileService inputFileService) : base ("Day1InputData.txt", inputFileService)
    {
        this.ElfsInventory = new Dictionary<int, int>();
    }

    public void GetData()
    {
        var data = this.GetInputs($"{LineSplitter}{LineSplitter}");
        this.PopulateData(data);
    }

    private void PopulateData(IEnumerable<string> inputData)
    {
        var elfs = 1;
        //var split = inputData.Split("\r\n\r\n").ToList();
        foreach (var s in inputData)
        {
            var set = s.Split("\r\n");
            var inventory = set.Sum(s1 => Convert.ToInt32(s1));
            this.ElfsInventory.Add(elfs, inventory);
            elfs++;
        }
    }

    public KeyValuePair<int, int> GetElfWithMostFood()
    {
        return ElfsInventory.MaxBy(kvp => kvp.Value);
    }

    public int GetTop3ElfsFood()
    {
        var topValues = this.ElfsInventory.Values
            .OrderByDescending(x => x)
            .Take(3)
            .ToArray();
        return topValues.Sum();
    }
}