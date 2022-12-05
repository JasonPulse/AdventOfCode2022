// See https://aka.ms/new-console-template for more information


using AdventOfCode2022;
using AdventOfCode2022.Day_2;
using AdventOfCode2022.Day_3;
using AdventOfCode2022.Day_4;

var Day1Part1 = new Day1();
var Day2 = new Day2();
var Day3 = new Day3();
var Day4 = new Day4();

await Day1Part1.GetData();
var elf = Day1Part1.GetElfWithMostFood();
Console.WriteLine($"Elf {elf.Key} has {elf.Value}");
Console.WriteLine($"Top 3 Elfs have {Day1Part1.GetTop3ElfsFood()} Food");

await Day2.GetInputData();
Day2.ProcessInputData();
Console.WriteLine($"Our Estimated Score is {Day2.GetScore()}");
Day2.ProcessInputDataPart2();
Console.WriteLine($"Our Score for Part 2 is {Day2.GetScore()}");


await Day3.GetInputData();
Day3.ParseData();
Console.WriteLine($"RuckSack Common Items Score is {Day3.GetScoreOfCommonItems()}");
Console.WriteLine($"RuckSack Badge Score is {Day3.BadgeScore}");

await Day4.GetInputData();
Day4.ProcessData();
Console.WriteLine($"Workspace overlap {Day4.Overlap}");