using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class CoreStampMapperTests
{
    [Fact]
    public void MapToCoreStampDomain_WithAllValues_MapsCorrectlyAndCastsEnums()
    {
        // Arrange
        var dto = new CoreStampDto(
            ExclusiveEffectCharacterId: (ushort?)999,
            Id: (ushort)10,
            NameId: (ushort)100,
            DisplayOrder: (ushort)1,
            RarityId: (byte)4,
            StarRatingId: (byte)5
        );

        // Act
        var result = CoreStampMapper.MapToCoreStampDomain(dto);

        // Assert
        Assert.Equal((ushort?)999, result.ExclusiveEffectCharacterId);
        Assert.Equal((ushort)10, result.Id);
        Assert.Equal((ushort)100, result.NameId);
        Assert.Equal((ushort)1, result.DisplayOrder);
        Assert.Equal((Rarity)4, result.Rarity);
        Assert.Equal((StarRating)5, result.StarRating);
    }

    [Fact]
    public void MapToCoreStampDomain_WithNullExclusiveCharacterId_MapsCorrectly()
    {
        // Arrange
        var dto = new CoreStampDto(
            ExclusiveEffectCharacterId: null,
            Id: (ushort)15,
            NameId: (ushort)150,
            DisplayOrder: (ushort)2,
            RarityId: (byte)3,
            StarRatingId: (byte)4
        );

        // Act
        var result = CoreStampMapper.MapToCoreStampDomain(dto);

        // Assert
        Assert.Null(result.ExclusiveEffectCharacterId);
        Assert.Equal((ushort)15, result.Id);
        Assert.Equal((Rarity)3, result.Rarity);
    }

    [Fact]
    public void MapToBaseStatDomain_ValidDto_AppliesScalingRoundsAndMapsCorrectly()
    {
        // Arrange
        var dto = new CoreStampBaseStatDto(
            CoreStampId: (ushort)10,
            MinBaseValue: 10.55f,
            MaxBaseValue: 25.89f,
            StatTypeId: (byte)1
        );

        // Act
        var result = CoreStampMapper.MapToBaseStatDomain(dto);

        // Assert
        Assert.Equal((uint)1055, result.MinBaseValue);
        Assert.Equal((uint)2589, result.MaxBaseValue);
        Assert.Equal((StatType)1, result.StatType);
    }

    [Fact]
    public void MapToBaseStatDomain_WithValuesNeedingRounding_RoundsCorrectly()
    {
        // Arrange
        var dto = new CoreStampBaseStatDto(
            CoreStampId: (ushort)10,
            MinBaseValue: 10.124f,
            MaxBaseValue: 10.126f,
            StatTypeId: (byte)2
        );

        // Act
        var result = CoreStampMapper.MapToBaseStatDomain(dto);

        // Assert
        Assert.Equal((uint)1012, result.MinBaseValue);
        Assert.Equal((uint)1013, result.MaxBaseValue);
    }
}

