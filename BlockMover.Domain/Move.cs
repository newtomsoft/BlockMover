namespace BlockMover.Domain;

public record Move(int BlockId, Direction Direction)
{
    public override string ToString() => "b" + BlockId + Direction.ToDisplay();
}