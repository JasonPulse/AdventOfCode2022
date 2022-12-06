using AdventOfCode2022.Year2022.Day_5.Models;

namespace AdventOfCode2022.Year2022.Day_5.Services;

public class MoveCrates9001
{
    public Dictionary<int, CrateStack> Move(Moves moveInstructions, Dictionary<int, CrateStack> stacks)
    {
        try
        {
            stacks[moveInstructions.To].Stack.Reverse();
            var CratesToMove = stacks[moveInstructions.From].Stack.GetRange(0, moveInstructions.Amount);
            CratesToMove.Reverse();
            stacks[moveInstructions.To].Stack.AddRange(CratesToMove);
            stacks[moveInstructions.From].Stack.RemoveRange(0, moveInstructions.Amount);
            stacks[moveInstructions.To].Stack.Reverse();
            

            return stacks;
        }
        catch (Exception e)
        {

            throw;
        }
    }
}