namespace BlockMover.Domain;

public enum Direction
{
    Increase,
    Decrease,
}

public static class DirectionExtensions
{
    public static string ToDisplay(this Direction direction) =>
        direction switch
        {
            Direction.Decrease => "-",
            Direction.Increase => "+",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
}