namespace RobotsBackend.Robot;

public enum Direction
{
    North,
    East,
    South,
    West
}

internal static class DirectionExt
{
    public static Direction TurnLeft(this Direction initialDirection)
    {
        return initialDirection switch
        {
            Direction.North => Direction.West,
            Direction.East => Direction.North,
            Direction.South => Direction.East,
            Direction.West => Direction.South,
            _ => throw new ArgumentOutOfRangeException(nameof(initialDirection), initialDirection, null)
        };
    }

    public static Direction TurnRight(this Direction initialDirection)
    {
        return initialDirection switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new ArgumentOutOfRangeException(nameof(initialDirection), initialDirection, null)
        };
    }

    public static Direction GetDirectionFromShortName(string directionName)
    {
        return directionName.ToLower()[0] switch
        {
            'e' => Direction.East,
            's' => Direction.South,
            'w' => Direction.West,
            'n' => Direction.North,
            _ => throw new FormatException($"Unknown given direction: {directionName}")
        };
    }
}