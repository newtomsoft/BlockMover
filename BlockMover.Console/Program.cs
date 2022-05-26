using BlockMover.Domain;

var blocks = new List<Block>
{
    new(2, Orientation.Horizontal, Coordinate.From(1, 2)),
    new(3, Orientation.Horizontal, Coordinate.From(1, 0)),
    new(3, Orientation.Horizontal, Coordinate.From(1, 1)),
    new(2, Orientation.Horizontal, Coordinate.From(1, 3)),
    new(2, Orientation.Horizontal, Coordinate.From(3, 4)),
    new(2, Orientation.Horizontal, Coordinate.From(0, 5)),
    new(2, Orientation.Vertical, Coordinate.From(0, 1)),
    new(2, Orientation.Vertical, Coordinate.From(0, 3)),
    new(2, Orientation.Vertical, Coordinate.From(2, 4)),
    new(2, Orientation.Vertical, Coordinate.From(3, 2)),
    new(3, Orientation.Vertical, Coordinate.From(4, 0)),
    new(2, Orientation.Vertical, Coordinate.From(5, 4)),
};
var grid = new Grid(new GridSize(6, 6), Coordinate.From(5, 2), blocks);
var node = new Node(grid);
var wayToExit = node.GetStringWayToExit();

Console.WriteLine("Way to Exit :");
Console.WriteLine(wayToExit);


