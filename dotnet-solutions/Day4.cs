using System.Linq;

namespace AoC2024;

public class Day4
{
    public static int Part1()
    {
        var grid = File.ReadAllLines("../inputs/4.txt").Select(line => line.ToArray()).ToArray();
        var xmasCount = 0;

        for (var y = 0; y < grid.Length; y++)
        {
            for (var x = 0; x < grid[y].Length; x++)
            {
                if (grid[y][x] != 'X') continue;

                (int DX, int DY)[] directions = [(1, 0), (1, 1), (1, -1), (-1, 0), (-1, 1), (-1, -1), (0, 1), (0, -1)]; // eww

                foreach (var direction in directions)
                if (IsXmasInDirection(grid, (x, y), direction)) xmasCount++;
            }
        }

        return xmasCount;
    }

    public static int Part2()
    {
        var grid = File.ReadAllLines("../inputs/4.txt").Select(line => line.ToArray()).ToArray();
        var masXCount = 0;

        for (var y = 0; y < grid.Length; y++)
        {
            for (var x = 0; x < grid[y].Length; x++)
            {
                if (IsCenterOfMasX(grid, (x, y))) masXCount++;
            }
        }

        return masXCount;
    }

    // We'll only call this (for every direction) if we're on an X 
    private static bool IsXmasInDirection(
        char[][] grid,
        (int X, int Y) startCoords,
        (int DeltaX, int DeltaY) direction)
    {
        var gridWidth = grid[0].Length;
        var gridHeight = grid.Length;

        (int index, char character)[] desiredCharacters = [(1, 'M'), (2, 'A'), (3, 'S')];

        foreach (var (i, character) in desiredCharacters)
        {
            var xCoord = startCoords.X + i * direction.DeltaX;
            var yCoord = startCoords.Y + i * direction.DeltaY;

            if (xCoord < 0 || xCoord >= gridWidth || yCoord < 0 || yCoord >= gridHeight) return false;
            
            if (grid[yCoord][xCoord] != character) return false;
        }

        return true;
    }

    private static bool IsCenterOfMasX(
        char[][] grid,
        (int X, int Y) startCoords)
    {
        var gridWidth = grid[0].Length;
        var gridHeight = grid.Length;

        if (grid[startCoords.Y][startCoords.X] != 'A') return false;

        if (startCoords.X < 1 || startCoords.X >= gridWidth - 1 || startCoords.Y < 1 || startCoords.Y >= gridHeight - 1) return false;

        var topLeft = grid[startCoords.Y - 1][startCoords.X - 1];
        var topRight = grid[startCoords.Y - 1][startCoords.X + 1];
        var bottomLeft = grid[startCoords.Y + 1][startCoords.X - 1];
        var bottomRight = grid[startCoords.Y + 1][startCoords.X + 1];

        char[] positiveDiagonal = [topLeft, bottomRight];
        char[] negativeDiagonal = [topRight, bottomLeft];

        return positiveDiagonal.Count(o => o == 'S') == 1 && positiveDiagonal.Count(o => o == 'M') == 1
            && negativeDiagonal.Count(o => o == 'S') == 1 && negativeDiagonal.Count(o => o == 'M') == 1;
    }
}