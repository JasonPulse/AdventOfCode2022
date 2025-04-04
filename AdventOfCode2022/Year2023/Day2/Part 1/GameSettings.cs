namespace AdventOfCode2022.Year2023.Day2.Part_1;

public class GameSettings
{
    public int GameId { get; set; }
    public List<int> Blue { get; set; }
    public List<int> Red { get; set; }
    public List<int> Green { get; set; }

    public GameSettings()
    {
        Blue = new List<int>();
        Red = new List<int>();
        Green = new List<int>();
    }
    public bool GamePossible(int maxBlue = 0, int maxRed = 0, int maxGreen = 0)
    {

        if (Red.Any(i => i > maxRed))
        {
            return false;
        }

        if (Blue.Any(i => i > maxBlue))
        {
            return false;
        }

        if (Green.Any(i => i > maxGreen))
        {
            return false;
        }
        
        return true;
    }

    public int[] MinimumRequered()
    {
        int reqRed = 0;
        int reqBlue = 0;
        int reqGreen = 0;
        foreach (var i in this.Red)
        {
            if (i > reqRed)
            {
                reqRed = i;
            }
        }
        
        foreach (var i in this.Blue)
        {
            if (i > reqBlue)
            {
                reqBlue = i;
            }
        }
        
        foreach (var i in this.Green)
        {
            if (i > reqGreen)
            {
                reqGreen = i;
            }
        }

        return new[] { reqRed, reqBlue, reqGreen };
    }
}