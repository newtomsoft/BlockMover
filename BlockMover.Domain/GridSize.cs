namespace BlockMover.Domain;

public record GridSize(int X, int Y)
{
    public static GridSize From(int size) => new(size, size);
    public static GridSize Null => new(0, 0);
}