using BlockMover.Domain;

var (grid, solution) = GridFactory.Create(20);

Console.WriteLine("Way to Exit :");
Console.WriteLine(string.Join(' ', solution.Reverse().Select(m => m.Invert())));


