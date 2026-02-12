using Project498.WebApi.Services;

namespace Project498.WebApi.Tests;

public class StringServiceTests
{
    private readonly StringService _stringService = new();

    [Theory]
    [InlineData("hello", "olleh")]
    [InlineData("", "")]
    [InlineData(null, "")]
    [InlineData("a", "a")]
    [InlineData("racecar", "racecar")]
    [InlineData("hello world", "dlrow olleh")]
    [InlineData("hello  world", "dlrow  olleh")]
    [InlineData(" hello world", "dlrow olleh ")]
    [InlineData("hello world ", " dlrow olleh")]
    public void Reverse_WithVariousInputs_ReturnsExpectedResult(string? input, string expected)
    {
        var result = _stringService.Reverse(input!);

        Assert.Equal(expected, result);
    }
    
    // Used Day 4 slides and existing tests for test case examples
    // Also added test cases for other language(s) and apostrophes
    [Theory]
    [InlineData("Hello World", "World Hello")]
    [InlineData("", "")]
    [InlineData("     ", "")]
    [InlineData("hello", "hello")]
    [InlineData(null, "")]
    [InlineData("The quick brown fox", "fox brown quick The")]
    [InlineData(" hello  world ", "world hello")]
    [InlineData("hello  world!", "world! hello")]
    [InlineData("a b  c", "c b a")]
    [InlineData("你好", "好你")]
    [InlineData("don't","don't")]
    [InlineData("I don't know","know don't I")]
    [InlineData("מה קורה?","קורה? מה")]
    public void ReverseWords_WithVariousInputs(string? input, string expected) {
        var result = _stringService.ReverseWords(input!);
        
        Assert.Equal(expected, result);
    }
}
