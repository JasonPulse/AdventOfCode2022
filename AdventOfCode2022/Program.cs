// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2022.Day_1;
using AdventOfCode2022.Year2022.Day_2;
using AdventOfCode2022.Year2022.Day_3;
using AdventOfCode2022.Year2022.Day_4;
using AdventOfCode2022.Year2022.Day_5;

IInputFileService inputFileService = new InputFileService();

var Day1Part1 = new Day1(inputFileService);
var Day2 = new Day2(inputFileService);
var Day3 = new Day3(inputFileService);
var Day4 = new Day4(inputFileService);
var Day5 = new Day5(inputFileService);

Day1Part1.GetData();
var elf = Day1Part1.GetElfWithMostFood();
Console.WriteLine($"Elf {elf.Key} has {elf.Value}");
Console.WriteLine($"Top 3 Elfs have {Day1Part1.GetTop3ElfsFood()} Food");

Day2.GetInputData();
Day2.ProcessInputData();
Console.WriteLine($"Our Estimated Score is {Day2.GetScore()}");
Day2.ProcessInputDataPart2();
Console.WriteLine($"Our Score for Part 2 is {Day2.GetScore()}");


Day3.GetInputData();
Day3.ParseData();
Console.WriteLine($"RuckSack Common Items Score is {Day3.GetScoreOfCommonItems()}");
Console.WriteLine($"RuckSack Badge Score is {Day3.BadgeScore}");

Day4.GetInputData();
Day4.ProcessData();
Console.WriteLine($"Workspace overlap {Day4.Overlap}");

Day5.CreateStacks();
var result = Day5.ProcessMoves();
Console.WriteLine($"Contents After Stacking 9001 {result}");