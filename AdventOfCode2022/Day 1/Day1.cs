namespace AdventOfCode2022;

public class Day1
{
    public Dictionary<int, int> ElfsInventory { get; set; }

    public Day1()
    {
        this.ElfsInventory = new Dictionary<int, int>();
    }

    public async Task GetData()
    {
        var tmp = new FileFunctions();
        var data = await tmp.ReadFile("Day 1/InputData.txt");
        if (!string.IsNullOrEmpty(data))
        {
            this.PopulateData(data);
        }
    }

    private void PopulateData(string inputData)
    {
        int elfs = 1;
        var split = inputData.Split("\r\n\r\n").ToList();
        foreach (var s in split)
        {
            var set = s.Split("\r\n");
            var inventory = set.Sum(s1 => Convert.ToInt32(s1));
            this.ElfsInventory.Add(elfs, inventory);
            //Console.WriteLine($"Elf {elfs} has {inventory}");
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