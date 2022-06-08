namespace BlockMover.Blazor.Components;

public partial class GridComponent
{
    [Parameter] public Action<int, int, int, int> MakeBlock { get; set; } = default!;
    [Parameter] public int Size { get; set; }
    [Parameter] public Grid Grid { get; set; } = default!;

    private int _dragStartX;
    private int _dragStartY;

    private void OnMouseDown(int x, int y)
    {
        _dragStartX = x;
        _dragStartY = y;
    }

    private void OnMouseUp(int x, int y) => MakeBlock(_dragStartX, _dragStartY, x, y);

    private (string freeOrBlock, string borders) GetClasses(Block? block, Coordinate coordinate)
    {
        string freeOrBlock;
        string borders;
        if (block is null) return ("free", string.Empty);

        var orientation = block.Orientation;
        if (block == Grid.Blocks[0])
        {
            freeOrBlock = "block_to_escape";
            if (block.MinCoordinate == coordinate)
                borders = orientation == Orientation.Horizontal
                ? "border_top_escape border_left_escape border_bottom_escape no_border_right_escape"
                : " border_top_escape border_left_escape no_border_bottom_escape border_right_escape";
            else if (block.MaxCoordinate == coordinate)
                borders = orientation == Orientation.Horizontal
                ? "border_top_escape no_border_left_escape border_bottom_escape border_right_escape"
                : "no_border_top_escape border_left_escape border_bottom_escape border_right_escape";
            else
                borders = orientation == Orientation.Horizontal
                ? "border_top_escape no_border_left_escape border_bottom_escape no_border_right_escape"
                : "no_border_top_escape border_left_escape no_border_bottom_escape border_right_escape";
            return (freeOrBlock, borders);
        }

        freeOrBlock = "block";
        if (block.MinCoordinate == coordinate)
            borders = orientation == Orientation.Horizontal
            ? "border_top border_left border_bottom no_border_right"
            : " border_top border_left no_border_bottom border_right";
        else if (block.MaxCoordinate == coordinate)
            borders = orientation == Orientation.Horizontal
            ? "border_top no_border_left border_bottom border_right"
            : "no_border_top border_left border_bottom border_right";
        else
            borders = orientation == Orientation.Horizontal
            ? "border_top no_border_left border_bottom no_border_right"
            : "no_border_top border_left no_border_bottom border_right";
        return (freeOrBlock, borders);
    }
}
