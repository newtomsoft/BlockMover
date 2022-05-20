namespace BlockMover.Domain.Tests;

public class SingleBlockDecreaseTest
{
    [Fact]
    public void DecreaseHorizontallyShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        block.CanDecrease().ShouldBeTrue();
        block.Decrease();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 0));
    }

    [Fact]
    public void DecreaseHorizontallyShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block.CanDecrease().ShouldBeFalse();
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 1), grid);
        block.CanDecrease().ShouldBeTrue();
        block.Decrease();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 0));
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block.CanDecrease().ShouldBeFalse();
    }
}