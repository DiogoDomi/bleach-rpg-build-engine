using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class CharacterMapperTests
{
    [Fact]
    public void MapToRoleDomain_ValidDto_MapsCorrectly()
    {
        // Arrange
        var dto = new CharacterRoleDto(
            Id: (byte)1,
            Name: "DPS",
            Description: "Damage Dealer"
        );

        // Act
        var result = CharacterMapper.MapToRoleDomain(dto);

        // Assert
        Assert.Equal("DPS", result.Name);
        Assert.Equal("Damage Dealer", result.Description);
    }

    [Fact]
    public void MapToCharacterDomain_ValidDto_MapsCorrectlyAndCastsEnums()
    {
        // Arrange
        var dto = new CharacterDto(
            Id: (ushort)10,
            NameId: (ushort)100,
            DisplayOrder: (ushort)1,
            AffinityId: (byte)2,
            RoleId: (byte)3,
            FactionId: (byte)4,
            RarityId: (byte)5
        );

        // Act
        var result = CharacterMapper.MapToCharacterDomain(dto);

        // Assert
        Assert.Equal((ushort)10, result.Id);
        Assert.Equal((ushort)100, result.NameId);
        Assert.Equal((ushort)1, result.DisplayOrder);
        Assert.Equal((CharacterAffinity)2, result.Affinity);
        Assert.Equal((byte)3, result.RoleId);
        Assert.Equal((byte)4, result.FactionId);
        Assert.Equal((Rarity)5, result.Rarity);
    }

    [Fact]
    public void MapToBaseStatDomain_WithAllValues_MapsCorrectly()
    {
        // Arrange
        var dto = new CharacterBaseStatDto(
            CharacterId: (ushort)10,
            MinBaseValue: (ushort)100,
            MaxBaseValue: (ushort)500,
            StatTypeId: (byte)1
        );

        // Act
        var result = CharacterMapper.MapToBaseStatDomain(dto);

        // Assert
        Assert.Equal((ushort)500, result.MaxBaseValue);
        Assert.Equal((ushort)100, result.MinBaseValue);
        Assert.Equal((StatType)1, result.StatType);
    }

    [Fact]
    public void MapToBaseStatDomain_WithNullMaxBaseValue_MapsCorrectly()
    {
        // Arrange
        var dto = new CharacterBaseStatDto(
            CharacterId: (ushort)10,
            MinBaseValue: (ushort)100,
            MaxBaseValue: null,
            StatTypeId: (byte)2
        );

        // Act
        var result = CharacterMapper.MapToBaseStatDomain(dto);

        // Assert
        Assert.Null(result.MaxBaseValue);
        Assert.Equal((ushort)100, result.MinBaseValue);
        Assert.Equal((StatType)2, result.StatType);
    }
}

