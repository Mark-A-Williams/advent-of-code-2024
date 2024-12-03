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
        var safeIncreaseCount = 0;
        var safeDecreaseCount = 0;
        var unsafeChangeCount = 0;

        for (int i = 0; i < report.Length - 1; i++)
        {
            var diff = report[i + 1] - report[i];

            if (diff > 3 || diff < -3 || diff == 0)
            {
                unsafeChangeCount++;
            }
            else if (diff > 0)
            {
                safeIncreaseCount++;
            }
            else if (diff < 0)
            {
                safeDecreaseCount++;
            }
        }

        var totalChanges = safeDecreaseCount + safeIncreaseCount + unsafeChangeCount;

        if (allowSingleUnsafeLevel)
        {
            return safeDecreaseCount >= totalChanges - 1 || safeIncreaseCount >= totalChanges - 1;
        }
        else
        {
            return safeDecreaseCount == totalChanges || safeIncreaseCount == totalChanges;
        }
    }
}
