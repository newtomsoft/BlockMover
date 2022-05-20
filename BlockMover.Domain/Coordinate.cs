namespace BlockMover.Domain;

public record Coordinate(int X, int Y)
{
    public static Coordinate From(int x, int y) => new(x, y);

}