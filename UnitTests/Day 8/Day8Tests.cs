using System;
using System.Linq;
using AdventOfCode2022.Year2022.Day_8.Models;
using AdventOfCode2022.Year2022.Day_8.Services;
using NUnit.Framework;

namespace UnitTests.Day_8;

[TestFixture]
public class Day8Tests
{
    private string TestData { get; set; }
    
    private ForestData Forest { get; set; }
    
    [SetUp]
    public void Setup()
    {
        this.TestData = @"30373
25512
65332
33549
35390";
        Forest = new ForestData();
    }

    [Test]
    public void TestForestCreation()
    {
        ForestCreator fc = new ForestCreator();
        HeightChecker hc = new HeightChecker();
        
        fc.CreateForest(5,5);

        var list = this.TestData.Split("\r\n").ToList();
        foreach (var line in list)
        {
            fc.CreateTreeLine(line, list.IndexOf(line), list.IndexOf(line) == 0 || list.IndexOf(line) == list.Count);
        }

        Assert.That(fc.GetForest().Trees.Length > 0);
        
        Assert.That(hc.CheckTreeVisible(fc.GetForest(), 1, 1));
        
        Assert.That(CalculateVisible(fc.GetForest(), hc), Is.EqualTo(21));

        Assert.That(fc.GetForest().Trees[3, 2].ScenicScore, Is.EqualTo(8));
        Assert.That(fc.GetForest().Trees[1, 2].ScenicScore, Is.EqualTo(4));
    }

    public int CalculateVisible(ForestData forest, HeightChecker hc)
    {
        var visible = 0;
        for (int i = 0; i < forest.MaxRows; i++)
        {
            for (int j = 0; j < forest.MaxColumns; j++)
            {
                if (hc.CheckTreeVisible(forest, j, i))
                {
                    visible++;
                    continue;
                }
                Console.WriteLine($"Y{i} X{j} Not Visible");
            }
        }

        return visible;
    }
}