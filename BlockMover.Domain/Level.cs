namespace BlockMover.Domain;

public record Level(Grid Grid, IEnumerable<Move> Solution);