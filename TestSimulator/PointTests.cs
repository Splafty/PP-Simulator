using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetSize()
    {
        // Arrange
        int x = 4;
        int y = 2;

        // Act
        var point = new Point(x, y);

        // Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);

        // Act
        var nextPoint = point.Next(direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    public void NextDiagonal_ShouldReturnCorrectNextDiagonalPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);

        // Act
        var nextDiagonalPoint = point.NextDiagonal(direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextDiagonalPoint);
    }
}
