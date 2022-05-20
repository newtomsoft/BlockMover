namespace BlockMover.Resolve.Test;

public class EscapeBlockKing
{
    [Fact]
    public void TestNormal822()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 2), grid);
        _ = new Block(1, 3, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(1, 1), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(1, 3), grid);
        _ = new Block(4, 2, Orientation.Horizontal, Coordinate.From(0, 5), grid);
        _ = new Block(5, 2, Orientation.Horizontal, Coordinate.From(3, 5), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        _ = new Block(7, 3, Orientation.Vertical, Coordinate.From(0, 2), grid);
        _ = new Block(8, 2, Orientation.Vertical, Coordinate.From(2, 4), grid);
        _ = new Block(9, 2, Orientation.Vertical, Coordinate.From(3, 1), grid);
        _ = new Block(10, 2, Orientation.Vertical, Coordinate.From(3, 3), grid);
        _ = new Block(11, 3, Orientation.Vertical, Coordinate.From(5, 3), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b11- b5+ b10+ b9+ b2+++ b9- b3++ b8- b4+ b7+ b6+ b1- b9- b0++ b8-- b3-- b10- b5- b11+ b0+");
    }

    [Fact]
    public void TestHard001()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(2, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(2, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(4, 0), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(3, 3), grid);
        _ = new Block(4, 2, Orientation.Horizontal, Coordinate.From(4, 4), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(0, 3), grid);
        _ = new Block(6, 3, Orientation.Vertical, Coordinate.From(2, 3), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(3, 4), grid);
        _ = new Block(8, 2, Orientation.Vertical, Coordinate.From(4, 1), grid);
        _ = new Block(9, 3, Orientation.Vertical, Coordinate.From(5, 1), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b2- b5--- b0-- b6-- b9- b3+ b7-- b4---- b6++ b0+ b5+ b1- b2- b7++ b3- b8- b9+++ b0+++");
    }

    [Fact]
    public void TestPro607()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(2, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        _ = new Block(2, 3, Orientation.Horizontal, Coordinate.From(3, 3), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(4, 4), grid);
        _ = new Block(4, 2, Orientation.Horizontal, Coordinate.From(0, 5), grid);
        _ = new Block(5, 3, Orientation.Vertical, Coordinate.From(0, 2), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(1, 3), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(2, 0), grid);
        _ = new Block(8, 2, Orientation.Vertical, Coordinate.From(2, 4), grid);
        _ = new Block(9, 2, Orientation.Vertical, Coordinate.From(3, 4), grid);
        _ = new Block(10, 2, Orientation.Vertical, Coordinate.From(4, 1), grid);
        _ = new Block(11, 3, Orientation.Vertical, Coordinate.From(5, 0), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b8- b4+ b5+ b0-- b7+ b1+++ b7- b0++ b5--- b4- b6--- b0- b8+ b2--- b9--- b2+++ b3- b8- b4+++ b5+++ b8+ b2- b11+++ b1+ b9- b0+ b6+++ b0-- b7+ b9+ b1---- b7- b9- b10- b0++++");
    }


}