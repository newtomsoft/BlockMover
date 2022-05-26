using BlockMover.Domain;

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
var grid = new Grid(new GridSize(5, 5), Coordinate.From(4, 2), blocks);
var node = new Node(grid);
var wayToExit = node.GetStringWayToExit();

Console.WriteLine("Way to Exit :");
Console.WriteLine(wayToExit);