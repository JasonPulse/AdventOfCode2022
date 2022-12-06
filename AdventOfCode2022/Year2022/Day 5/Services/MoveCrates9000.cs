using AdventOfCode2022.Year2022.Day_5.Models;

namespace AdventOfCode2022.Year2022.Day_5.Services;

public class MoveCrates9000
{
    public Dictionary<int, CrateStack> Move(Moves moveInstructions, Dictionary<int, CrateStack> stacks)
    {
        try
        {
            stacks[moveInstructions.To].Stack.Reverse();
            for (var i = 0; i < moveInstructions.Amount; i++)
            {
                stacks[moveInstructions.To].Stack.AddRange(stacks[moveInstructions.From].Stack.GetRange(0, 1));
                stacks[moveInstructions.From].Stack.RemoveRange(0, 1);
            }
            stacks[moveInstructions.To].Stack.Reverse();
            

            return stacks;
        }
        catch (Exception e)
        {

            throw;
        }
    }
}