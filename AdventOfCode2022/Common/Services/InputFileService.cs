using AdventOfCode2022.Common.Interfaces;

namespace AdventOfCode2022.Common.Services;

public class InputFileService : IInputFileService
{
    private const string BasePath = "Year2022/Inputs";

    public IEnumerable<string> GetInputs(string name, string? lineSplitter = null, string path = "")
    {
        lineSplitter ??= Environment.NewLine;

        if (string.IsNullOrEmpty(path))
        {
            return GetInput(name)
                .Split(lineSplitter)
                .Where(i => !string.IsNullOrWhiteSpace(i));
        }
        return GetInput(path, name)
            .Split(lineSplitter)
            .Where(i => !string.IsNullOrWhiteSpace(i));
    }

    private string GetInput(string name)
    {
        return File.ReadAllText($"{BasePath}/{name}");
    }

    private string GetInput(string path, string name)
    {
        return File.ReadAllText($"{path}/{name}");
    }
}