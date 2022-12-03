﻿// See https://aka.ms/new-console-template for more information


using AdventOfCode2022;
using AdventOfCode2022.Day_2;

var Day1Part1 = new Day1();
var Day2 = new Day2();

await Day1Part1.GetData();
var elf = Day1Part1.GetElfWithMostFood();
Console.WriteLine($"Elf {elf.Key} has {elf.Value}");
Console.WriteLine($"Top 3 Elfs have {Day1Part1.GetTop3ElfsFood()} Food");

await Day2.GetInputData();
Day2.ProcessInputData();
Console.WriteLine($"Our Score is {Day2.GetScore()}");
Day2.ProcessInputDataPart2();
Console.WriteLine($"Our Score for Part 2 is {Day2.GetScore()}");