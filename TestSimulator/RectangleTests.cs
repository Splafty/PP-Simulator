using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetCorrectProperties()
    {
        // Arrange
        int x1 = 10, y1 = 5, x2 = 20, y2 = 15;

        // Act
        var rect = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(10, rect.X1);
        Assert.Equal(5, rect.Y1);
        Assert.Equal(20, rect.X2);
        Assert.Equal(15, rect.Y2);
    }

    [Fact]
    public void Constructor_InvalidCoordinates_ShouldReorderCoordinates()
    {
        // Arrange
        int x1 = 20, y1 = 15, x2 = 10, y2 = 5;

        // Act
        var rect = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(10, rect.X1);
        Assert.Equal(5, rect.Y1);
        Assert.Equal(20, rect.X2);
        Assert.Equal(15, rect.Y2);
    }

    [Theory]
    [InlineData(10, 5, 10, 5)]
    [InlineData(5, 0, 10, 0)]
    [InlineData(10, 10, 10, 10)]
    public void Constructor_InvalidRectangle_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Constructor_WithPoints_ShouldSetCorrectProperties()
    {
        // Arrange
        var p1 = new Point(10, 5);
        var p2 = new Point(20, 15);

        // Act
        var rect = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(10, rect.X1);
        Assert.Equal(5, rect.Y1);
        Assert.Equal(20, rect.X2);
        Assert.Equal(15, rect.Y2);
    }

    [Fact]
    public void Constructor_WithPointsInvalidOrder_ShouldReorderCoordinates()
    {
        // Arrange
        var p1 = new Point(20, 15);
        var p2 = new Point(10, 5);

        // Act
        var rect = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(10, rect.X1);
        Assert.Equal(5, rect.Y1);
        Assert.Equal(20, rect.X2);
        Assert.Equal(15, rect.Y2);
    }

    [Fact]
    public void Constructor_InvalidPoints_ShouldThrowArgumentException()
    {
        // Arrange
        var p1 = new Point(10, 5);
        var p2 = new Point(5, 0);
        var p3 = new Point(10, 0);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Rectangle(p1, p1));
        Assert.Throws<ArgumentException>(() => new Rectangle(p2, p3));
    }

    [Theory]
    [InlineData(15, 10, true)]
    [InlineData(10, 10, true)]
    [InlineData(25, 25, false)]
    [InlineData(-1, -1, false)]
    public void Contains_ShouldReturnExpectedResult(int x, int y, bool expected)
    {
        // Arrange
        var rect = new Rectangle(0, 0, 20, 20);
        var point = new Point(x, y);

        // Act
        var result = rect.Contains(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ShouldReturnCorrectString()
    {
        // Arrange
        var rect = new Rectangle(4, 2, 0, 0);
        string expectedString = "(0, 0):(4, 2)";

        // Act
        var result = rect.ToString();

        // Assert
        Assert.Equal(expectedString, result);
    }
}
