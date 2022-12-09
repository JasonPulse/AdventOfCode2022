namespace AdventOfCode2022.Year2022.Day_7.Models;

public class Folder
{
    public Folder? ParentFolder { get; set; }
    public List<Folder> Folders { get; set; }
    public List<File> Files { get; set; }
    public string FolderName { get; set; }
    public int FolderSize { get; set; }

    public void IncreaseFolderSize(int newFileSize)
    {
        this.FolderSize += newFileSize;
       ParentFolder?.IncreaseFolderSize(newFileSize);
    }
}