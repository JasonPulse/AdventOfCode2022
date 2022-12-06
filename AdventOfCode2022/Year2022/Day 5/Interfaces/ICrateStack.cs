using AdventOfCode2022.Year2022.Day_5.Models;
using AdventOfCode2022.Year2022.Day_5.Services;

namespace AdventOfCode2022.Year2022.Day_5.Interfaces;

public interface ICrateStack
{
   public Dictionary<int, CrateStack> CreateAStack(IEnumerable<string> stackDiagram);
}