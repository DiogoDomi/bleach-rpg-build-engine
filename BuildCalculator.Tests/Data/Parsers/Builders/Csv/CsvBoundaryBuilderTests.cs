using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvBoundaryBuilderTests
{
    [Fact]
    public void BuildBoundaryDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "101,202,3,4,5,600".AsSpan();

        // Act
        var (characterId, dto) = CsvBoundaryBuilder.BuildBoundaryDto(line);

        // Assert
        Assert.Equal((ushort)202, characterId);
        Assert.Equal((ushort)101, dto.Id);
        Assert.Equal((ushort)202, dto.CharacterId);
        Assert.Equal((byte)3, dto.AscensionId);
        Assert.Equal((byte)4, dto.TypeId);
        Assert.Equal((byte?)5, dto.ImprovementValue);
        Assert.Equal((ushort?)600, dto.SkillNameId);
    }

    [Fact]
    public void BuildBoundaryDto_OptionalValuesAreEmpty_ReturnsDtoWithNulls()
    {
        // Arrange
        ReadOnlySpan<char> line = "101,202,3,4,,".AsSpan();

        // Act
        var (characterId, dto) = CsvBoundaryBuilder.BuildBoundaryDto(line);

        // Assert
        Assert.Equal((ushort)202, characterId);
        Assert.Equal((ushort)101, dto.Id);
        Assert.Equal((ushort)202, dto.CharacterId);
        Assert.Equal((byte)3, dto.AscensionId);
        Assert.Equal((byte)4, dto.TypeId);
        Assert.Null(dto.ImprovementValue);
        Assert.Null(dto.SkillNameId);
    }

    [Fact]
    public void BuildBoundaryDto_WithWhitespaceAndQuotes_ParsesCorrectly()
    {
        // Arrange
        ReadOnlySpan<char> line = "\"101\",\"202\",\"3\",\"4\",\"5\",\"600\"".AsSpan();

        // Act
        var (characterId, dto) = CsvBoundaryBuilder.BuildBoundaryDto(line);

        // Assert
        Assert.Equal((ushort)202, characterId);
        Assert.Equal((ushort)101, dto.Id);
        Assert.Equal((byte?)5, dto.ImprovementValue);
        Assert.Equal((ushort?)600, dto.SkillNameId);
    }
}

