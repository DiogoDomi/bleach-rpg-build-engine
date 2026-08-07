using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvGameConfigBuilderTests
{
    [Fact]
    public void BuildCharacterMaxUpgradeCostDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,5,2,3,10,50000".AsSpan();

        // Act
        var (id, dto) = CsvGameConfigBuilder.BuildCharacterMaxUpgradeCostDto(line);

        // Assert
        Assert.Equal((byte)1, id);
        Assert.Equal((byte)1, dto.Id);
        Assert.Equal((byte)5, dto.RarityId);
        Assert.Equal((byte?)2, dto.RoleId);
        Assert.Equal((byte?)3, dto.AffinityId);
        Assert.Equal((byte)10, dto.ItemId);
        Assert.Equal((uint)50000, dto.Amount);
    }

    [Fact]
    public void BuildCharacterMaxUpgradeCostDto_OptionalValuesAreEmpty_ReturnsNulls()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,5,,,10,50000".AsSpan();

        // Act
        var (id, dto) = CsvGameConfigBuilder.BuildCharacterMaxUpgradeCostDto(line);

        // Assert
        Assert.Equal((byte)1, id);
        Assert.Equal((byte)1, dto.Id);
        Assert.Equal((byte)5, dto.RarityId);
        Assert.Null(dto.RoleId);
        Assert.Null(dto.AffinityId);
        Assert.Equal((byte)10, dto.ItemId);
        Assert.Equal((uint)50000, dto.Amount);
    }

    [Fact]
    public void BuildLimitedGachaGuaranteedPullCostDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "2,50,180".AsSpan();

        // Act
        var (id, dto) = CsvGameConfigBuilder.BuildLimitedGachaGuaranteedPullCostDto(line);

        // Assert
        Assert.Equal((byte)2, id);
        Assert.Equal((byte)2, dto.EntityTypeId);
        Assert.Equal((byte)50, dto.ItemId);
        Assert.Equal((ushort)180, dto.Amount);
    }

    [Fact]
    public void BuildGameLevelConfigDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,2,5,4,3,1,100,0,6".AsSpan();

        // Act
        var (id, dto) = CsvGameConfigBuilder.BuildGameLevelConfigDto(line);

        // Assert
        Assert.Equal((byte)1, id);
        Assert.Equal((byte)1, dto.Id);
        Assert.Equal((byte)2, dto.EntityTypeId);
        Assert.Equal((byte?)5, dto.RarityId);
        Assert.Equal((byte?)4, dto.StarRatingId);
        Assert.Equal((byte?)3, dto.SkillSubCategoryId);
        Assert.Equal((byte?)1, dto.MinLevel);
        Assert.Equal((byte?)100, dto.MaxLevel);
        Assert.Equal((byte?)0, dto.MinAscensionLevel);
        Assert.Equal((byte?)6, dto.MaxAscensionLevel);
    }

    [Fact]
    public void BuildGameLevelConfigDto_OptionalValuesAreEmpty_ReturnsNulls()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,2,,,,,,,".AsSpan();

        // Act
        var (id, dto) = CsvGameConfigBuilder.BuildGameLevelConfigDto(line);

        // Assert
        Assert.Equal((byte)1, id);
        Assert.Equal((byte)1, dto.Id);
        Assert.Equal((byte)2, dto.EntityTypeId);
        Assert.Null(dto.RarityId);
        Assert.Null(dto.StarRatingId);
        Assert.Null(dto.SkillSubCategoryId);
        Assert.Null(dto.MinLevel);
        Assert.Null(dto.MaxLevel);
        Assert.Null(dto.MinAscensionLevel);
        Assert.Null(dto.MaxAscensionLevel);
    }
}

