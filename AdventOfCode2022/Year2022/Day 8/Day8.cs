using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Year2022.Day_8.Interfaces;

namespace AdventOfCode2022.Year2022.Day_8;

public class Day8 : BaseDay
{
    protected IForestCreator ForestCreator { get; set; }
    protected IHeightChecker HeightChecker { get; set; }
    public Day8(IInputFileService inputFileService, IForestCreator forestCreator, IHeightChecker heightChecker) : base("Day8InputData.txt", inputFileService)
    {
        this.ForestCreator = forestCreator;
        this.HeightChecker = heightChecker;
        var data = this.GetInputs().ToList();
        this.ForestCreator.CreateForest(data[0].Length, data.Count);
        foreach (var dataLine in data)
        {
            var row = data.IndexOf(dataLine);
            this.ForestCreator.CreateTreeLine(dataLine, row, row == 0 || row == data.Count);
        }
        
    }

    public int CalculateVisible()
    {
        var visible = 0;
        var forest = this.ForestCreator.GetForest();
        for (int i = 0; i < forest.Trees.GetLength(0); i++)
        {
            for (int j = 0; j < forest.Trees.GetLength(1); j++)
            {
                if (this.HeightChecker.CheckTreeVisible(forest, j, i))
                {
                    visible++;
                }
            }
        }

        return visible;
    }
    
    public int GetScenicScore()
    {
        var score = 0;
        var forest = this.ForestCreator.GetForest();
        for (int i = 0; i < forest.Trees.GetLength(0); i++)
        {
            for (int j = 0; j < forest.Trees.GetLength(1); j++)
            {
                if (forest.Trees[i,j].ScenicScore > score)
                {
                    score = forest.Trees[i, j].ScenicScore;
                }
            }
        }

        return score;
    }
}