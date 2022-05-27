namespace BlockMover.Domain;

public record Grid
{
    public List<Block> Blocks { get; }
    public Coordinate ExitCoordinate { get; set; }

    private GridSize _size;
    private Block BlockToEscape => Blocks[0];

    public Grid(GridSize size, Coordinate exitCoordinate, IEnumerable<Block> blocks)
    {
        _size = size;
        Blocks = new List<Block>();
        ExitCoordinate = exitCoordinate;
        var arrayBlocks = blocks.ToArray();
        if (_size == GridSize.Null && arrayBlocks.Any()) throw new ArgumentException("size can't be (0,0)");
        if (_size == GridSize.Null) return;

        foreach (var block in arrayBlocks) AddBlock(block);

        if (exitCoordinate.X < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y < 0) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X >= _size.X) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.Y >= _size.Y) throw new ArgumentOutOfRangeException(nameof(size));
        if (exitCoordinate.X != 0 && exitCoordinate.X != _size.X - 1 && exitCoordinate.Y != 0 && exitCoordinate.Y != _size.Y - 1) throw new ArgumentOutOfRangeException(nameof(size));

    }

    public void AddBlock(Block block)
    {
        if (block.MaxCoordinate.X >= _size.X) throw new ArgumentException("block must be inside grid");
        if (block.MaxCoordinate.Y >= _size.Y) throw new ArgumentException("block must be inside grid");
        Blocks.Add(block);
        if (Blocks.Count == 1) SetEscapeCoordinate();
    }

    public Grid(GridSize size, IEnumerable<Block> blocks)
    {
        _size = size;
        Blocks = new List<Block>();
        var arrayBlocks = blocks.ToArray();
        if (_size == GridSize.Null) throw new ArgumentException("size can't be (0,0)");
        foreach (var block in arrayBlocks) AddBlock(block);
    }

    public void ChangeSize(GridSize size)
    {
        _size = size;
        if (Blocks.Count > 0) SetEscapeCoordinate();
    }

    public bool CanBlockMove(int blockIndex, Direction direction) =>
        direction switch
        {
            Direction.Decrease => CanBlockDecrease(blockIndex),
            Direction.Increase => CanBlockIncrease(blockIndex),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

    

    public bool IsEmpty() => _size == new GridSize(0, 0);

    public Grid MoveBlock(int blockIndex, Direction direction)
    {
        if (CanBlockMove(blockIndex, direction) is false) return Empty();
        var blocks = Blocks.Select(block => new Block(block.Length, block.Orientation, block.Coordinate)).ToList();
        var grid = new Grid(_size, blocks);
        grid.Blocks[blockIndex].Move(direction);
        return grid;
    }

    public bool HasReachedExit() => Blocks[0].HasCoordinate(ExitCoordinate);


    public bool IsIn(List<Grid> allGrids)
    {
        foreach (var grid in allGrids)
        {
            var isIn = true;
            // ReSharper disable once LoopCanBeConvertedToQuery because this version approximately 2x faster than Linq
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

    public bool IsInLinq(IEnumerable<Grid> allGrids) => allGrids.Select(grid => !grid.Blocks.Where((t, i) => t.Coordinate != Blocks[i].Coordinate).Any()).Any(isIn => isIn);

    private bool CanBlockIncrease(int blockIndex)
    {
        var blockToTest = Blocks[blockIndex];
        switch (blockToTest.Orientation)
        {
            case Orientation.Horizontal:
                if (blockToTest.Coordinate.X + blockToTest.Length >= _size.X) return false;
                if (Blocks.Any(block => block.HasCoordinate(Coordinate.From(blockToTest.Coordinate.X + blockToTest.Length, blockToTest.Coordinate.Y)))) return false;
                break;
            case Orientation.Vertical:
                if (blockToTest.Coordinate.Y + blockToTest.Length >= _size.Y) return false;
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

    private void SetEscapeCoordinate()
    {
        ExitCoordinate = BlockToEscape.Orientation == Orientation.Horizontal
            ? Coordinate.From(_size.X - 1, BlockToEscape.Coordinate.Y)
            : Coordinate.From(BlockToEscape.Coordinate.X, _size.Y - 1);
    }

    private static Grid Empty() => new(new GridSize(0, 0), Coordinate.From(0, 0), new List<Block>());
}