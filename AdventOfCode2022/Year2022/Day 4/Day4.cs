using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;

namespace AdventOfCode2022.Year2022.Day_4;

public class Day4 : BaseDay
{
    private IEnumerable<string> RawData { get; set; }
    public int Overlap { get; set; }

    public Day4(IInputFileService inputFileService) : base("Day4InputData.txt", inputFileService)
    {
        
    }
    
    public void GetInputData()
    {
        this.RawData = this.GetInputs();
    }

    public void ProcessData()
    {
        
        foreach (var s in this.RawData)
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
        // Full Overlap
        if ((StartRange <= CheckStart && CheckEnd <= EndRange) ||
            (CheckStart <= StartRange && EndRange <= CheckEnd))
            return true;

        // Partial Overlap
        if ((StartRange <= CheckStart && EndRange >= CheckStart) ||
            (CheckStart <= StartRange && CheckEnd >= StartRange))
            return true;
        
        return false;
    }
}