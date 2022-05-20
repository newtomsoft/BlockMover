namespace BlockMover.Domain;

public record Grid
{
    public GridSize Size { get; }

    public List<Block> Blocks { get; }

    public Coordinate ExitCoordinate { get; }

    public Grid(GridSize size, Coordinate exitCoordinate)
    {
        Size = size;
        Blocks = new List<Block>();
        ExitCoordinate = exitCoordinate;
        if (Size == GridSize.Null) return;
        if (exitCoordinate.X < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X >= Size.X) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y >= Size.Y) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X != 0 && exitCoordinate.X != Size.X - 1 && exitCoordinate.Y != 0 && exitCoordinate.Y != Size.Y - 1) throw new ArgumentOutOfRangeException(nameof(size));

    }

    public static Grid Empty() => new(new GridSize(0, 0), Coordinate.From(0, 0));
    public bool IsEmpty() => Size == new GridSize(0, 0);

    public void AddBlock(Block block) => Blocks.Add(block);

    public Grid MoveBlock(int blockIndex, Direction direction)
    {
        if (Blocks[blockIndex].CanMove(direction) is false) return Empty();
        var grid = new Grid(Size, ExitCoordinate);
        var blocks = Blocks.Select(block => new Block(block.Id, block.Length, block.Orientation, block.Coordinate, grid)).ToList();
        blocks[blockIndex].Move(direction);
        return grid;
    }

    public bool IsIn(List<Grid> allGrids)
    {
        foreach (var grid in allGrids)
        {
            var isIn = true;
            for (var i = 0; i < grid.Blocks.Count; i++)
            {
                if (grid.Blocks[i].Coordinate == Blocks[i].Coordinate) continue;
                isIn = false;
                break;
            }
            if (isIn) return true;
        }

        return false;
    }
}