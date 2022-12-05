using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Day_3;

namespace AdventOfCode2022.Year2022.Day_3;

public class Day3 : BaseDay
{
    private IEnumerable<string> RawData { get; set; }
    private List<RuckSackCompartments> Rucksacks;
    public int BadgeScore { get; set; }

    public Day3(IInputFileService inputFileService) : base("Day3InputData.txt", inputFileService)
    {
        this.Rucksacks = new List<RuckSackCompartments>();
    }
    
    public void GetInputData()
    {
        this.RawData = this.GetInputs();
    }

    public void ParseData()
    {
        foreach (var s in this.RawData)
        {
            this.Rucksacks.Add(this.SplitCompartments(s));
        }

        var Chunks = this.Rucksacks.Chunk(3);
        foreach (var compartmentsArray in Chunks)
        {
            var badgeItem = FindBadge(compartmentsArray.ToList());
            this.BadgeScore += (int)ConvertToDecimal(badgeItem);
        }
    }

    public RuckSackCompartments SplitCompartments(string rucksackContents)
    {
        var compartment2 = rucksackContents.Remove(0, rucksackContents.Length / 2);
        var compartment1 = rucksackContents.Remove(rucksackContents.Length / 2);
        return new RuckSackCompartments
        {
            Compartment1 = compartment1,
            Compartment2 = compartment2,
            CommonItems = compartment1.Intersect(compartment2).ToList()
        };
    }

    public int GetScoreOfCommonItems()
    {
        return this.Rucksacks.Sum(rucksack => rucksack.CommonItems.Sum(commonItem => (int)this.ConvertToDecimal(commonItem)));
    }

    public decimal ConvertToDecimal(char item)
    {
        decimal dec = item;
        if (!char.IsUpper(item))
            return dec - 96;
        
        return dec - 38;
    }

    public char FindBadge(List<RuckSackCompartments> elfGroup)
    {
        var elfs = elfGroup.Select(ruck => $"{ruck.Compartment1}{ruck.Compartment2}").ToList();
        var intersect1 = elfs[0].Intersect(elfs[1]).ToList();
        var intersect2 = elfs[0].Intersect(elfs[2]).ToList();
        var intersect3 = intersect1.Intersect(intersect2).ToList();
        return intersect3[0];
    }
}