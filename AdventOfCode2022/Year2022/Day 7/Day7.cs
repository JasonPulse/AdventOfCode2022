using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Year2022.Day_7.Interfaces;
using AdventOfCode2022.Year2022.Day_7.Models;
using AdventOfCode2022.Year2022.Day_7.Services;

namespace AdventOfCode2022.Year2022.Day_7;

public class Day7 : BaseDay
{
    protected CreateFileSystem CreateFileSystem { get; set; }
    protected List<int> SubFolderSizes { get; set; }
    protected IFolderTools FolderTools { get; set; }
    public Day7(IInputFileService inputFileService, IFileTools fileTools, IFolderTools folderTools) : base("Day7InputData.txt", inputFileService)
    {
        this.CreateFileSystem = new CreateFileSystem(folderTools, fileTools);
        this.FolderTools = folderTools;
        foreach (var input in this.GetInputs())
        {
            this.CreateFileSystem.ReadTerminalResponses(input);
        }
    }

    public int CalculateSizesUnder(int x)
    {
        var folder = this.CreateFileSystem.GetFolder();
        var folderSize = FolderTools.CheckFoldersUnder(folder, x);

        return folderSize;
    }

    public int GetDirectorySizeSimular(int number)
    {
        this.SubFolderSizes = new List<int>();
        var folder = this.CreateFileSystem.GetFolder();
        SubFolderSizes.Add(folder.FolderSize);

        this.GetSubFolderSize(folder);

        int closest = SubFolderSizes.Aggregate((x,y) => Math.Abs(x-number) < Math.Abs(y-number) ? x : y);
        // var smallestResult = int.MaxValue;
        // var directorySize = 0;
        //
        // foreach (var i in SubFolderSizes)
        // {
        //     if (i - x < smallestResult)
        //     {
        //         smallestResult = i - x;
        //         directorySize = i;
        //     }
        // }
        
        return closest;
    }

    private void GetSubFolderSize(Folder folder)
    {
        foreach (var f in folder.Folders)
        {
            this.SubFolderSizes.Add(f.FolderSize);

            if (f.Folders.Any())
            {
                this.GetSubFolderSize(f);
            }
        }
    }

    public int GetTotalHddSize()
    {
        return this.CreateFileSystem.GetFolder().FolderSize;
    }
}