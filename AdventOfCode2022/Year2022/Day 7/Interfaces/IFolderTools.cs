using AdventOfCode2022.Year2022.Day_7.Models;

namespace AdventOfCode2022.Year2022.Day_7.Interfaces;

public interface IFolderTools
{
    public void ListFolders(Folder folder);
    public bool CheckFolderExists(Folder folder, string folderName);

    public void CreateDirectory(Folder folder, string folderName);

    public int CalculateFolderSizes(Folder folder);

    public int CheckFoldersUnder(Folder root, int size);
}