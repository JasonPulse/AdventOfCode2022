// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Common.Interfaces;
using AdventOfCode2022.Common.Services;
using AdventOfCode2022.Year2022.Day_1;
using AdventOfCode2022.Year2022.Day_2;
using AdventOfCode2022.Year2022.Day_3;
using AdventOfCode2022.Year2022.Day_4;
using AdventOfCode2022.Year2022.Day_5;
using AdventOfCode2022.Year2022.Day_6;
using AdventOfCode2022.Year2022.Day_6.Interfaces;
using AdventOfCode2022.Year2022.Day_6.Services;
using AdventOfCode2022.Year2022.Day_7;
using AdventOfCode2022.Year2022.Day_7.Interfaces;
using AdventOfCode2022.Year2022.Day_7.Services;
using AdventOfCode2022.Year2022.Day_8;
using AdventOfCode2022.Year2022.Day_8.Interfaces;
using AdventOfCode2022.Year2022.Day_8.Services;

IInputFileService inputFileService = new InputFileService();
IPacketDetector packetDetector = new PacketDetector();
IMessageDetector messageDetector = new MessageDetector();
IFolderTools folderTools = new FolderTools();
IFileTools fileTools = new FileTools();
IForestCreator forestCreator = new ForestCreator();
IHeightChecker heightChecker = new HeightChecker();

var Day1Part1 = new Day1(inputFileService);
var Day2 = new Day2(inputFileService);
var Day3 = new Day3(inputFileService);
var Day4 = new Day4(inputFileService);
var Day5 = new Day5(inputFileService);
var Day6 = new Day6(inputFileService, packetDetector, messageDetector);
var Day7 = new Day7(inputFileService, fileTools, folderTools);
var Day8 = new Day8(inputFileService, forestCreator, heightChecker);

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

Console.WriteLine($"Transmission starts at packet {Day6.CheckForPacket()}");
Console.WriteLine($"Transmission starts at packet {Day6.CheckForMessage()}");

Console.WriteLine($"Total FileSize for folder under 100000 {Day7.CalculateSizesUnder(100000)}");
Console.WriteLine($"Total FileSize for folder under 70000000 {Day7.CalculateSizesUnder(70000000)}");
var totalHddUsed = Day7.GetTotalHddSize();
Console.WriteLine($"Total FileSize for HDD {totalHddUsed}");
Console.WriteLine($"We need to free up {(totalHddUsed + 30000000) - 70000000}");
Console.WriteLine($"Smallest Directory that meets the requirments is {Day7.GetDirectorySizeSimular((totalHddUsed + 30000000) - 70000000)}");

Console.WriteLine($"There are {Day8.CalculateVisible()} trees visible from an edge");
Console.WriteLine($"The max Scenic Score is {Day8.GetScenicScore()}");