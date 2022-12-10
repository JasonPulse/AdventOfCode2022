using System.Linq.Expressions;
using AdventOfCode2022.Year2022.Day_8.Interfaces;
using AdventOfCode2022.Year2022.Day_8.Models;

namespace AdventOfCode2022.Year2022.Day_8.Services;

public class ForestCreator : IForestCreator
{
    
    protected ForestData Forest { get; set; }

    public ForestData GetForest()
    {
        return Forest;
    }
    
    public void CreateForest(int maxX, int maxY)
    {
        this.Forest = new ForestData
        {
            Trees = new TreeData[maxY, maxX],
            MaxColumns = maxX,
            MaxRows = maxY
        };
    }

    public void CreateTreeLine(string data, int row, bool edge)
    {
        int i = 0;
        foreach (var s in data)
        {
            var he = (int)char.GetNumericValue(s); 
            Forest.Trees[row, i] = CreateTree(i, row, he, edge);
            i++;
        }
    }

    public TreeData CreateTree(int x, int y, int height, bool edge = false)
    {
        var t = new TreeData
        {
            Height = height,
            GridX = x,
            GridY = y,
            Visible = new Dictionary<VisibleDirections, bool>()
        };

        return t;
    }
    
    // public int CalculateVisible()
    // {
    //     var visible = 0;
    //     var forest = this.ForestCreator.GetForest();
    //     for (int i = 0; i < forest.MaxRows -1; i++)
    //     {
    //         for (int j = 0; j < forest.MaxColumns - 1; j++)
    //         {
    //             if (this.HeightChecker.CheckTreeVisible(forest, j, i))
    //             {
    //                 visible++;
    //             }
    //         }
    //     }
    //
    //     return visible;
}