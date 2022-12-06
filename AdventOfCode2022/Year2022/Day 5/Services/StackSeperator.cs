namespace AdventOfCode2022.Year2022.Day_5.Services;

public class StackSeperator
{
    public IEnumerable<string> SeperateStack(string stackLine)
    {
        var tmp = stackLine;
        var stack = new List<string>();
        while (tmp.Any())
        {
            var stacks = RemoveStack(tmp).ToList();
            tmp = stacks[1];
            stack.Add(stacks[0]);
        }

        return stack;
    }

    private IEnumerable<string> RemoveStack(string data)
    {
        var splitStack = new List<string>();
        var crate = data.Substring(0, 3);
        var remainder = string.Empty;
        if (data.Length > 4)
            remainder = data.Remove(0, 4);
        
        splitStack.Add(crate);
        splitStack.Add(remainder);
        return splitStack;
    }
}