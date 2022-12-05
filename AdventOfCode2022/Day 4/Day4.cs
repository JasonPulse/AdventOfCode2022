namespace AdventOfCode2022.Day_4;

public class Day4
{
    private string? RawData { get; set; }
    public int Overlap { get; set; }

    public async Task GetInputData()
    {
        var ff = new FileFunctions();
        this.RawData = await ff.ReadFile("Day 4/InputData.txt");
    }

    public void ProcessData()
    {
        var split = this.RawData.Split("\r\n");
        foreach (var s in split)
        {
            var assignments = s.Split(',');
            var elf1 = assignments[0].Split('-');
            var elf2 = assignments[1].Split('-');
            if (FullyContains(Convert.ToInt32(elf1[0]), Convert.ToInt32(elf1[1]), Convert.ToInt32(elf2[0]),
                    Convert.ToInt32(elf2[1])))
            {
                Overlap++;
                continue;
            }

            //Console.WriteLine($"{s} Failed");
        }
    }

    public bool FullyContains(int StartRange, int EndRange, int CheckStart, int CheckEnd)
    {
        if ((StartRange <= CheckStart && CheckEnd <= EndRange) ||
            (CheckStart <= StartRange && EndRange <= CheckEnd))
            return true;

        if ((StartRange <= CheckStart && EndRange >= CheckStart) ||
            (CheckStart <= StartRange && CheckEnd >= StartRange))
            return true;
        
        return false;
    }
}