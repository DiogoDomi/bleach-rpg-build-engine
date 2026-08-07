using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvSetStampBuilderTests
{
    [Fact]
    public void BuildSetStampDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "100,200,5".AsSpan();

        // Act
        var (id, dto) = CsvSetStampBuilder.BuildSetStampDto(line);

        // Assert
        Assert.Equal((ushort)100, id);
        Assert.Equal((ushort)100, dto.Id);
        Assert.Equal((ushort)200, dto.NameId);
        Assert.Equal((ushort)5, dto.DisplayOrder);
    }

    [Fact]
    public void BuildPassiveDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "10,20,3".AsSpan();

        // Act
        var (id, dto) = CsvSetStampBuilder.BuildPassiveDto(line);

        // Assert
        Assert.Equal((byte)10, id);
        Assert.Equal((byte)10, dto.Id);
        Assert.Equal((byte)20, dto.NameId);
        Assert.Equal((byte)3, dto.PassiveLevel);
    }

    [Fact]
    public void BuildLevelGapDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "5,1,20".AsSpan();

        // Act
        var (starRatingId, dto) = CsvSetStampBuilder.BuildLevelGapDto(line);

        // Assert
        Assert.Equal((byte)5, starRatingId);
        Assert.Equal((byte)5, dto.StarRatingId);
        Assert.Equal((byte)1, dto.AscensionLevel);
        Assert.Equal((byte)20, dto.MaxEnhanceLevel);
    }

    [Fact]
    public void BuildFixedBasicStat_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,2".AsSpan();

        // Act
        var (pieceIndex, statTypeId) = CsvSetStampBuilder.BuildFixedBasicStat(line);

        // Assert
        Assert.Equal((byte)1, pieceIndex);
        Assert.Equal((byte)2, statTypeId);
    }

    [Fact]
    public void BuildPoolBasicStat_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "3,4".AsSpan();

        // Act
        var (pieceIndex, statTypeId) = CsvSetStampBuilder.BuildPoolBasicStat(line);

        // Assert
        Assert.Equal((byte)3, pieceIndex);
        Assert.Equal((byte)4, statTypeId);
    }

    [Fact]
    public void BuildFixedBasicStatGrowthDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "1,5,150,600".AsSpan();

        // Act
        var (pieceIndex, dto) = CsvSetStampBuilder.BuildFixedBasicStatGrowthDto(line);

        // Assert
        Assert.Equal((byte)1, pieceIndex);
        Assert.Equal((byte)1, dto.PieceIndex);
        Assert.Equal((byte)5, dto.StarRatingId);
        Assert.Equal((ushort)150, dto.MinBaseValue);
        Assert.Equal((ushort)600, dto.MaxBaseValue);
    }

    [Fact]
    public void BuildPoolBasicStatGrowthDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "5,2,10.5,25.8".AsSpan();

        // Act
        var (starRatingId, dto) = CsvSetStampBuilder.BuildPoolBasicStatGrowthDto(line);

        // Assert
        Assert.Equal((byte)5, starRatingId);
        Assert.Equal((byte)5, dto.StarRatingId);
        Assert.Equal((byte)2, dto.StatTypeId);
        Assert.Equal(10.5f, dto.MinBaseValue);
        Assert.Equal(25.8f, dto.MaxBaseValue);
    }

    [Fact]
    public void BuildPoolAdvancedStatGrowthDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "4,7,5.5,12.5".AsSpan();

        // Act
        var (starRatingId, dto) = CsvSetStampBuilder.BuildPoolAdvancedStatGrowthDto(line);

        // Assert
        Assert.Equal((byte)4, starRatingId);
        Assert.Equal((byte)4, dto.StarRatingId);
        Assert.Equal((byte)7, dto.StatTypeId);
        Assert.Equal(5.5f, dto.MinBaseValue);
        Assert.Equal((float?)12.5f, dto.MaxBaseValue);
    }

    [Fact]
    public void BuildPoolAdvancedStatGrowthDto_OptionalMaxBaseValueIsEmpty_ReturnsNull()
    {
        // Arrange
        ReadOnlySpan<char> line = "4,7,5.5,".AsSpan();

        // Act
        var (starRatingId, dto) = CsvSetStampBuilder.BuildPoolAdvancedStatGrowthDto(line);

        // Assert
        Assert.Equal((byte)4, starRatingId);
        Assert.Equal((byte)4, dto.StarRatingId);
        Assert.Equal((byte)7, dto.StatTypeId);
        Assert.Equal(5.5f, dto.MinBaseValue);
        Assert.Null(dto.MaxBaseValue);
    }
}

