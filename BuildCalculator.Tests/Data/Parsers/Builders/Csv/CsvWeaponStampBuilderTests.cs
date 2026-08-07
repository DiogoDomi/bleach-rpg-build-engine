using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvWeaponStampBuilderTests
{
    [Fact]
    public void BuildWeaponStampDto_ValidRowWithAllValues_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "100,200,300,5,15,10".AsSpan();

        // Act
        var (id, dto) = CsvWeaponStampBuilder.BuildWeaponStampDto(line);

        // Assert
        Assert.Equal((ushort)100, id);
        Assert.Equal((ushort)100, dto.Id);
        Assert.Equal((ushort)200, dto.NameId);
        Assert.Equal((ushort?)300, dto.ExclusiveEffectCharacterId);
        Assert.Equal((byte)5, dto.RarityId);
        Assert.Equal((byte)15, dto.StatsMultiplierValue);
        Assert.Equal((ushort)10, dto.DisplayOrder);
    }

    [Fact]
    public void BuildWeaponStampDto_OptionalCharacterIdIsEmpty_ReturnsNull()
    {
        // Arrange
        ReadOnlySpan<char> line = "100,200,,5,15,10".AsSpan();

        // Act
        var (id, dto) = CsvWeaponStampBuilder.BuildWeaponStampDto(line);

        // Assert
        Assert.Equal((ushort)100, id);
        Assert.Equal((ushort)100, dto.Id);
        Assert.Equal((ushort)200, dto.NameId);
        Assert.Null(dto.ExclusiveEffectCharacterId);
        Assert.Equal((byte)5, dto.RarityId);
        Assert.Equal((byte)15, dto.StatsMultiplierValue);
        Assert.Equal((ushort)10, dto.DisplayOrder);
    }
}

