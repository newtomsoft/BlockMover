using Shouldly;
using Xunit;

namespace BlockMover.Domain.Tests;

public class SingleBlockIncreaseTest
{
    [Fact]
    public void IncreaseHorizontallyShouldReturnTrue1()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(2, 0));
    }

    [Fact]
    public void IncreaseHorizontallyShouldReturnTrue2()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(1, 0));
    }

    [Fact]
    public void IncreaseHorizontallyShouldReturnFalse1()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 3, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeFalse();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 0));
    }

    [Fact]
    public void IncreaseHorizontallyShouldReturnFalse2()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(1, 0), grid);
        block.Increase().ShouldBeFalse();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(1, 0));
    }

    [Fact]
    public void IncreaseHorizontally2TimesShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Increase().ShouldBeTrue();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(2, 0));
    }

    [Fact]
    public void IncreaseHorizontally2TimesShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Horizontal, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Increase().ShouldBeFalse();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(1, 0));
    }
    
    [Fact]
    public void IncreaseVerticallyShouldReturnTrue1()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 1), grid);
        block.Increase().ShouldBeTrue();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 2));
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnTrue2()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 1));
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnFalse1()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 3, Orientation.Vertical, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeFalse();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 0));
    }

    [Fact]
    public void IncreaseVerticallyShouldReturnFalse2()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 1), grid);
        block.Increase().ShouldBeFalse();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 1));
    }

    [Fact]
    public void IncreaseVertically2TimesShouldReturnTrue()
    {
        var grid = new Grid(new GridSize(4, 4), Coordinate.From(3, 2));
        var block = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Increase().ShouldBeTrue();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 2));
    }

    [Fact]
    public void IncreaseVertically2TimesShouldReturnFalse()
    {
        var grid = new Grid(new GridSize(3, 3), Coordinate.From(2, 2));
        var block = new Block(0, 2, Orientation.Vertical, Coordinate.From(0, 0), grid);
        block.Increase().ShouldBeTrue();
        block.Increase().ShouldBeFalse();
        block.Coordinate.ShouldBeEquivalentTo(Coordinate.From(0, 1));
    }
}