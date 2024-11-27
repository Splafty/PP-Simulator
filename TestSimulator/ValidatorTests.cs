using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-5, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    [InlineData(0, 0, 10, 0)]
    [InlineData(10, 0, 10, 10)]
    public void Limiter_ShouldReturnClampedValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("test", 5, 10, '#', "Test#")]
    [InlineData("example text", 5, 10, '#', "Example te")]
    [InlineData("Test", 4, 8, '#', "Test")]
    [InlineData(" lowerCase ", 5, 15, '#', "LowerCase")]
    [InlineData("Single", 5, 6, '#', "Single")]
    [InlineData(" ", 3, 5, '#', "###")]
    [InlineData("a                   b", 3, 5, '#', "a##")]
    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}
