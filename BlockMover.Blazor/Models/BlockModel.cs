using BlockMover.Domain;

namespace BlockMover.Blazor.Models;

public class BlockModel
{
    public int Length { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Orientation Orientation { get; set; }
}
