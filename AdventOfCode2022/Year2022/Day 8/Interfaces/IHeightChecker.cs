using AdventOfCode2022.Year2022.Day_8.Models;

namespace AdventOfCode2022.Year2022.Day_8.Interfaces;

public interface IHeightChecker
{
    public bool CheckTreeVisible(ForestData forest, int treeX, int treeY);
}