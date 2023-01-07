namespace BlockMover.Domain;

public record Move(int BlockId, Direction Direction)
{
    public override string ToString() => "b" + BlockId + Direction.ToDisplay();

    public Move Invert() => this with {Direction = Direction == Direction.Decrease ? Direction.Increase : Direction.Decrease};
}