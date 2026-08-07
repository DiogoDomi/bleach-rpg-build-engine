using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class WeaponStampMapperTests
{
    [Fact]
    public void MapToWeaponStampDomain_WithExclusiveCharacterId_MapsCorrectlyAndCastsEnum()
    {
        // Arrange
        var dto = new WeaponStampDto(
            ExclusiveEffectCharacterId: (ushort?)1050,
            Id: (ushort)20,
            NameId: (ushort)300,
            DisplayOrder: (ushort)2,
            RarityId: (byte)4,
            StatsMultiplierValue: (byte)15
        );

        // Act
        var result = WeaponStampMapper.MapToWeaponStampDomain(dto);

        // Assert
        Assert.Equal((ushort?)1050, result.ExclusiveEffectCharacterId);
        Assert.Equal((ushort)20, result.Id);
        Assert.Equal((ushort)300, result.NameId);
        Assert.Equal((ushort)2, result.DisplayOrder);
        Assert.Equal((Rarity)4, result.Rarity);
        Assert.Equal((byte)15, result.StatsMultiplierValue);
    }

    [Fact]
    public void MapToWeaponStampDomain_WithNullExclusiveCharacterId_MapsCorrectly()
    {
        // Arrange
        var dto = new WeaponStampDto(
            ExclusiveEffectCharacterId: null,
            Id: (ushort)21,
            NameId: (ushort)301,
            DisplayOrder: (ushort)3,
            RarityId: (byte)3,
            StatsMultiplierValue: (byte)10
        );

        // Act
        var result = WeaponStampMapper.MapToWeaponStampDomain(dto);

        // Assert
        Assert.Null(result.ExclusiveEffectCharacterId);
        Assert.Equal((ushort)21, result.Id);
        Assert.Equal((ushort)301, result.NameId);
        Assert.Equal((ushort)3, result.DisplayOrder);
        Assert.Equal((Rarity)3, result.Rarity);
        Assert.Equal((byte)10, result.StatsMultiplierValue);
    }
}

