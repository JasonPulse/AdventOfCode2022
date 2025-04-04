using AdventOfCode2022.Common.BaseClasses;
using AdventOfCode2022.Common.Interfaces;
using Serilog;

namespace AdventOfCode2022.Year2023.Day5;

public class Year2023_Day05 : BaseDay
{
    private ILogger _log { get; set; }
    private IInputFileService _fileService { get; set; }

    private List<SeedInfo> Seeds { get; set; }
    public Year2023_Day05(IInputFileService inputFileService) : base("Day5InputData.txt", inputFileService)
    {
        _log = Log.ForContext<Year2023_Day05>();
        this._fileService = inputFileService;
        Seeds = new List<SeedInfo>();
    }

    public IEnumerable<string> LoadInputData()
    {
        return GetInputs($"{LineSplitter}", "Year2023/Day5/");
    }

    public long GetMinLocation()
    {
        return this.Seeds.Select(x => x.Loc).Min();
    }
    
    // Need to gather all the ranges and then process all the seeds only keeping the lowest loc of all the processed seeds
    public RangeInfo ParseData(string[] data)
    {
        var rng = new RangeInfo()
        {
            SeedToSoil = new List<long[]>(),
            SoilToFert = new List<long[]>(),
            FertToWater = new List<long[]>(),
            WaterToLight = new List<long[]>(),
            LightToTemp = new List<long[]>(),
            TempToHumid = new List<long[]>(),
            HumidToLoc = new List<long[]>()
        };
        var parsing = CurrentlyParsing.None;
        foreach (var s in data)
        {
            if (string.IsNullOrEmpty(s))
            {
                continue;
            }

            if (s.StartsWith("seeds:"))
            {
                var spl = s.Split(':')[1].Split(' ').ToList();
                spl.Remove(string.Empty);
                rng.Seeds = spl.Select(long.Parse).ToArray();
            }

            if (s.StartsWith("seed-to-soil map:"))
            {
                parsing = CurrentlyParsing.Soil;
            }
            else if (s.StartsWith("soil-to-fertilizer map:"))
            {
                parsing = CurrentlyParsing.Fert;
            }
            else if (s.StartsWith("fertilizer-to-water map:"))
            {
                parsing = CurrentlyParsing.Water;
            }
            else if (s.StartsWith("water-to-light map:"))
            {
                parsing = CurrentlyParsing.Light;
            }
            else if (s.StartsWith("light-to-temperature map:"))
            {
                parsing = CurrentlyParsing.Temp;
            }
            else if (s.StartsWith("temperature-to-humidity map:"))
            {
                parsing = CurrentlyParsing.Humid;
            }
            else if (s.StartsWith("humidity-to-location map:"))
            {
                parsing = CurrentlyParsing.Loc;
            }
            else
            {
                switch (parsing)
                {
                    case CurrentlyParsing.Soil:
                    {
                        rng.SeedToSoil.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    case CurrentlyParsing.None:
                        break;
                    case CurrentlyParsing.Fert:
                    {
                        rng.SoilToFert.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    case CurrentlyParsing.Water:
                    {
                        rng.FertToWater.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    case CurrentlyParsing.Light:
                    {
                        rng.WaterToLight.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    case CurrentlyParsing.Temp:
                    {
                        rng.LightToTemp.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    case CurrentlyParsing.Humid:
                    {
                        rng.TempToHumid.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    case CurrentlyParsing.Loc:
                    {
                        rng.HumidToLoc.Add(s.Split(' ').Select(long.Parse).ToArray());
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        return rng;
    }
    
    // [Obsolete("Uses to much memory to actually test for solution, but does work")]
    // public void ParseData(string[] data)
    // {
    //     CurrentlyParsing parsing = CurrentlyParsing.None;
    //     foreach (var s in data)
    //     {
    //         if (string.IsNullOrEmpty(s))
    //         {
    //             continue;
    //         }
    //         if (s.StartsWith("seeds:"))
    //         {
    //             var split = s.Split(' ');
    //             for (int i = 1; i < split.Length; i = i + 2)
    //             {
    //                 for (int j = 0; j < long.Parse(split[i+1]); j++)
    //                 {
    //                     this.Seeds.Add(new SeedInfo()
    //                     {
    //                         Seed = long.Parse(split[i]) + j
    //                     });
    //                 }
    //             }
    //             // foreach (var s1 in split)
    //             // {
    //             //     if (s1 == "seeds:")
    //             //     {
    //             //         continue;
    //             //     }
    //             //     this.Seeds.Add(new SeedInfo
    //             //     {
    //             //         Seed = long.Parse(s1)
    //             //     });
    //             // }
    //             // continue;
    //         }
    //         
    //         if (s.StartsWith("seed-to-soil map:"))
    //         {
    //             parsing = CurrentlyParsing.Soil;
    //         }
    //         else if (s.StartsWith("soil-to-fertilizer map:"))
    //         {
    //             foreach (var seed in this.Seeds.Where(seed => seed.Soil == 0))
    //             {
    //                 seed.Soil = seed.Seed;
    //             }
    //             parsing = CurrentlyParsing.Fert;
    //         }
    //         else if (s.StartsWith("fertilizer-to-water map:"))
    //         {
    //             // Check all Seeds for invalid Fert values and set them to the soil value
    //             foreach (var seed in this.Seeds.Where(seed => seed.Fert == 0))
    //             {
    //                 seed.Fert = seed.Soil;
    //             }
    //
    //             parsing = CurrentlyParsing.Water;
    //         }
    //         else if (s.StartsWith("water-to-light map:"))
    //         {
    //             foreach (var seed in this.Seeds.Where(seed => seed.Water == 0))
    //             {
    //                 seed.Water = seed.Fert;
    //             }
    //             parsing = CurrentlyParsing.Light;
    //         }
    //         else if (s.StartsWith("light-to-temperature map:"))
    //         {
    //             foreach (var seed in this.Seeds.Where(seed => seed.Light == 0))
    //             {
    //                 seed.Light = seed.Water;
    //             }
    //             parsing = CurrentlyParsing.Temp;
    //         }
    //         else if (s.StartsWith("temperature-to-humidity map:"))
    //         {
    //             foreach (var seed in this.Seeds.Where(seed => seed.Temp == 0))
    //             {
    //                 seed.Temp = seed.Light;
    //             }
    //             parsing = CurrentlyParsing.Humid;
    //         }
    //         else if (s.StartsWith("humidity-to-location map:"))
    //         {
    //             foreach (var seed in this.Seeds.Where(seed => seed.Humid == 0))
    //             {
    //                 seed.Humid = seed.Temp;
    //             }
    //             parsing = CurrentlyParsing.Loc;
    //         }
    //         else
    //         {
    //             switch (parsing)
    //             {
    //                 case CurrentlyParsing.Soil:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     var source = long.Parse(split[1]);
    //                     var dest = long.Parse(split[0]);
    //                     var range = long.Parse(split[2]);
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Seed >= source + range || seedInfo.Seed < source) continue;
    //                         var seedLocation = seedInfo.Seed - source;
    //                         seedInfo.Soil = dest + seedLocation;
    //                     }
    //                     break;
    //                 }
    //                 case CurrentlyParsing.Fert:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Soil <= long.Parse(split[1]) + long.Parse(split[2]) )
    //                         {
    //                             if (seedInfo.Soil < long.Parse(split[1]))
    //                                 continue;
    //                             var seedLocation = seedInfo.Soil - long.Parse(split[1]);
    //                             seedInfo.Fert = long.Parse(split[0]) + seedLocation;
    //                         }
    //                     }
    //                     break;
    //                 }
    //                 case CurrentlyParsing.Water:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Fert < long.Parse(split[1]) + long.Parse(split[2]) )
    //                         {
    //                             if (seedInfo.Fert < long.Parse(split[1]))
    //                                 continue;
    //                             var seedLocation = seedInfo.Fert - long.Parse(split[1]);
    //                             seedInfo.Water = long.Parse(split[0]) + seedLocation;
    //                         }
    //                     }
    //                     break;
    //                 }
    //                 case CurrentlyParsing.Light:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Water < long.Parse(split[1]) + long.Parse(split[2]) )
    //                         {
    //                             if (seedInfo.Water < long.Parse(split[1]))
    //                                 continue;
    //                             var seedLocation = seedInfo.Water - long.Parse(split[1]);
    //                             seedInfo.Light = long.Parse(split[0]) + seedLocation;
    //                         }
    //                     }
    //                     break;
    //                 }
    //                 case CurrentlyParsing.Temp:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Light < long.Parse(split[1]))
    //                             continue;
    //                         if (seedInfo.Light < long.Parse(split[1]) + long.Parse(split[2]) )
    //                         {
    //                             var seedLocation = seedInfo.Light - long.Parse(split[1]);
    //                             seedInfo.Temp = long.Parse(split[0]) + seedLocation;
    //                         }
    //                     }
    //                     break;
    //                 }
    //                 case CurrentlyParsing.Humid:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Temp < long.Parse(split[1]) + long.Parse(split[2]) )
    //                         {
    //                             if (seedInfo.Temp < long.Parse(split[1]))
    //                                 continue;
    //                             var seedLocation = seedInfo.Temp - long.Parse(split[1]);
    //                             seedInfo.Humid = long.Parse(split[0]) + seedLocation;
    //                         }
    //                     }
    //                     break;
    //                 }
    //                 case CurrentlyParsing.Loc:
    //                 {
    //                     var split = s.Split(' ');
    //                     // Destination = split[0]
    //                     // Source = split[1]
    //                     // Range = split[3] Includes the first number of Destination/Source
    //                     foreach (var seedInfo in this.Seeds)
    //                     {
    //                         if (seedInfo.Humid < long.Parse(split[1]) + long.Parse(split[2]) )
    //                         {
    //                             if (seedInfo.Humid < long.Parse(split[1]))
    //                                 continue;
    //                             var seedLocation = seedInfo.Humid - long.Parse(split[1]);
    //                             seedInfo.Loc = long.Parse(split[0]) + seedLocation;
    //                         }
    //                     }
    //                     break;
    //                 }
    //             }
    //         }
    //     }
    //
    //     foreach (var seedInfo in this.Seeds.Where(seedInfo => seedInfo.Loc == 0))
    //     {
    //         seedInfo.Loc = seedInfo.Humid;
    //     }
    //
    // }

    enum CurrentlyParsing
    {
        None,
        Soil,
        Fert,
        Water,
        Light,
        Temp,
        Humid,
        Loc
    }

    internal class SeedInfo()
    {
        public long Seed { get; set; }
        public long Soil { get; set; }
        public long Fert { get; set; }
        public long Water { get; set; }
        public long Light { get; set; }
        public long Temp { get; set; }
        public long Humid { get; set; }
        public long Loc { get; set; }
    }

    public class RangeInfo()
    {
        public long[] Seeds { get; set; }
        public List<long[]> SeedToSoil { get; set; }
        public List<long[]> SoilToFert { get; set; }
        public List<long[]> FertToWater { get; set; }
        public List<long[]> WaterToLight { get; set; }
        public List<long[]> LightToTemp { get; set; }
        public List<long[]> TempToHumid { get; set; }
        public List<long[]> HumidToLoc { get; set; }
        
        internal long LowestLocation { get; set; }

        public long ProcessLocations()
        {
            LowestLocation = long.MaxValue;
            for (int i = 0; i < Seeds.Length; i += 2)
            {
                Parallel.For(0, Seeds[i + 1], j =>
                {
                    var seed = Seeds[i] + j;
                    var soil = (long)0;
                    var fert = (long)0;
                    var water = (long)0;
                    var light = (long)0;
                    var temp = (long)0;
                    var humid = (long)0;
                    var loc = (long)0;
                    foreach (var ss in SeedToSoil)
                    {
                        var dest = ss[0];
                        var source = ss[1];
                        var range = ss[2];

                        soil = CalculateLocation(dest, source, range, seed);
                        if (soil > 0)
                            break;
                    }

                    if (soil == 0)
                        soil = seed;

                    foreach (var sf in SoilToFert)
                    {
                        var dest = sf[0];
                        var source = sf[1];
                        var range = sf[2];

                        fert = CalculateLocation(dest, source, range, soil);
                        if (fert > 0)
                            break;
                    }

                    if (fert == 0)
                        fert = soil;

                    foreach (var fw in FertToWater)
                    {
                        var dest = fw[0];
                        var source = fw[1];
                        var range = fw[2];

                        water = CalculateLocation(dest, source, range, fert);
                        if (water > 0)
                            break;
                    }

                    if (water == 0)
                        water = fert;

                    foreach (var wl in WaterToLight)
                    {
                        var dest = wl[0];
                        var source = wl[1];
                        var range = wl[2];

                        light = CalculateLocation(dest, source, range, water);
                        if (light > 0)
                            break;
                    }

                    if (light == 0)
                        light = water;

                    foreach (var lt in LightToTemp)
                    {
                        var dest = lt[0];
                        var source = lt[1];
                        var range = lt[2];

                        temp = CalculateLocation(dest, source, range, light);
                        if (temp > 0)
                            break;
                    }

                    if (temp == 0)
                        temp = light;

                    foreach (var th in TempToHumid)
                    {
                        var dest = th[0];
                        var source = th[1];
                        var range = th[2];

                        humid = CalculateLocation(dest, source, range, temp);
                        if (humid > 0)
                            break;
                    }

                    if (humid == 0)
                        humid = temp;

                    foreach (var hl in HumidToLoc)
                    {
                        var dest = hl[0];
                        var source = hl[1];
                        var range = hl[2];

                        loc = CalculateLocation(dest, source, range, humid);
                        if (loc > 0)
                            break;
                    }

                    if (loc == 0)
                        loc = humid;


                    if (loc < LowestLocation)
                        LowestLocation = loc;
                });
            }

            return LowestLocation;
        }

        private long CalculateLocation(long dest, long source, long range, long item)
        {
            
            if (item >= source && item <= source + range)
            {
                var seedLocation = item - source;
                return dest + seedLocation;
            }

            return 0;
        }
    }
}