using AdventOfCode2022.Year2022.Day_8.Interfaces;
using AdventOfCode2022.Year2022.Day_8.Models;

namespace AdventOfCode2022.Year2022.Day_8.Services;

public class HeightChecker: IHeightChecker
{
    public bool CheckTreeVisible(ForestData forest, int treeX, int treeY)
    {
        try
        {
            if (treeY == 0)
                return true;
            if (treeX == 0)
                return true;
            if (forest.Trees.GetLength(0) - 1 == treeX)
                return true;
            if (forest.Trees.GetLength(1) - 1 == treeY)
                return true;
        
            var tree = forest.Trees[treeY, treeX];

            if (tree.Visible.Count() == 4)
                return tree.Visible.Any(x => x.Value);

            var upVis = new List<bool>();
            var dnVis = new List<bool>();
            var ltVis = new List<bool>();
            var rtVis = new List<bool>();
            for (int i = treeY - 1; i >= 0; i--)
            {
                // Above Tree
                if (forest.Trees[i, treeX].Height < tree.Height)
                {
                    upVis.Add(true);
                    continue;
                }

                upVis.Add(false);
            }

            tree.Visible.Add(VisibleDirections.Up, upVis.All(x => x));

            for (int i = treeY + 1; i < forest.Trees.GetLength(0); i++)
            {
                // Below Tree
                if (forest.Trees[i, treeX].Height < tree.Height)
                {
                    dnVis.Add(true);
                    continue;
                }

                dnVis.Add(false);
            }
            tree.Visible.Add(VisibleDirections.Down, dnVis.All(x => x));

            for (int i = treeX - 1; i >= 0; i--)
            {
                // Left Tree
                if (forest.Trees[treeY, i].Height < tree.Height)
                {
                    ltVis.Add(true);
                    continue;
                }

                ltVis.Add(false);
            }
            tree.Visible.Add(VisibleDirections.Left, ltVis.All(x => x));

            for (int i = treeX + 1; i < forest.Trees.GetLength(1); i++)
            {
                // Right Tree
                if (forest.Trees[treeY, i].Height < tree.Height)
                {
                    rtVis.Add(true);
                    continue;
                }

                rtVis.Add(false);
            }
            tree.Visible.Add(VisibleDirections.Right, rtVis.All(x => x));

            var scenicUp = this.CalculateScenic(upVis);
            var scenicDn = this.CalculateScenic(dnVis);
            var scenicrt = this.CalculateScenic(rtVis);
            var sceniclt = this.CalculateScenic(ltVis);

            tree.ScenicScore = scenicUp * sceniclt * scenicDn * scenicrt;
            
            return tree.Visible.Any(x => x.Value);

        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Checking trees X{treeX}, Y{treeY}");
            throw;
        }
    }

    private int CalculateScenic(List<bool> direction)
    {
        if (direction.Contains(false))
            return direction.IndexOf(false) + 1;

        return direction.Count();
    }
}