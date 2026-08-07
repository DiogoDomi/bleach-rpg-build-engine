using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvItemBuilderTests
{
    [Fact]
    public void BuildItemDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "10,20,30,40".AsSpan();

        // Act
        var (itemId, dto) = CsvItemBuilder.BuildItemDto(line);

        // Assert
        Assert.Equal((byte)10, itemId);
        Assert.Equal((byte)10, dto.Id);
        Assert.Equal((byte)20, dto.NameId);
        Assert.Equal((byte)30, dto.CategoryId);
        Assert.Equal((byte)40, dto.TypeId);
    }
}
