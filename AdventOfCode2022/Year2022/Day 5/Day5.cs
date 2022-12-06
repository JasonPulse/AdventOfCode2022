using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Year2022.Day_5.Interfaces;
using AdventOfCode2022.Year2022.Day_5.Models;
using AdventOfCode2022.Year2022.Day_5.Services;

namespace AdventOfCode2022.Year2022.Day_5;

public class Day5 : BaseDay
{
    private IEnumerable<string> Data { get; set; }
    private List<Moves> MovesList { get; set; }

    private Dictionary<int, CrateStack> CrateStacks { get; set; }
    public Day5(IInputFileService inputFileService) : base("Day5InputData.txt", inputFileService)
    {
        this.CrateStacks = new Dictionary<int, CrateStack>();
        this.MovesList = new List<Moves>();
        this.Data = this.GetInputs();
    }

    public void CreateStacks()
    {
        ICrateStack StackService = new CreateStack();
        var moveCreateor = new MovesCreator();
        var StackDiagram = new List<string>();
        foreach (var d in Data)
        {
            if (string.IsNullOrWhiteSpace(d))
                continue;
            if (!d.Contains('[') && !d.Contains("move"))
                continue;
            
            if (!d.Contains("move"))
            {
                StackDiagram.Add(d);
                continue;
            }

            MovesList.Add(moveCreateor.CreateMove(d));
        }

        this.CrateStacks = StackService.CreateAStack(StackDiagram);
    }

    public string ProcessMoves()
    {
        var crain = new MoveCrates9001();
        var updatedStack = CrateStacks;
        foreach (var move in MovesList)
        {
            updatedStack = crain.Move(move, CrateStacks);
        }

        var endContents = string.Empty;
        foreach (var stackValue in updatedStack.OrderBy(z => z.Key))
        {
            endContents += stackValue.Value.Stack[0].Contents;
        }

        return endContents;
    }
    
    
}