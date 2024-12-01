namespace AoC2024;

public class Day1
{
    public static int Part1()
    {
        List<int> lefts = [];
        List<int> rights = [];

        foreach (var line in File.ReadAllLines("../inputs/1.txt"))
        {
            var bits = line.Split(" ");
            lefts.Add(int.Parse(bits.First()));
            rights.Add(int.Parse(bits.Last()));
        }

        return lefts.Order()
            .Zip(rights.Order())
            .Sum(x => Math.Abs(x.First - x.Second));
    }

    public static int Part2()
    {
        List<int> lefts = [];
        List<int> rights = [];

        foreach (var line in File.ReadAllLines("../inputs/1.txt"))
        {
            var bits = line.Split(" ");
            lefts.Add(int.Parse(bits.First()));
            rights.Add(int.Parse(bits.Last()));
        }

        return lefts.Sum(l => rights.Count(r => r == l) * l);
    }
}
