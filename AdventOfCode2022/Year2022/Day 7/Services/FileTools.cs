using AdventOfCode2022.Year2022.Day_7.Interfaces;
using AdventOfCode2022.Year2022.Day_7.Models;
using File = AdventOfCode2022.Year2022.Day_7.Models.File;

namespace AdventOfCode2022.Year2022.Day_7.Services;

public class FileTools : IFileTools
{
    public bool CheckFileExists(Folder folder, string fileName)
    {
        return folder.Files.Any(x => x.FileName == fileName);
    }

    public void CreateFile(Folder folder, string fileName, int fileSize)
    {
        var file = new File
        {
            FileName = fileName,
            FileSize = fileSize
        };
        
        folder.Files.Add(file);

        folder.IncreaseFolderSize(fileSize);
    }
    
    public void CreateFile(Folder folder, File file)
    {
        folder.Files.Add(file);

        folder.IncreaseFolderSize(file.FileSize);
    }
}