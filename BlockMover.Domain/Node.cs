using System.Text;

namespace BlockMover.Domain;

public class Node
{
    private Grid Grid { get; }
    private Dictionary<List<Move>, Node> Children { get; }
    private Move FromMove { get; }
    private List<Move> Moves { get; }
    private Node? Parent { get; }

    public Node(Grid grid)
    {
        Grid = grid;
        Children = new Dictionary<List<Move>, Node>();
        Moves = new List<Move>();
    }

    private Node(Node parent, Grid grid, Move fromMove)
    {
        Parent = parent;
        Grid = grid;
        FromMove = fromMove;
        Moves = new List<Move>(parent.Moves) { fromMove };
        Children = new Dictionary<List<Move>, Node>();
    }

    private static Dictionary<List<Move>, Node> ComputeChildren(Node node)
    {
        var children = new Dictionary<List<Move>, Node>();
        for (var blockIndex = 0; blockIndex < node.Grid.Blocks.Count; blockIndex++)
            foreach (Direction direction in Enum.GetValues(typeof(Direction)))
            {
                var oppositeMove = new Move(blockIndex, Opposite(direction));
                if (node.FromMove == oppositeMove) continue;
                var parentNode = node;
                while (true)
                {
                    var newGrid = parentNode.Grid.MoveBlock(blockIndex, direction);
                    if (newGrid.IsEmpty()) break;
                    var childNode = new Node(parentNode, newGrid, new Move(blockIndex, direction));
                    var listMove = new List<Move>(parentNode.Moves) { new(blockIndex, direction) };
                    children.TryAdd(listMove, childNode);
                    parentNode = childNode;
                }
            }

        return children;
    }

    private Node? ComputeChildren()
    {
        var nodes = new List<Node> { this };
        var newNodes = new List<Node>();
        var allFoundGrids = new List<Grid> { Grid };
        while (true)
        {
            newNodes.Clear();
            foreach (var node in nodes)
            {
                var children = ComputeChildren(node);
                foreach (var child in children.Where(child => !child.Value.Grid.IsIn(allFoundGrids)))
                {
                    allFoundGrids.Add(child.Value.Grid);
                    node.Children.Add(child.Key, child.Value);
                    newNodes.Add(child.Value);
                }
                var childrenHavingBlockOnExit = children.FirstOrDefault(c => c.Value.HasBlockExit());
                if (childrenHavingBlockOnExit.Value is not null) return childrenHavingBlockOnExit.Value;

            }
            if (newNodes.Count == 0) break;
            nodes = new List<Node>(newNodes);
        }

        return null;
    }

    public string GetStringWayToExit()
    {
        var exitNode = ComputeChildren();
        if (exitNode is null) return "No way";

        var stringBuilder = new StringBuilder();
        var lastMove = exitNode.Moves[0];
        stringBuilder.Append(lastMove);
        for (var i = 1; i < exitNode.Moves.Count; i++)
        {
            var currentMove = exitNode.Moves[i];
            if (currentMove == lastMove)
            {
                stringBuilder.Append(currentMove.Direction.ToDisplay());
            }
            else
            {
                stringBuilder.Append(' ');
                stringBuilder.Append(currentMove);
            }

            lastMove = currentMove;

        }
        return stringBuilder.ToString();
    }

    private bool HasBlockExit() => Grid.Blocks[0].HasCoordinate(Grid.ExitCoordinate);

    private static Direction Opposite(Direction direction) =>
        direction switch
        {
            Direction.Decrease => Direction.Increase,
            Direction.Increase => Direction.Decrease,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
}