namespace BlockMover.Domain.Tests;

public class ManyBlocksIncreaseTest
{
    [Fact]
    public void IncreaseHorizontallyShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        var block1 = new Block(0, 2, Orientation.Vertical, Coordinate.From(3, 0), grid);
        block0.CanIncrease().ShouldBeTrue();
    }

    [Fact]
    public void IncreaseHorizontallyShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        var block1 = new Block(0, 2, Orientation.Vertical, Coordinate.From(3, 0), grid);
        block0.CanIncrease().ShouldBeFalse();
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        var block1 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 3), grid);
        block0.CanIncrease().ShouldBeTrue();
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 1), grid);
        var block1 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 3), grid);
        block0.CanIncrease().ShouldBeFalse();
    }

    [Fact]
    public void DecreaseHorizontallyShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(2, 0), grid);
        var block1 = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        block0.CanDecrease().ShouldBeTrue();
    }

    [Fact]
    public void DecreaseHorizontallyShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        var block1 = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        block0.CanDecrease().ShouldBeFalse();
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 2), grid);
        var block1 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block0.CanDecrease().ShouldBeTrue();
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 1), grid);
        var block1 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block0.CanDecrease().ShouldBeFalse();
    }
}