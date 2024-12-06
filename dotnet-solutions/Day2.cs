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
                return IsReportSafe(report) || IsReportSafeIfLevelSkipped(report);
            });

    private static bool IsReportSafeIfLevelSkipped(int[] report)
    {
        for (int i = 0; i < report.Length; i++)
        {
            if (IsReportSafe(report.Where((o, index) => index != i).ToArray())) return true;
        }

        return false;
    }

    private static bool IsReportSafe(int[] report)
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
        return safeDecreaseCount == totalChanges || safeIncreaseCount == totalChanges;
    }
}
