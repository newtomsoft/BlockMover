namespace BlockMover.Domain;

public record BlockNew
{
    public int Id { get; }
    public int Length { get; }
    public Orientation Orientation { get; }
    public Coordinate Coordinate { get; private set; }

    
    public BlockNew(int length, Orientation orientation, Coordinate coordinate)
    {
        Length = length;
        Orientation = orientation;
        Coordinate = coordinate;
    }

    public BlockNew(BlockNew block, int id)
    {
        Id = id;
        Length = block.Length;
        Orientation = block.Orientation;
        Coordinate = block.Coordinate;
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Decrease:
                Decrease();
                break;
            case Direction.Increase:
                Increase();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
    
    public void Increase() =>
        Coordinate = Orientation switch
        {
            Orientation.Horizontal => Coordinate with { X = Coordinate.X + 1 },
            Orientation.Vertical => Coordinate with { Y = Coordinate.Y + 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

    public void Decrease() =>
        Coordinate = Orientation switch
        {
            Orientation.Horizontal => Coordinate with { X = Coordinate.X - 1 },
            Orientation.Vertical => Coordinate with { Y = Coordinate.Y - 1 },
            _ => throw new ArgumentOutOfRangeException()
        };

    public bool HasCoordinate(Coordinate coordinate) => AllCoordinates().Contains(coordinate);

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