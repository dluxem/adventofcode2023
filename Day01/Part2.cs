using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc;

internal class Part2
{
    private static int Converter(string value)
    {
        var result = 0;
        if (value.Length >= 1) 
        {
            switch (value)
            {
                case "one": result = 1;
                    break;
                case "two": result = 2;
                    break; ;
                case "three": result = 3;
                    break;
                case "four": result = 4;
                    break;
                case "five": result = 5;
                    break;
                case "six": result = 6;
                    break;
                case "seven": result = 7;
                    break;
                case "eight": result = 8;
                    break;
                case "nine": result = 9;
                    break;

                default:
                    result = Convert.ToInt32(value);
                    break;
            }
        }
        
        //Console.WriteLine("{0} : {1}", value, result);
        return result;
    }

    public static void Run()
    {
        var inputFile = File.OpenText("input.txt");

        int sum = 0;

        while (!inputFile.EndOfStream)
        {
            var line = inputFile.ReadLine();
            var regex = new Regex(@"(?=(\d|one|two|three|four|five|six|seven|eight|nine))"); // positive look ahead :(
            var matches = regex.Matches(line);
            var int10 = Converter(matches[0].Groups[1].Value);
            var int1 = Converter(matches[matches.Count - 1].Groups[1].Value);
            sum = sum + (int10 * 10) + int1;

        }


        Console.WriteLine(sum);


    }

}

