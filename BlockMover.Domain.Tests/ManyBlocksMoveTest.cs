namespace BlockMover.Domain.Tests;

public class ManyBlocksMoveTest
{
    [Fact]
    public void IncreaseHorizontallyShouldReturnTrue()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(0, 0));
        var block1 = new Block(2, Orientation.Vertical, Coordinate.From(3, 0));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeTrue();
    }

    [Fact]
    public void IncreaseHorizontallyShouldReturnFalse()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(1, 0));
        var block1 = new Block(2, Orientation.Vertical, Coordinate.From(3, 0));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeFalse();
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnTrue()
    {
        var block0 = new Block(2, Orientation.Vertical, Coordinate.From(0, 0));
        var block1 = new Block(2, Orientation.Horizontal, Coordinate.From(0, 3));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeTrue();
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnFalse()
    {
        var block0 = new Block(2, Orientation.Vertical, Coordinate.From(0, 1));
        var block1 = new Block(2, Orientation.Horizontal, Coordinate.From(0, 3));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeFalse();
    }

    [Fact]
    public void DecreaseHorizontallyShouldReturnTrue()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(2, 0));
        var block1 = new Block(2, Orientation.Vertical, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeTrue();
    }

    [Fact]
    public void DecreaseHorizontallyShouldReturnFalse()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(1, 0));
        var block1 = new Block(2, Orientation.Vertical, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeFalse();
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnTrue()
    {
        var block0 = new Block(2, Orientation.Vertical, Coordinate.From(0, 2));
        var block1 = new Block(2, Orientation.Horizontal, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeTrue();
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnFalse()
    {
        var block0 = new Block(2, Orientation.Vertical, Coordinate.From(0, 1));
        var block1 = new Block(2, Orientation.Horizontal, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(4, 4), new List<Block> { block0, block1 });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeFalse();
    }
}