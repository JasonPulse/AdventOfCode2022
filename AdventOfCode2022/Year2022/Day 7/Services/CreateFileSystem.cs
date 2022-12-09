using AdventOfCode2022.Year2022.Day_7.Interfaces;
using AdventOfCode2022.Year2022.Day_7.Models;
using File = AdventOfCode2022.Year2022.Day_7.Models.File;

namespace AdventOfCode2022.Year2022.Day_7.Services;

public class CreateFileSystem
{
    private bool ReadingCommandResponse { get; set; }
    private Folder Folders { get; set; }
    private string DirectryPath { get; set; }
    
    private IFolderTools _folderTools { get; set; }
    private IFileTools _fileTools { get; set; }

    public CreateFileSystem(IFolderTools folderTools, IFileTools fileTools)
    {
        this._folderTools = folderTools;
        this._fileTools = fileTools;
        this.Folders = new Folder
        {
            FolderName = "/",
            Files = new List<File>(),
            Folders = new List<Folder>(),
        };
    }

    public Folder GetFolder()
    {
        return Folders;
    }
    
    public void ReadTerminalResponses(string response)
    {
        if (response[0] == '$')
        {
            this.ReadingCommandResponse = false;
            // Command we executed
            switch (response.Substring(2,2))
            {
                case "cd":
                {
                    if (response.Substring(5) == "/")
                    {
                        // Reset to Home
                        this.DirectryPath = "/";
                        break;
                    }

                    if (response.Substring(5) == "..")
                    {
                        var lastIndex = this.DirectryPath.LastIndexOf("/");
                        var newpath = this.DirectryPath.Remove(lastIndex);
                        this.DirectryPath = newpath;
                        if (string.IsNullOrEmpty(this.DirectryPath))
                            this.DirectryPath = "/";
                        return;
                    }

                    if (this.DirectryPath.Length > 1)
                    {
                        // Add a / before the new directory
                        this.DirectryPath += "/";
                    }
                    
                    // Add to the current path /a/e ... etc
                    this.DirectryPath += response.Substring(5);
                    break;
                }

                case "ls":
                {
                    this.ReadingCommandResponse = true;
                    break;
                }
            }
            return;
        }

        if (response.Contains("dir"))
        {
            this.CheckOrCreateDirectory(response.Remove(0,4));
            return;
        }

        var split = response.Split(" ");
        var fileSize = Convert.ToInt32(split[0]);
        var fileName = split[1];

        this.CheckOrCreateFile(new File
        {
            FileName = fileName,
            FileSize = fileSize
        });
    }

    private void CheckOrCreateDirectory(string directoryName)
    {

        var CurrentFolder = GetCurrentFolder();

        if (!_folderTools.CheckFolderExists(CurrentFolder, directoryName))
        {
            _folderTools.CreateDirectory(CurrentFolder, directoryName);
        }
    }

    private void CheckOrCreateFile(File file)
    {
        var CurrentFolder = GetCurrentFolder();
        if (!_fileTools.CheckFileExists(CurrentFolder, file.FileName))
        {
            _fileTools.CreateFile(CurrentFolder, file);
        }
    }

    private Folder GetCurrentFolder()
    {
        if (this.DirectryPath == "/")
            return Folders;
        
        var path = this.DirectryPath.Split('/');
        var CurrentFolder = this.Folders;
        foreach (var s in path)
        {
            if (string.IsNullOrEmpty(s))
                continue;
            CurrentFolder = CurrentFolder.Folders.FirstOrDefault(x => x.FolderName == s);
        }

        return CurrentFolder;
    }
    
    private Folder GetParentFolder()
    {
        var ParentDirectoryPath = this.DirectryPath.Remove(this.DirectryPath.LastIndexOf("/"));
        var path = ParentDirectoryPath.Split('/');
        if (path.Count() == 1)
        {
            return this.Folders;
        }
        var CurrentFolder = this.Folders;
        foreach (var s in path)
        {
            if (string.IsNullOrEmpty(s))
                continue;
            CurrentFolder = CurrentFolder.Folders.FirstOrDefault(x => x.FolderName == s);
        }

        return CurrentFolder;
    }
}