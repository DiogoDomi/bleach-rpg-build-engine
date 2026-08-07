using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvSkillBuilderTests
{
    [Fact]
    public void BuildCategoryDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,Offensive,10".AsSpan();

        // Act
        var (categoryId, dto) = CsvSkillBuilder.BuildCategoryDto(line);

        // Assert
        Assert.Equal((byte)1, categoryId);
        Assert.Equal((byte)1, dto.Id);
        Assert.Equal("Offensive", dto.Name);
        Assert.Equal((byte)10, dto.DisplayOrder);
    }

    [Fact]
    public void BuildSubCategoryDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "5,Slash,1,20".AsSpan();

        // Act
        var (subCategoryId, dto) = CsvSkillBuilder.BuildSubCategoryDto(line);

        // Assert
        Assert.Equal((byte)5, subCategoryId);
        Assert.Equal((byte)5, dto.Id);
        Assert.Equal("Slash", dto.Name);
        Assert.Equal((byte)1, dto.CategoryId);
        Assert.Equal((byte)20, dto.DisplayOrder);
    }

    [Fact]
    public void BuildSkillDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1000,500,2000,3,1".AsSpan();

        // Act
        var (characterId, dto) = CsvSkillBuilder.BuildSkillDto(line);

        // Assert
        Assert.Equal((ushort)500, characterId);
        Assert.Equal((ushort)1000, dto.Id);
        Assert.Equal((ushort)500, dto.CharacterId);
        Assert.Equal((ushort)2000, dto.NameId);
        Assert.Equal((byte)3, dto.SubCategoryId);
        Assert.Equal((byte)1, dto.DisplayOrder);
    }

    [Fact]
    public void BuildTagMappingDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1000,7".AsSpan();

        // Act
        var (skillId, dto) = CsvSkillBuilder.BuildTagMappingDto(line);

        // Assert
        Assert.Equal((ushort)1000, skillId);
        Assert.Equal((ushort)1000, dto.SkillId);
        Assert.Equal((byte)7, dto.TagId);
    }
}

