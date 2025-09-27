namespace BlockMover.Domain;

public class GridFactory
{
    public static (Grid grid, IEnumerable<Move> solution) Create(int nbMoves)
    {
        var solution = new List<Move>();
        var blocks = new List<Block>
        {
            new(2, Orientation.Horizontal, new Coordinate(4, 2)),
            new(2, Orientation.Horizontal, new Coordinate(0, 0)),
            new(2, Orientation.Horizontal, new Coordinate(0, 1)),
            new(3, Orientation.Vertical, new Coordinate(0, 2)),
            new(3, Orientation.Vertical, new Coordinate(1, 2)),
            new(2, Orientation.Vertical, new Coordinate(2, 0)),
            new(2, Orientation.Vertical, new Coordinate(3, 0)),
            new(2, Orientation.Vertical, new Coordinate(3, 3)),
            new(2, Orientation.Vertical, new Coordinate(4, 0)),
            new(2, Orientation.Vertical, new Coordinate(5, 1)),
            new(3, Orientation.Horizontal, new Coordinate(0, 5)),
            new(2, Orientation.Horizontal, new Coordinate(4, 4)),
        };
        var grid = new Grid(new GridSize(6, 6), new Coordinate(5, 2), blocks);
        var random = new Random();
        for (var i = 0; i < nbMoves; i++)
        {
            var blockToMove = random.Next(0, grid.Blocks.Count);
            var direction = random.Next(0, 2) == 0 ? Direction.Decrease : Direction.Increase;
            if (grid.CanBlockMove(blockToMove, direction))
            {
                solution.Add(new Move(blockToMove, direction));
                grid = grid.MoveBlock(blockToMove, direction);
            }
        }

        return (grid, solution);
    }
}