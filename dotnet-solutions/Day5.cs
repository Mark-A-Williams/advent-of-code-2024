namespace AoC2024;

public class Day5
{
    public static int Part1()
    {
        var input = ParseInput();

        var correctlyOrderedMiddlePageNumberCount = 0;

        foreach (var pageList in input.RequiredPageLists)
        {
            var obeysAllRules = true;
            foreach (var rule in input.OrderingRules)
            {
                if (!pageList.Contains(rule.First) || !pageList.Contains(rule.Second)) continue;

                var isObeyed = pageList.IndexOf(rule.First) < pageList.IndexOf(rule.Second);
                if (!isObeyed)
                {
                    obeysAllRules = false;
                    break;
                }
            }

            if (obeysAllRules) correctlyOrderedMiddlePageNumberCount += pageList[(pageList.Count - 1) / 2];
        }

        return correctlyOrderedMiddlePageNumberCount;
    }
    
    public static int Part2()
    {
        return 0;
    }

    private static (List<(int First, int Second)> OrderingRules, List<List<int>> RequiredPageLists) ParseInput()
    {
        List<(int, int)> orderingRules = [];
        List<List<int>> requiredPageLists = [];

        var allLines = File.ReadAllLines(@"C:\Projects\advent-of-code-2024\inputs\5.txt").ToList();
        var blankLineIndex = allLines.IndexOf("");

        foreach (var line in allLines.Take(blankLineIndex))
        {
            if (string.IsNullOrWhiteSpace(line)) break;
            var rule = line.Split('|');
            orderingRules.Add((int.Parse(rule[0]), int.Parse(rule[1])));
        }

        foreach (var line in allLines.Skip(blankLineIndex + 1))
        {
            requiredPageLists.Add(line.Split(",").Select(int.Parse).ToList());
        }

        return (orderingRules, requiredPageLists);
    }
}