using AdventOfCode2022.Year2022.Day_8.Models;

namespace AdventOfCode2022.Year2022.Day_8.Interfaces;

public interface IForestCreator
{
    public void CreateForest(int maxX, int maxY);

    public void CreateTreeLine(string data, int row, bool edge);
    public TreeData CreateTree(int x, int y, int height, bool edge);
    public ForestData GetForest();
}