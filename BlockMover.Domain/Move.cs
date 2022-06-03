namespace BlockMover.Domain;

public record Move(int BlockId, Block Block, Direction Direction)
{
    public override string ToString() => "b" + BlockId + Direction.ToDisplay();
}