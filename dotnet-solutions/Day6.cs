namespace AoC2024;

public class Day6
{
    public static int Part1()
    {
        var (obstructionCoords, guardStart, width, height) = ParseInput();
        HashSet<Coord> visitedLocations = [guardStart];
        MovementVector movementVector = new(0, -1); // Up = negative Y
        Coord currentLocation = guardStart;
        var hasLeftGrid = false;

        while (!hasLeftGrid)
        {
            var nextLocation = currentLocation.ApplyMovement(movementVector);
            if (obstructionCoords.Contains(nextLocation))
            {
                movementVector = movementVector.RotateRight();
                continue;
            }
            else
            {
                visitedLocations.Add(currentLocation);
                currentLocation = nextLocation;
                hasLeftGrid = currentLocation.X < 0 || currentLocation.X >= width || currentLocation.Y < 0 || currentLocation.Y >= height;
            }
        }

        return visitedLocations.Count;
    }

    public static int Part2()
    {
        return 0;
    }

    private static (List<Coord> ObstructionCoords, Coord GuardStart, int Width, int Height) ParseInput()
    {
        List<Coord> obstructions = [];
        Coord guardStart = new();

        var lines = File.ReadAllLines("../inputs/6.txt");
        for (var row = 0; row < lines.Length; row++)
        {
            var line = lines[row];
            for (var col = 0; col < line.Length; col++)
            {
                if (line[col] == '#') obstructions.Add(new(col, row));
                else if (line[col] == '^') guardStart = new(col, row);
            }
        }

        return (obstructions, guardStart, lines[0].Length, lines.Length);
    }

    // 0,0 is top left
    // X and Y increase right and down
    private readonly record struct Coord(int X, int Y)
    {
        public Coord ApplyMovement(MovementVector movementVector) => new(X + movementVector.X, Y + movementVector.Y);
    }

    private readonly record struct MovementVector(int X, int Y)
    {
        public MovementVector RotateRight()
        {
            return new(-Y, X);
        }
    }
}
