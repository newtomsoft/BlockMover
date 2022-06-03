namespace BlockMover.Domain;

public record Block(int Length, Orientation Orientation, Coordinate MinCoordinate)
{
    public Coordinate MinCoordinate { get; private set; } = MinCoordinate;
    public Coordinate MaxCoordinate => Orientation == Orientation.Horizontal ? Coordinate.From(MinCoordinate.X + Length - 1, MinCoordinate.Y) : Coordinate.From(MinCoordinate.X, MinCoordinate.Y + Length - 1);

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Decrease: Decrease(); break;
            case Direction.Increase: Increase(); break;
            default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public bool HasCoordinate(Coordinate coordinate) => AllCoordinates().Contains(coordinate);

    private void Increase() =>
        MinCoordinate = Orientation switch
        {
            Orientation.Horizontal => MinCoordinate with { X = MinCoordinate.X + 1 },
            Orientation.Vertical => MinCoordinate with { Y = MinCoordinate.Y + 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

    private void Decrease() =>
        MinCoordinate = Orientation switch
        {
            Orientation.Horizontal => MinCoordinate with { X = MinCoordinate.X - 1 },
            Orientation.Vertical => MinCoordinate with { Y = MinCoordinate.Y - 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

    private List<Coordinate> AllCoordinates()
    {
        var coordinates = new List<Coordinate>();
        for (var i = 0; i < Length; i++)
        {
            var newX = Orientation == Orientation.Vertical ? MinCoordinate.X : MinCoordinate.X + i;
            var newY = Orientation == Orientation.Horizontal ? MinCoordinate.Y : MinCoordinate.Y + i;
            var newCoordinates = Coordinate.From(newX, newY);
            coordinates.Add(newCoordinates);
        }

        return coordinates;
    }
}