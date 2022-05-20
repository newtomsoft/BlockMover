using Shouldly;
using Xunit;

namespace BlockMover.Domain.Tests;

public class ExitTest
{
    [Fact]
    public void ExitReached()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(2, 2), grid);
        block0.HasReachedExit().ShouldBeTrue();
    }

    [Fact]
    public void ExitNotReached()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 2), grid);
        block0.HasReachedExit().ShouldBeFalse();
    }

    [Fact]
    public void ExitReachedAfterMove()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block0 = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 2), grid);
        block0.Increase();
        block0.HasReachedExit().ShouldBeTrue();
    }
}
