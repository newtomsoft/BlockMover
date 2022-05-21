using System.Collections.Generic;

namespace BlockMover.Domain.Tests;
public class ResolveTest
{
    [Fact]
    public void MoveBlocksShould()
    {
        var block0 = new BlockNew(2, Orientation.Horizontal, Coordinate.From(0, 1));
        var block1 = new BlockNew(2, Orientation.Vertical, Coordinate.From(2, 0));
        var block2 = new BlockNew(2, Orientation.Horizontal, Coordinate.From(1, 2));
        var grid = new GridNew(new GridSize(4, 4), Coordinate.From(3, 1), new List<BlockNew> { block0, block1, block2 });

        grid.MoveBlock(0, Direction.Increase).IsEmpty().ShouldBeTrue();
        grid.MoveBlock(0, Direction.Decrease).IsEmpty().ShouldBeTrue();

        grid.MoveBlock(1, Direction.Increase).IsEmpty().ShouldBeTrue();
        grid.MoveBlock(1, Direction.Decrease).IsEmpty().ShouldBeTrue();

        var gridAfterB2Increase = grid.MoveBlock(2, Direction.Increase);
        gridAfterB2Increase.Blocks[0].ShouldBe(grid.Blocks[0]);
        gridAfterB2Increase.Blocks[1].ShouldBe(grid.Blocks[1]);
        gridAfterB2Increase.Blocks[2].Id.ShouldBe(grid.Blocks[2].Id);
        gridAfterB2Increase.Blocks[2].Orientation.ShouldBe(grid.Blocks[2].Orientation);
        gridAfterB2Increase.Blocks[2].Length.ShouldBe(grid.Blocks[2].Length);
        gridAfterB2Increase.Blocks[2].Coordinate.ShouldBe(Coordinate.From(2, 2));

        var gridAfterB2Decrease = grid.MoveBlock(2, Direction.Decrease);
        gridAfterB2Decrease.Blocks[0].ShouldBe(grid.Blocks[0]);
        gridAfterB2Decrease.Blocks[1].ShouldBe(grid.Blocks[1]);
        gridAfterB2Decrease.Blocks[2].Id.ShouldBe(grid.Blocks[2].Id);
        gridAfterB2Decrease.Blocks[2].Orientation.ShouldBe(grid.Blocks[2].Orientation);
        gridAfterB2Decrease.Blocks[2].Length.ShouldBe(grid.Blocks[2].Length);
        gridAfterB2Decrease.Blocks[2].Coordinate.ShouldBe(Coordinate.From(0, 2));
    }

    [Fact]
    public void TestNoExit2In3By3()
    {
        var block0 = new BlockNew(2, Orientation.Vertical, Coordinate.From(0, 0));
        var block1 = new BlockNew(2, Orientation.Vertical, Coordinate.From(2, 1));
        var grid = new GridNew(new GridSize(3, 3), Coordinate.From(2, 0), new List<BlockNew> { block0, block1 });

        var node = new NodeNew(grid);
        node.GetStringWayToExit().ShouldBe("No way");
    }

    [Fact]
    public void Test3In4By4()
    {
        var blocks = new List<BlockNew>
        {
            new(2, Orientation.Horizontal, Coordinate.From(0, 1)),
            new(2, Orientation.Vertical, Coordinate.From(2, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 2)),
        };
        var grid = new GridNew(new GridSize(4, 4), Coordinate.From(3, 1), blocks);
        new NodeNew(grid).GetStringWayToExit().ShouldBe("b2- b1++ b0++");
    }

    [Fact]
    public void Test4In4By4()
    {
        var blocks = new List<BlockNew>
        {
            new(2, Orientation.Horizontal, Coordinate.From(0, 1)),
            new(2, Orientation.Vertical, Coordinate.From(2, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(2, 3)),
        };
        var grid = new GridNew(new GridSize(4, 4), Coordinate.From(3, 1), blocks);
        new NodeNew(grid).GetStringWayToExit().ShouldBe("b2- b3-- b1++ b0++");
    }

    [Fact]
    public void Test5In4By4()
    {
        var blocks = new List<BlockNew>
        {
            new (2, Orientation.Horizontal, Coordinate.From(0, 1)),
            new (2, Orientation.Vertical, Coordinate.From(2, 0)),
            new (2, Orientation.Vertical, Coordinate.From(3, 0)),
            new (2, Orientation.Horizontal, Coordinate.From(1, 2)),
            new (2, Orientation.Horizontal, Coordinate.From(1, 3)),
        };
        var grid = new GridNew(new GridSize(4, 4), Coordinate.From(3, 1), blocks);
        var node = new NodeNew(grid);
        node.GetStringWayToExit().ShouldBe("b2++ b3- b4- b1++ b0++");
    }


    [Fact]
    public void Test6In5By5()
    {
        var grid = new Grid(new GridSize(5, 5), Coordinate.From(4, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(2, 1), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(0, 4), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(2, 4), grid);
        _ = new Block(4, 2, Orientation.Vertical, Coordinate.From(2, 2), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(4, 1), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1-- b4-- b5++ b0+++");
    }

    [Fact]
    public void Test8In5By5()
    {
        var grid = new Grid(new GridSize(5, 5), Coordinate.From(4, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(2, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(1, 4), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(3, 4), grid);
        _ = new Block(3, 2, Orientation.Vertical, Coordinate.From(2, 0), grid);
        _ = new Block(4, 2, Orientation.Vertical, Coordinate.From(3, 0), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(4, 0), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(1, 2), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(4, 2), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b2- b7+ b0+");
    }

    [Fact]
    public void Test7In6By6()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 3, Orientation.Horizontal, Coordinate.From(2, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(1, 3), grid);
        _ = new Block(3, 3, Orientation.Horizontal, Coordinate.From(2, 4), grid);
        _ = new Block(4, 3, Orientation.Horizontal, Coordinate.From(3, 5), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(2, 1), grid);
        _ = new Block(6, 3, Orientation.Vertical, Coordinate.From(3, 1), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1+ b3-- b4--- b5- b6++ b0++++");
    }



    [Fact]
    public void Test6In6By6()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 3, Orientation.Horizontal, Coordinate.From(1, 1), grid);
        _ = new Block(2, 3, Orientation.Vertical, Coordinate.From(4, 0), grid);
        _ = new Block(3, 3, Orientation.Vertical, Coordinate.From(5, 0), grid);
        _ = new Block(4, 2, Orientation.Vertical, Coordinate.From(2, 2), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(2, 4), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b2+++ b3+++ b1++ b4-- b0++++");
    }
}
