namespace BlockMover.Blazor.Pages;

public partial class EscapeBlockPage : ComponentBase
{
    private string Way { get; set; } = default!;

    private Grid _grid = default!;

    private int _size = 6;
    private int Size
    {
        get => _size;
        set
        {
            _size = value;
            _grid.ChangeSize(GridSize.From(value));
        }
    }

    protected override Task OnInitializedAsync()
    {
        _grid = new Grid(new GridSize(Size, Size), new List<Block>());
        return base.OnInitializedAsync();
    }

    private void MakeBlock(int x1, int y1, int x2, int y2)
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
        Way = string.Empty;
        var node = new Node(_grid);
        Way = node.GetStringWayToExit();
    }
}
