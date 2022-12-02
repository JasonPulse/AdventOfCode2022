// See https://aka.ms/new-console-template for more information


using AdventOfCode2022;

var Day1Part1 = new Day1();

await Day1Part1.GetData();
var elf = Day1Part1.GetElfWithMostFood();
Console.WriteLine($"Elf {elf.Key} has {elf.Value}");
Console.WriteLine($"Top 3 Elfs have {Day1Part1.GetTop3ElfsFood()} Food");