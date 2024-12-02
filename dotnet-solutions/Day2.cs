namespace AoC2024;

public class Day2
{
    public static int Part1()
        => File.ReadAllLines("../inputs/2.txt")
            .Count(line =>
            {
                var report = line.Split(" ").Select(int.Parse).ToArray();
                return IsReportSafe(report);
            });

    public static int Part2()
        => File.ReadAllLines("../inputs/2.txt")
            .Count(line =>
            {
                var report = line.Split(" ").Select(int.Parse).ToArray();
                return IsReportSafe(report, allowSingleUnsafeLevel: true);
            });

    private static bool IsReportSafe(int[] report, bool allowSingleUnsafeLevel = false)
    {
        var anyHaveIncreased = false;
        var anyHaveDecreased = false;
        var hasHadUnsafeLevel = false;

        // Think this doesn't work because if in fact it was the first level that was unsafe, we determine the wrong direction for the whole thing
        for (int i = 0; i < report.Length - 1; i++)
        {
            var diff = report[i + 1] - report[i];

            if (diff > 3 || diff < -3 || diff == 0)
            {
                if (!allowSingleUnsafeLevel || hasHadUnsafeLevel) return false;
                hasHadUnsafeLevel = true;
            }
            else if (diff > 0)
            {
                if (anyHaveDecreased)
                {
                    if (!allowSingleUnsafeLevel || hasHadUnsafeLevel) return false;
                    hasHadUnsafeLevel = true;
                }

                anyHaveIncreased = true;
            }
            else if (diff < 0)
            {
                if (anyHaveIncreased)
                {
                    if (!allowSingleUnsafeLevel || hasHadUnsafeLevel) return false;
                    hasHadUnsafeLevel = true;
                }

                anyHaveDecreased = true;
            }
        }

        return true;
    }
}
