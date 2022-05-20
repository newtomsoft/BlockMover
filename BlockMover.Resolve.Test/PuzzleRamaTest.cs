namespace BlockMover.Resolve.Test;

public class PuzzleRamaTest
{
    [Fact]
    public void TestEasy10_7In5By5()
    {
        var grid = new Grid(new GridSize(5, 5), Coordinate.From(4, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(3, 0), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(2, 4), grid);
        _ = new Block(4, 2, Orientation.Vertical, Coordinate.From(2, 1), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(4, 1), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(1, 3), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b4- b5++ b0+++");
    }

    [Fact]
    public void TestEasy30_8In5By5Ex2()
    {
        var grid = new Grid(new GridSize(5, 5), Coordinate.From(4, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(3, 0), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(3, 3), grid);
        _ = new Block(4, 2, Orientation.Vertical, Coordinate.From(0, 1), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(2, 3), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(3, 1), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(4, 1), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b4++ b0- b5--- b3-- b6++ b7++ b0+++");
    }

    [Fact]
    public void TestEasy50_9In5By5()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(2, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(1, 1), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(4, 3), grid);
        _ = new Block(4, 3, Orientation.Horizontal, Coordinate.From(3, 5), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(2, 2), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(2, 4), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(3, 1), grid);
        _ = new Block(8, 3, Orientation.Vertical, Coordinate.From(5, 0), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1+ b2- b5-- b3---- b6- b4- b7++ b8+++ b0++++");
    }

    [Fact]
    public void TestMedium40_11In6By6()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 3, Orientation.Horizontal, Coordinate.From(2, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(0, 1), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(2, 3), grid);
        _ = new Block(4, 3, Orientation.Horizontal, Coordinate.From(2, 4), grid);
        _ = new Block(5, 2, Orientation.Horizontal, Coordinate.From(4, 5), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(0, 3), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(2, 1), grid);
        _ = new Block(8, 2, Orientation.Vertical, Coordinate.From(4, 1), grid);
        _ = new Block(9, 2, Orientation.Vertical, Coordinate.From(5, 0), grid);
        _ = new Block(10, 3, Orientation.Vertical, Coordinate.From(5, 2), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b4- b5- b8++ b10+ b9+ b1+ b7- b0+++ b7+ b1- b9- b0+");
    }

    [Fact]
    public void TestMedium50_9In6By6()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(4, 3), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(4, 4), grid);
        _ = new Block(3, 3, Orientation.Horizontal, Coordinate.From(2, 5), grid);
        _ = new Block(4, 2, Orientation.Vertical, Coordinate.From(1, 4), grid);
        _ = new Block(5, 2, Orientation.Vertical, Coordinate.From(2, 3), grid);
        _ = new Block(6, 3, Orientation.Vertical, Coordinate.From(3, 2), grid);
        _ = new Block(7, 2, Orientation.Vertical, Coordinate.From(4, 0), grid);
        _ = new Block(8, 3, Orientation.Vertical, Coordinate.From(5, 0), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b4- b3-- b5--- b6+ b0++ b4--- b0- b6--- b1--- b2--- b6+++ b8+++ b0+++");
    }

    [Fact]
    public void TestAdvanced50_11In6By6()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 2), grid);
        _ = new Block(1, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(4, 0), grid);
        _ = new Block(3, 2, Orientation.Horizontal, Coordinate.From(3, 1), grid);
        _ = new Block(4, 2, Orientation.Horizontal, Coordinate.From(4, 3), grid);
        _ = new Block(5, 2, Orientation.Horizontal, Coordinate.From(2, 5), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(0, 3), grid);
        _ = new Block(7, 3, Orientation.Vertical, Coordinate.From(1, 3), grid);
        _ = new Block(8, 3, Orientation.Vertical, Coordinate.From(2, 1), grid);
        _ = new Block(9, 3, Orientation.Vertical, Coordinate.From(3, 2), grid);
        _ = new Block(10, 2, Orientation.Vertical, Coordinate.From(5, 4), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b5+ b8++ b3-- b9-- b4- b10--- b4+ b5+ b9+++ b2- b10- b0++++");
    }

    [Fact]
    public void TestExpert50_10In6By6()
    {
        var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2));
        _ = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 2), grid);
        _ = new Block(1, 3, Orientation.Horizontal, Coordinate.From(2, 0), grid);
        _ = new Block(2, 2, Orientation.Horizontal, Coordinate.From(0, 3), grid);
        _ = new Block(3, 3, Orientation.Horizontal, Coordinate.From(3, 4), grid);
        _ = new Block(4, 3, Orientation.Horizontal, Coordinate.From(0, 5), grid);
        _ = new Block(5, 3, Orientation.Vertical, Coordinate.From(0, 0), grid);
        _ = new Block(6, 2, Orientation.Vertical, Coordinate.From(2, 3), grid);
        _ = new Block(7, 3, Orientation.Vertical, Coordinate.From(4, 1), grid);
        _ = new Block(8, 2, Orientation.Vertical, Coordinate.From(5, 0), grid);
        _ = new Block(9, 2, Orientation.Vertical, Coordinate.From(5, 2), grid);

        var node = new Node(grid);
        node.GetStringWayToExit().ShouldBe("b1- b4+++ b6+ b7- b2+++ b5+++ b0- b6--- b2- b3-- b4-- b7+++ b9+ b8+ b1++ b6- b0+++ b6+ b1- b8- b0+");
    }
}