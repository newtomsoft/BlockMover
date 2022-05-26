using System;

namespace BlockMover.Domain.Tests;

public class GridTest
{
    [Fact]
    public void NewGridShouldNotThrowWithHorizontalBlock()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(2, 2));
       
        Should.NotThrow(() =>
        {
            _ = new Grid(new GridSize(4, 4), new List<Block> { block0 });
        });
    }

    [Fact]
    public void NewGridShouldNotThrowWithVerticalBlock()
    {
        var block0 = new Block(2, Orientation.Vertical, Coordinate.From(2, 2));

        Should.NotThrow(() =>
        {
            _ = new Grid(new GridSize(4, 4), new List<Block> { block0 });
        });
    }

    [Fact]
    public void NewGridShouldThrowWithHorizontalBlock()
    {
        var block0 = new Block(2, Orientation.Horizontal, Coordinate.From(2, 2));

        Should.Throw<ArgumentException>(() =>
        {
            _ = new Grid(new GridSize(3, 2), new List<Block> { block0 });
        });
    }

    [Fact]
    public void NewGridShouldThrowWithVerticalBlock()
    {
        var block0 = new Block(2, Orientation.Vertical, Coordinate.From(2, 2));

        Should.Throw<ArgumentException>(() =>
        {
            _ = new Grid(new GridSize(2, 3), new List<Block> { block0 });
        });
    }
}
