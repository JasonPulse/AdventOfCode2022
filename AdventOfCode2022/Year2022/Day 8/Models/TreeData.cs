namespace AdventOfCode2022.Year2022.Day_8.Models;

public class TreeData
{
    public Dictionary<VisibleDirections, bool> Visible { get; set; }
    public int GridX { get; set; }
    public int GridY { get; set; }
    public int Height { get; set; }
    
    public int ScenicScore { get; set; }
}