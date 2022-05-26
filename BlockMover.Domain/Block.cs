namespace BlockMover.Domain;

public record Block(int Length, Orientation Orientation, Coordinate Coordinate)
{
    public Coordinate Coordinate { get; private set; } = Coordinate;
    public Coordinate MaxCoordinate => Orientation == Orientation.Horizontal ? Coordinate.From(Coordinate.X + Length - 1, Coordinate.Y) : Coordinate.From(Coordinate.X, Coordinate.Y + Length - 1);
    
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
        Coordinate = Orientation switch
        {
            Orientation.Horizontal => Coordinate with { X = Coordinate.X + 1 },
            Orientation.Vertical => Coordinate with { Y = Coordinate.Y + 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

    private void Decrease() =>
        Coordinate = Orientation switch
        {
            Orientation.Horizontal => Coordinate with { X = Coordinate.X - 1 },
            Orientation.Vertical => Coordinate with { Y = Coordinate.Y - 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

    private List<Coordinate> AllCoordinates()
    {
        var coordinates = new List<Coordinate>();
        for (var i = 0; i < Length; i++)
        {
            var newX = Orientation == Orientation.Vertical ? Coordinate.X : Coordinate.X + i;
            var newY = Orientation == Orientation.Horizontal ? Coordinate.Y : Coordinate.Y + i;
            var newCoordinates = Coordinate.From(newX, newY);
            coordinates.Add(newCoordinates);
        }

        return coordinates;
    }
}