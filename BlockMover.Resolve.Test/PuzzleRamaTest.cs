namespace BlockMover.Resolve.Test;

public class PuzzleRamaTest
{
    [Fact]
    public void TestEasy10_7In5By5()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(0, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(2, 4)),
            new(2, Orientation.Vertical, Coordinate.From(2, 1)),
            new(2, Orientation.Vertical, Coordinate.From(4, 1)),
            new(2, Orientation.Vertical, Coordinate.From(1, 3)),
        };
        var grid = new Grid(new GridSize(5, 5), blocks);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b4- b5++ b0+++");
    }

    [Fact]
    public void TestEasy30_8In5By5Ex2()
    {

        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(1, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(1, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 3)),
            new(2, Orientation.Vertical, Coordinate.From(0, 1)),
            new(2, Orientation.Vertical, Coordinate.From(2, 3)),
            new(2, Orientation.Vertical, Coordinate.From(3, 1)),
            new(2, Orientation.Vertical, Coordinate.From(4, 1)),
        };
        var grid = new Grid(new GridSize(5, 5), blocks);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b4++ b0- b5--- b3-- b6++ b7++ b0+++");
    }

    [Fact]
    public void TestAdvanced50_11In6By6()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(0, 2)),
            new(2, Orientation.Horizontal, Coordinate.From(0, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(3, 1)),
            new(2, Orientation.Horizontal, Coordinate.From(4, 3)),
            new(2, Orientation.Horizontal, Coordinate.From(2, 5)),
            new(2, Orientation.Vertical, Coordinate.From(0, 3)),
            new(3, Orientation.Vertical, Coordinate.From(1, 3)),
            new(3, Orientation.Vertical, Coordinate.From(2, 1)),
            new(3, Orientation.Vertical, Coordinate.From(3, 2)),
            new(2, Orientation.Vertical, Coordinate.From(5, 4)),
        };
        var grid = new Grid(new GridSize(6, 6), blocks);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b5+ b8++ b3-- b9-- b4- b10--- b4+ b5+ b9+++ b2- b10- b0++++");
    }

    [Fact]
    public void TestExpert50_10In6By6()
    {
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, Coordinate.From(1, 2)),
            new(3, Orientation.Horizontal, Coordinate.From(2, 0)),
            new(2, Orientation.Horizontal, Coordinate.From(0, 3)),
            new(3, Orientation.Horizontal, Coordinate.From(3, 4)),
            new(3, Orientation.Horizontal, Coordinate.From(0, 5)),
            new(3, Orientation.Vertical, Coordinate.From(0, 0)),
            new(2, Orientation.Vertical, Coordinate.From(2, 3)),
            new(3, Orientation.Vertical, Coordinate.From(4, 1)),
            new(2, Orientation.Vertical, Coordinate.From(5, 0)),
            new(2, Orientation.Vertical, Coordinate.From(5, 2)),
        };
        var grid = new Grid(new GridSize(6, 6), blocks);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b4+++ b6+ b7- b2+++ b5+++ b0- b6--- b2- b3-- b4-- b7+++ b9+ b8+ b1++ b6- b0+++ b6+ b1- b8- b0+");
    }
}