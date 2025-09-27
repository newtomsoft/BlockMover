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
        Generate();
        return base.OnInitializedAsync();
    }

    private void Generate()
    {
        var (grid, solution) = GridFactory.Create(20);
        _grid = grid;
        NextMoves = new Stack<Move>(solution.Reverse().Select(m => m.Invert()));
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
