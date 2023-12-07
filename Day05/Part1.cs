using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc;

internal class Part1
{
    private static Dictionary<string, List<Map>> mappings = new Dictionary<string, List<Map>>();
    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");
        var seeds = new List<string>();


        //seeds
        var seedLine = inputFile.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
        var seedParts = seedLine[1].Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
        seeds.AddRange(seedParts);

        var section = "";
        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine().Trim();
            if (line == "") { continue; }
            if (line.Contains("map")) { section = line; continue; }
            ParseMap(section, line);
        }

        var mapSeedLocation = new Dictionary<long, long>();
        foreach (var seed in seeds)
        {
            mapSeedLocation.Add(Convert.ToInt64(seed), GetSeedLocation(seed));
        }

        Console.WriteLine(mapSeedLocation.Values.Min().ToString());

    }

    private static long GetSeedLocation(string seedText)
    {
        Console.WriteLine("Seed: {0}", seedText);
        long pointer = Convert.ToInt64(seedText);
        foreach (var list in mappings)
        {
            Console.WriteLine(list.Key);
            var result = list.Value.Where<Map>(m => m.SourceEnd > pointer && m.SourceStart <= pointer).SingleOrDefault();
            if (result != null)
            {
                pointer = pointer + result.DestOffset;
                Console.WriteLine(result.ToString());
            }
            Console.WriteLine("Next: {0}", pointer);
        }
        return pointer;
    }

    private static void ParseMap(string section, string inputLine)
    {
        // fertilizer-to-water map:
        // 49 53 8
        // dest src range

        // source_start, source_end, dst_offset = (dest - source)
        // where input>=source_start and input<=source_end; destination = input + dst_offset
        var parts = inputLine.Split(" ");
        var thisMap = new Map();
        thisMap.SourceStart = Convert.ToInt64(parts[1]);
        var range = Convert.ToInt64(parts[2]);
        thisMap.SourceEnd = thisMap.SourceStart + range;
        var dest = Convert.ToInt64(parts[0]);
        thisMap.DestOffset = (dest - thisMap.SourceStart);
        
        if (!mappings.ContainsKey(section))
        {
            mappings.Add(section, new List<Map> { thisMap } );   
        } else
        {
            mappings[section].Add(thisMap);
        }
     
    }

    private record Map
    {
        public long SourceStart = 0;
        public long SourceEnd = 0;
        public long DestOffset = 0;
    }
}

