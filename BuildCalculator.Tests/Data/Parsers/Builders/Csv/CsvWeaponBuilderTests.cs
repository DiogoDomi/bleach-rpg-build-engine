using Xunit;
using BuildCalculator.Data.Parsers.Builders.Csv;

namespace BuildCalculator.Tests.Data.Parsers.Builders.Csv;

public class CsvWeaponBuilderTests
{
    [Fact]
    public void BuildWeaponDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "150,300,5,3".AsSpan();

        // Act
        var (characterId, dto) = CsvWeaponBuilder.BuildWeaponDto(line);

        // Assert
        Assert.Equal((ushort)150, characterId);
        Assert.Equal((ushort)150, dto.CharacterId);
        Assert.Equal((ushort)300, dto.NameId);
        Assert.Equal((byte)5, dto.TypeId);
        Assert.Equal((byte)3, dto.RarityId);
    }

    [Fact]
    public void BuildBaseStatDto_ValidRow_ReturnsExpectedTuple()
    {
        // Arrange
        ReadOnlySpan<char> line = "150,2,45,120".AsSpan();

        // Act
        var (characterId, dto) = CsvWeaponBuilder.BuildBaseStatDto(line);

        // Assert
        Assert.Equal((ushort)150, characterId);
        Assert.Equal((ushort)150, dto.CharacterId);
        Assert.Equal((byte)2, dto.StatTypeId);
        Assert.Equal((ushort)45, dto.MinBaseValue);
        Assert.Equal((ushort)120, dto.MaxBaseValue);
    }
}

