using AdventOfCode2022.Year2022.Day_7.Models;
using File = AdventOfCode2022.Year2022.Day_7.Models.File;

namespace AdventOfCode2022.Year2022.Day_7.Interfaces;

public interface IFileTools
{
    public bool CheckFileExists(Folder folder, string fileName);

    public void CreateFile(Folder folder, string fileName, int fileSize);
    public void CreateFile(Folder folder, File file);
}