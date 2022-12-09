using AdventOfCode2022.Year2022.Day_7.Interfaces;
using AdventOfCode2022.Year2022.Day_7.Models;
using File = AdventOfCode2022.Year2022.Day_7.Models.File;

namespace AdventOfCode2022.Year2022.Day_7.Services;

public class FolderTools: IFolderTools
{
    private string indent { get; set; }

    public FolderTools()
    {
        this.indent = string.Empty;
    }
    public void ListFolders(Folder folder)
    {
        foreach (var f in folder.Folders)
        {
            Console.WriteLine($"{indent}{f.FolderName}");
            if (f.Folders.Any())
            {
                indent += "-";
                this.ListFolders(f);
            }

            if (indent.Length > 1)
                indent = indent.Substring(0, indent.Length - 1);
        }
    }

    public bool CheckFolderExists(Folder folder, string folderName)
    {
        var finder = folder.Folders.FirstOrDefault(x => x.FolderName == folderName); 
        return finder != null;
    }

    public void CreateDirectory(Folder folder, string folderName)
    {
        folder.Folders.Add(new Folder
        {
            Files = new List<File>(),
            Folders = new List<Folder>(),
            FolderName = folderName,
            ParentFolder = folder
        });
    }

    public int CalculateFolderSizes(Folder folder)
    {
        var folderSizes = folder.FolderSize;
        foreach (var ff in folder.Folders)
        {
            folderSizes += ff.FolderSize;
        }

        return folderSizes;
    }

    public int CheckFoldersUnder(Folder root, int size)
    {
        var folderSize = 0;
        if (root.FolderSize < size)
            folderSize += root.FolderSize;
        foreach (var f in root.Folders)
        {
            folderSize += this.CheckFoldersUnder(f, size);
        }

        return folderSize;
    }
}