namespace BlockMover.Resolve.Test;

public class EscapeBlockKing
{
    [Fact]
    public void TestNormal822()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(1, 2)),
            new(3, Orientation.Horizontal, Coordinate.From(1, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 1)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 3)),
            new(2, Orientation.Horizontal, Coordinate.From(0, 5)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 5)),
            new(2, Orientation.Vertical, Coordinate.From(0, 0)),
            new(3, Orientation.Vertical, Coordinate.From(0, 2)),
            new(2, Orientation.Vertical, Coordinate.From(2, 4)),
            new(2, Orientation.Vertical, Coordinate.From(3, 1)),
            new(2, Orientation.Vertical, Coordinate.From(3, 3)),
            new(3, Orientation.Vertical, Coordinate.From(5, 3)),
        };
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2), blocks);
        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b11- b5+ b10+ b9+ b2+++ b9- b3++ b8- b4+ b7+ b6+ b1- b9- b0++ b8-- b3-- b10- b5- b11+ b0+");
    }

    [Fact]
    public void TestHard001()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(2, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(2, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 3)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 4)),
            new(2, Orientation.Vertical, Coordinate.From(0, 3)),
            new(3, Orientation.Vertical, Coordinate.From(2, 3)),
            new(2, Orientation.Vertical, Coordinate.From(3, 4)),
            new(2, Orientation.Vertical, Coordinate.From(4, 1)),
            new(3, Orientation.Vertical, Coordinate.From(5, 1)),
        };
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2), blocks);
        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b2- b5--- b0-- b6-- b9- b3+ b7-- b4---- b6++ b0+ b5+ b1- b2- b7++ b3- b8- b9+++ b0+++");
    }

    [Fact]
    public void TestHard010()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(2, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(0, 3)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 4)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 5)),
            new(2, Orientation.Vertical, Coordinate.From(0, 1)),
            new(2, Orientation.Vertical, Coordinate.From(0, 4)),
            new(3, Orientation.Vertical, Coordinate.From(1, 0)),
            new(2, Orientation.Vertical, Coordinate.From(2, 3)),
            new(2, Orientation.Vertical, Coordinate.From(3, 0)),
            new(3, Orientation.Vertical, Coordinate.From(4, 1)),
            new(2, Orientation.Vertical, Coordinate.From(5, 4)),
        };
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2), blocks);
        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b4++ b5- b8+ b2++ b7+++ b0-- b9+ b1-- b10- b2+ b8--- b2- b3- b4- b10+++ b1++ b8- b9- b0++++");
    }


    [Fact]
    public void TestHard020()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(3, 2)),
            new(3, Orientation.Horizontal, Coordinate.From(0, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 1)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 3)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 4)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 4)),
            new(3, Orientation.Horizontal, Coordinate.From(1, 5)),
            new(3, Orientation.Vertical, Coordinate.From(0, 1)),
            new(2, Orientation.Vertical, Coordinate.From(0, 4)),
            new(2, Orientation.Vertical, Coordinate.From(3, 0)),
            new( 2, Orientation.Vertical, Coordinate.From(3, 3)),
            new( 2, Orientation.Vertical, Coordinate.From(5, 2)),
        };
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2), blocks);
        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b0-- b9+ b1+ b7- b8- b6- b10+ b9+ b2--- b9- b10- b6+ b8+ b7+ b1- b9- b11-- b0+++");
    }

    [Fact]
    public void TestPro607()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(2, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(0, 0)),
            new(3, Orientation.Horizontal, Coordinate.From(3, 3)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 4)),
            new(2, Orientation.Horizontal, Coordinate.From(0, 5)),
            new(3, Orientation.Vertical, Coordinate.From(0, 2)),
            new(2, Orientation.Vertical, Coordinate.From(1, 3)),
            new(2, Orientation.Vertical, Coordinate.From(2, 0)),
            new(2, Orientation.Vertical, Coordinate.From(2, 4)),
            new(2, Orientation.Vertical, Coordinate.From(3, 4)),
            new( 2, Orientation.Vertical, Coordinate.From(4, 1)),
            new( 3, Orientation.Vertical, Coordinate.From(5, 0)),
        };
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2), blocks);
        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b8- b4+ b5+ b0-- b7+ b1+++ b7- b0++ b5--- b4- b6--- b0- b8+ b2--- b9--- b2+++ b3- b8- b4+++ b5+++ b8+ b2- b11+++ b1+ b9- b0+ b6+++ b0-- b7+ b9+ b1---- b7- b9- b10- b0++++");
    }


}