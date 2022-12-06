using System.Text.RegularExpressions;
using AdventOfCode2022.Year2022.Day_5.Models;

namespace AdventOfCode2022.Year2022.Day_5.Services;

public class MovesCreator
{
    public Moves CreateMove(string movedata)
    {
        var mv = new Moves();
        var pattern = "move\\s(.*)\\sfrom\\s(.*)\\sto\\s([0-9])";

        var re = new Regex(pattern, RegexOptions.Multiline);
        var matches = re.Matches(movedata);

        foreach (Match ma in matches)
        {
            var groups = ma.Groups;
            mv.Amount = Convert.ToInt32(groups[1].Value);
            mv.From = Convert.ToInt32(groups[2].Value);
            mv.To = Convert.ToInt32(groups[3].Value);
            return mv;
        }

        return mv;
    }
}