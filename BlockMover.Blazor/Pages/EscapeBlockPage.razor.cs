namespace BlockMover.Blazor.Pages;

public partial class EscapeBlockPage : ComponentBase
{
    private Grid _grid = default!;

    private int _size = 6;
    private bool _disabledNavigatesPreviousMoves = true;
    private bool _disabledNavigatesNextMoves = true;

    private int Size
    {
        get => _size;
        set
        {
            _size = value;
            _grid.ChangeSize(GridSize.From(value));
        }
    }

    private Stack<Move> NextMoves { get; set; } = default!;
    private Stack<Move> PreviousMoves { get; set; } = new();

    protected override Task OnInitializedAsync()
    {
        _grid = new Grid(new GridSize(Size, Size), new List<Block>());
        return base.OnInitializedAsync();
    }

    private void MakeBlocks(int x1, int y1, int x2, int y2)
    {
        var diffX = x2 - x1;
        var diffY = y2 - y1;
        if (diffX != 0 && diffY != 0) return;
        if (diffX == 0 && diffY == 0) return;

        var orientation = diffX != 0 ? Orientation.Horizontal : Orientation.Vertical;

        int length;
        Coordinate startCoordinate;
        if (diffX != 0)
        {
            length = Math.Abs(diffX) + 1;
            startCoordinate = diffX > 0 ? Coordinate.From(x1, y1) : Coordinate.From(x2, y2);
        }
        else
        {
            length = Math.Abs(diffY) + 1;
            startCoordinate = diffY > 0 ? Coordinate.From(x1, y1) : Coordinate.From(x2, y2);
        }

        _grid.AddBlock(new Block(length, orientation, startCoordinate));
    }

    private void ComputeWay()
    {
        _disabledNavigatesPreviousMoves = true;
        _disabledNavigatesNextMoves = true;
        var node = new Node(_grid);
        var moves = node.GetMovesToEscape();
        NextMoves = new Stack<Move>(moves.Reverse());
        PreviousMoves = new Stack<Move>();
        _disabledNavigatesNextMoves = false;
    }

    private void MoveBlock(int blockIndex, Direction direction) => _grid = _grid.MoveBlock(blockIndex, direction);

    private void ShowNextMove()
    {
        if (NextMoves.Count == 0) return;
        Move move;
        do
        {
            move = NextMoves.Pop();
            MoveBlock(move.BlockId, move.Direction);
            PreviousMoves.Push(move.Invert());
            _disabledNavigatesPreviousMoves = false;
        } while (NextMoves.Count > 0 && NextMoves.Peek() == move);

        if (NextMoves.Count == 0) _disabledNavigatesNextMoves = true;
    }

    private void ShowPreviousMove()
    {
        if (PreviousMoves.Count == 0) return;
        Move move;
        do
        {
            move = PreviousMoves.Pop();
            MoveBlock(move.BlockId, move.Direction);
            NextMoves.Push(move.Invert());
            _disabledNavigatesNextMoves = false;
        } while (PreviousMoves.Count > 0 && PreviousMoves.Peek() == move);

        if (PreviousMoves.Count == 0) _disabledNavigatesPreviousMoves = true;
    }
}
