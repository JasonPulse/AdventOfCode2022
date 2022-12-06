using AdventOfCode2022.Year2022.Day_5.Interfaces;
using AdventOfCode2022.Year2022.Day_5.Models;

namespace AdventOfCode2022.Year2022.Day_5.Services;

public class CreateStack : ICrateStack
{
    private StackSeperator _stackSeperator { get; set; }

    public CreateStack()
    {
        this._stackSeperator = new StackSeperator();
    }
    public Dictionary<int, CrateStack> CreateAStack(IEnumerable<string> stackDiagram)
    {
        var Stacks = new Dictionary<int, CrateStack>();
        foreach (var stackLine in stackDiagram)
        {
            var stackList = this._stackSeperator.SeperateStack(stackLine).ToList();
            var index = 0;
            foreach (var s in stackList)
            {
                index++;
                if (string.IsNullOrWhiteSpace(s))
                    continue;
                
                if (Stacks.ContainsKey(index))
                {
                    Stacks[index].Stack.Add(new Crate
                    {
                        Contents = s[1],
                        StackNumber = index,
                    });
                    continue;
                }

                var cs = new CrateStack
                {
                    Stack = new List<Crate>()
                };
                var c = new Crate
                {
                    Contents = s[1],
                    StackNumber = index
                };
                cs.Stack.Add(c);
                Stacks.Add(index, cs);
            }
        }

        // foreach (var value in Stacks.Values)
        // {
        //     value.Stack.Reverse();
        // }
        
        return Stacks;
    }
}