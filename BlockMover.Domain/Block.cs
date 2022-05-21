﻿namespace BlockMover.Domain;

public record Block
{
    public int Id { get; }
    public int Length { get; }
    public Orientation Orientation { get; }
    public Coordinate Coordinate { get; private set; }

    private readonly Grid _grid;

    public Block(int id, int length, Orientation orientation, Coordinate coordinate, Grid grid)
    {
        Id = id;
        Length = length;
        Orientation = orientation;
        Coordinate = coordinate;
        _grid = grid;
        _grid.AddBlock(this);
    }

    public Block(int length, Orientation orientation, Coordinate coordinate)
    {
        Length = length;
        Orientation = orientation;
        Coordinate = coordinate;
    }

    public Block(Block block, int id)
    {
        Id = id;
        Length = block.Length;
        Orientation = block.Orientation;
        Coordinate = block.Coordinate;
    }


    public bool CanMove(Direction direction) =>
        direction switch
        {
            Direction.Decrease => CanDecrease(),
            Direction.Increase => CanIncrease(),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

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

    public bool CanIncrease()
    {
        switch (Orientation)
        {
            case Orientation.Horizontal:
                if (Coordinate.X + Length >= _grid.Size.X) return false;
                if (_grid.Blocks.Any(block => block.HasCoordinate(Coordinate.From(Coordinate.X + Length, Coordinate.Y)))) return false;
                break;
            case Orientation.Vertical:
                if (Coordinate.Y + Length >= _grid.Size.Y) return false;
                if (_grid.Blocks.Any(block => block.HasCoordinate(Coordinate.From(Coordinate.X, Coordinate.Y + Length)))) return false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }

    public bool CanDecrease()
    {
        switch (Orientation)
        {
            case Orientation.Horizontal:
                if (Coordinate.X == 0) return false;
                if (_grid.Blocks.Any(block => block.HasCoordinate(Coordinate.From(Coordinate.X - 1, Coordinate.Y)))) return false;
                break;
            case Orientation.Vertical:
                if (Coordinate.Y == 0) return false;
                if (_grid.Blocks.Any(block => block.HasCoordinate(Coordinate.From(Coordinate.X, Coordinate.Y - 1)))) return false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }

    public void Increase() =>
        Coordinate = Orientation switch
        {
            Orientation.Horizontal => Coordinate with {X = Coordinate.X + 1},
            Orientation.Vertical => Coordinate with {Y = Coordinate.Y + 1},
            _ => throw new ArgumentOutOfRangeException()
        };

    public void Decrease() =>
        Coordinate = Orientation switch
        {
            Orientation.Horizontal => Coordinate with {X = Coordinate.X - 1},
            Orientation.Vertical => Coordinate with {Y = Coordinate.Y - 1},
            _ => throw new ArgumentOutOfRangeException()
        };

    public bool HasReachedExit() => HasCoordinate(_grid.ExitCoordinate);


    private bool HasCoordinate(Coordinate coordinate) => AllCoordinates().Contains(coordinate);

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