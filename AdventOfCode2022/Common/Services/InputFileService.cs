using AdventOfCode2022.Common.Interfaces;

namespace AdventOfCode2022.Common.Services;

public class InputFileService : IInputFileService
{
    private const string BasePath = "Year2022/Inputs";

    public IEnumerable<string> GetInputs(string name, string? lineSplitter = null)
    {
        lineSplitter ??= Environment.NewLine;

        return GetInput(name)
            .Split(lineSplitter)
            .Where(i => !string.IsNullOrWhiteSpace(i));
    }

    private string GetInput(string name)
    {
        return File.ReadAllText($"{BasePath}/{name}");
    }
}