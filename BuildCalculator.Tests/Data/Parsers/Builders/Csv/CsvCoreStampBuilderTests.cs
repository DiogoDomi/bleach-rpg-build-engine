using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Testes.Data.Parsers.Builders.Csv;

public class CsvCoreStampBuilderTests
{
    [Fact]
    public void BuildCoreStampDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "10,20,30,4,5,100".AsSpan();

        // Act
        var (coreStampId, dto) = CsvCoreStampBuilder.BuildCoreStampDto(line);

        // Assert
        Assert.Equal((ushort)10, coreStampId);
        Assert.Equal((ushort)10, dto.Id);
        Assert.Equal((ushort)20, dto.NameId);
        Assert.Equal((ushort?)30, dto.ExclusiveEffectCharacterId);
        Assert.Equal((byte)4, dto.RarityId);
        Assert.Equal((byte)5, dto.StarRatingId);
        Assert.Equal((ushort)100, dto.DisplayOrder);
    }

    [Fact]
    public void BuildCoreStampDto_OptionalCharacterIdIsEmpty_ReturnsNull()
    {
        // Arrange
        ReadOnlySpan<char> line = "10,20,,4,5,100".AsSpan();

        // Act
        var (coreStampId, dto) = CsvCoreStampBuilder.BuildCoreStampDto(line);

        // Assert
        Assert.Equal((ushort)10, coreStampId);
        Assert.Equal((ushort)10, dto.Id);
        Assert.Equal((ushort)20, dto.NameId);
        Assert.Null(dto.ExclusiveEffectCharacterId);
        Assert.Equal((byte)4, dto.RarityId);
        Assert.Equal((byte)5, dto.StarRatingId);
        Assert.Equal((ushort)100, dto.DisplayOrder);
    }

    [Fact]
    public void BuildBaseStatDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "15,2,10.5,25.8".AsSpan();

        // Act
        var (coreStampId, dto) = CsvCoreStampBuilder.BuildBaseStatDto(line);

        // Assert
        Assert.Equal((ushort)15, coreStampId);
        Assert.Equal((ushort)15, dto.CoreStampId);
        Assert.Equal((byte)2, dto.StatTypeId);
        Assert.Equal(10.5f, dto.MinBaseValue);
        Assert.Equal(25.8f, dto.MaxBaseValue);
    }
}
