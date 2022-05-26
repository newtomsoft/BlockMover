using System.Collections.Generic;

namespace BlockMover.Domain.Tests;

public class SingleBlockMoveTest
{
    [Fact]
    public void DecreaseHorizontallyShouldReturnTrue()
    {
        var block = new Block(2, Orientation.Horizontal, Coordinate.From(1, 0));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeTrue();
        block.Move(Direction.Decrease);
        block.Coordinate.ShouldBe(Coordinate.From(0, 0));
    }

    [Fact]
    public void DecreaseHorizontallyShouldReturnFalse()
    {
        var block = new Block(2, Orientation.Horizontal, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeFalse();
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnTrue()
    {
        var block = new Block(2, Orientation.Vertical, Coordinate.From(0, 1));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeTrue();
        block.Move(Direction.Decrease);
        block.Coordinate.ShouldBe(Coordinate.From(0, 0));
    }

    [Fact]
    public void DecreaseVerticallyShouldReturnFalse()
    {
        var block = new Block(2, Orientation.Vertical, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Decrease).ShouldBeFalse();
    }

    [Fact]
    public void IncreaseHorizontallyShouldReturnTrue()
    {
        var block = new Block(2, Orientation.Horizontal, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeTrue();
        block.Move(Direction.Increase);
        block.Coordinate.ShouldBe(Coordinate.From(1, 0));
    }
    
    [Fact]
    public void IncreaseHorizontallyShouldReturnFalse()
    {
        var block = new Block(2, Orientation.Horizontal, Coordinate.From(1, 0));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeFalse();
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnTrue()
    {
        var block = new Block(2, Orientation.Vertical, Coordinate.From(0, 0));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeTrue();
        block.Move(Direction.Increase);
        block.Coordinate.ShouldBe(Coordinate.From(0, 1));
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnFalse()
    {
        var block = new Block(2, Orientation.Vertical, Coordinate.From(0, 1));
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2), new List<Block> { block });
        grid.CanBlockMove(0, Direction.Increase).ShouldBeFalse();
    }
}