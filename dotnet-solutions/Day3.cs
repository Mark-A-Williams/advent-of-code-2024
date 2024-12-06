using System.Text.RegularExpressions;

namespace AoC2024;

public class Day3
{
    public static int Part1()
    {
        var result = 0;
        var text = File.ReadAllText("../inputs/3.txt");
        var matches = Regex.Matches(text, @"mul\(\d+\,\d+\)");

        foreach (Match match in matches)
        {
            var ints = Regex.Matches(match.Value, @"\d+").ToArray();
            result += int.Parse(ints[0].Value) * int.Parse(ints[1].Value);
        }

        return result;
    }
}