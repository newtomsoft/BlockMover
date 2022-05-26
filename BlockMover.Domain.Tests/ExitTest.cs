using System.Collections.Generic;

namespace BlockMover.Domain.Tests;

public class ExitTest
{
    [Fact]
    public void ExitReached()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(2, 2));
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2), new List<Block> { block0 });
        grid.HasReachedExit().ShouldBeTrue();
    }

    [Fact]
    public void ExitNotReached()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(1, 2));
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2), new List<Block> { block0 });
        grid.HasReachedExit().ShouldBeFalse();
    }

    [Fact]
    public void ExitReachedAfterMove()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(1, 2));
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2), new List<Block> { block0 });
        grid.Blocks[0].Move(Direction.Increase);
        grid.HasReachedExit().ShouldBeTrue();
    }
}
