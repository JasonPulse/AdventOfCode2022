using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using Serilog;

namespace AdventOfCode2022.Year2023.Day8;

public class Year2023_Day08 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }
    
    public Year2023_Day08(IInputFileService inputFileService) : base("Day8InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day08>();
        this._fileService = inputFileService;
    }
    
    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day7/");
    }

}