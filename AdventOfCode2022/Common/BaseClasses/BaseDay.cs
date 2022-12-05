using AdventOfCode2022.Common.Interfaces;

namespace AdventOfCode2022.Common.BaseClasses;

public class BaseDay
{
    private readonly string _inputFileName;
    private readonly IInputFileService _inputFileService;
    protected readonly string? LineSplitter = Environment.NewLine;

    protected BaseDay(string inputFileName, IInputFileService inputFileService)
    {
        _inputFileName = inputFileName;
        _inputFileService = inputFileService;
    }

    protected IEnumerable<string> GetInputs(string? lineSplitter = null)
    {
        return _inputFileService.GetInputs(_inputFileName, lineSplitter);
    }
}