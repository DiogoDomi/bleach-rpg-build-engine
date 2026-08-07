using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class WeaponMapperTests
{
    [Fact]
    public void MapToWeaponDomain_ValidDto_MapsCorrectlyAndIgnoresCharacterId()
    {
        // Arrange
        var dto = new WeaponDto(
            CharacterId: (ushort)999,
            NameId: (ushort)150,
            TypeId: (byte)3,
            RarityId: (byte)5
        );

        // Act
        var result = WeaponMapper.MapToWeaponDomain(dto);

        // Assert
        Assert.Equal((ushort)150, result.NameId);
        Assert.Equal((byte)3, result.TypeId);
        Assert.Equal((Rarity)5, result.Rarity);
    }

    [Fact]
    public void MapToBaseStatDomain_ValidDto_MapsCorrectlyAndIgnoresCharacterId()
    {
        // Arrange
        var dto = new WeaponBaseStatDto(
            CharacterId: (ushort)999,
            MinBaseValue: (ushort)42,
            MaxBaseValue: (ushort)520,
            StatTypeId: (byte)2
        );

        // Act
        var result = WeaponMapper.MapToBaseStatDomain(dto);

        // Assert
        Assert.Equal((ushort)42, result.MinBaseValue);
        Assert.Equal((ushort)520, result.MaxBaseValue);
        Assert.Equal((StatType)2, result.StatType);
    }
}

