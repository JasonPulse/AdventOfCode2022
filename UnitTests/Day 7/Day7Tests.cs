using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2022.Year2022.Day_7.Models;
using AdventOfCode2022.Year2022.Day_7.Services;
using NUnit.Framework;

namespace UnitTests.Day_7;

[TestFixture]
public class Day7Tests
{
    private List<string> RawData { get; set; }
    
    private Folder Hdd { get; set; }

    [SetUp]
    public void Setup()
    {
        this.RawData = new List<string>();
        var input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

        this.RawData = input.Split(Environment.NewLine).ToList();
    }

    [Test]
    public void CreateFileSystemTest()
    {
        var filetools = new FileTools();
        var foldertools = new FolderTools();
        var cf = new CreateFileSystem(foldertools, filetools);
        foreach (var s in RawData)
        {
            cf.ReadTerminalResponses(s);
        }

        this.Hdd = cf.GetFolder();
        Assert.That(this.Hdd != null);
        
        Assert.That(this.Hdd.Folders[0].Folders[0].FolderSize, Is.EqualTo(584));
        
        Assert.That(this.Hdd.Folders[0].FolderSize, Is.EqualTo(94853));
        Assert.That(this.Hdd.Folders[1].FolderSize, Is.EqualTo(24933642));
        Assert.That(this.Hdd.FolderSize, Is.EqualTo(48381165));

        foreach (var f in this.Hdd.Folders)
        {
            if (f.FolderSize < 100000)
            {
                // var folderSizes = f.FolderSize;
                // foreach (var ff in f.Folders)
                // {
                //     folderSizes += ff.FolderSize;
                // }
                Console.WriteLine(foldertools.CalculateFolderSizes(f));
            }
        }
    }

}