using System.Text.RegularExpressions;

namespace AoC2024;

public class Day3
{
    public static int Part1()    
        => GetMulSumForText(File.ReadAllText("../inputs/3.txt"));

    public static int Part2()
        => File.ReadAllText("../inputs/3.txt")
            .Split("do()")
            .Sum(chunk => GetMulSumForText(chunk.Split("don't").First()));

    private static int GetMulSumForText(string text)
        => Regex.Matches(text, @"mul\(\d+\,\d+\)")
            .Sum(match => {
                var ints = Regex.Matches(match.Value, @"\d+").ToArray();
                return int.Parse(ints[0].Value) * int.Parse(ints[1].Value);
            });
}