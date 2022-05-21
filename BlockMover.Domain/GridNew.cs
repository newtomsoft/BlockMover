namespace BlockMover.Domain;

public record GridNew
{
    public GridSize Size { get; }

    public List<BlockNew> Blocks { get; }

    public Coordinate ExitCoordinate { get; }

    public GridNew(GridSize size, Coordinate exitCoordinate)
    {
        Size = size;
        Blocks = new List<BlockNew>();
        ExitCoordinate = exitCoordinate;
        if (Size == GridSize.Null) return;
        if (exitCoordinate.X < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X >= Size.X) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y >= Size.Y) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X != 0 && exitCoordinate.X != Size.X - 1 && exitCoordinate.Y != 0 && exitCoordinate.Y != Size.Y - 1) throw new ArgumentOutOfRangeException(nameof(size));

    }

    public GridNew(GridSize size, Coordinate exitCoordinate, IEnumerable<BlockNew> blocks)
    {
        Size = size;
        Blocks = new List<BlockNew>();
        if (Size == GridSize.Null) return;
        var arrayBlocks = blocks.ToArray();
        for (var i = 0; i < arrayBlocks.Length; i++)
        {
            var currentBlock = new BlockNew(arrayBlocks[i], i);
            Blocks.Add(currentBlock);
        }
        ExitCoordinate = exitCoordinate;
        if (exitCoordinate.X < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X >= Size.X) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y >= Size.Y) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X != 0 && exitCoordinate.X != Size.X - 1 && exitCoordinate.Y != 0 && exitCoordinate.Y != Size.Y - 1) throw new ArgumentOutOfRangeException(nameof(size));

    }

    public bool CanBlockMove(int blockIndex, Direction direction) =>
        direction switch
        {
            Direction.Decrease => CanBlockDecrease(blockIndex),
            Direction.Increase => CanBlockIncrease(blockIndex),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    private bool CanBlockIncrease(int blockIndex)
    {
        var blockToTest = Blocks[blockIndex];
        switch (blockToTest.Orientation)
        {
            case Orientation.Horizontal:
                if (blockToTest.Coordinate.X + blockToTest.Length >= Size.X) return false;
                if (Blocks.Any(block => block.HasCoordinate(Coordinate.From(blockToTest.Coordinate.X + blockToTest.Length, blockToTest.Coordinate.Y)))) return false;
                break;
            case Orientation.Vertical:
                if (blockToTest.Coordinate.Y + blockToTest.Length >= Size.Y) return false;
                if (Blocks.Any(block => block.HasCoordinate(Coordinate.From(blockToTest.Coordinate.X, blockToTest.Coordinate.Y + blockToTest.Length)))) return false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }

    private bool CanBlockDecrease(int blockIndex)
    {
        var blockToTest = Blocks[blockIndex];
        switch (blockToTest.Orientation)
        {
            case Orientation.Horizontal:
                if (blockToTest.Coordinate.X == 0) return false;
                if (Blocks.Any(block => block.HasCoordinate(Coordinate.From(blockToTest.Coordinate.X - 1, blockToTest.Coordinate.Y)))) return false;
                break;
            case Orientation.Vertical:
                if (blockToTest.Coordinate.Y == 0) return false;
                if (Blocks.Any(block => block.HasCoordinate(Coordinate.From(blockToTest.Coordinate.X, blockToTest.Coordinate.Y - 1)))) return false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }

    public bool IsEmpty() => Size == new GridSize(0, 0);

    public void AddBlock(BlockNew block) => Blocks.Add(block);

    public GridNew MoveBlock(int blockIndex, Direction direction)
    {
        if (CanBlockMove(blockIndex, direction) is false) return Empty();
        var blocks = Blocks.Select(block => new BlockNew(block.Length, block.Orientation, block.Coordinate)).ToList();
        var grid = new GridNew(Size, ExitCoordinate, blocks);
        grid.Blocks[blockIndex].Move(direction);
        return grid;
    }

    public bool HasReachedExit() => Blocks[0].HasCoordinate(ExitCoordinate);


    public bool IsIn(List<GridNew> allGrids)
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

    private static GridNew Empty() => new(new GridSize(0, 0), Coordinate.From(0, 0));
}