using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class GameConfigMapperTests
{
    [Fact]
    public void MapToCharacterMaxUpgradeCostDomain_WithAllValues_MapsCorrectlyAndCastsEnums()
    {
        // Arrange
        var dto = new CharacterMaxUpgradeCostDto(
            Amount: (uint)500000,
            RoleId: (byte?)3,
            AffinityId: (byte?)2,
            Id: (byte)99,
            RarityId: (byte)5,
            ItemId: (byte)10
        );

        // Act
        var result = GameConfigMapper.MapToCharacterMaxUpgradeCostDomain(dto);

        // Assert
        Assert.Equal((uint)500000, result.Amount);
        Assert.Equal((byte?)3, result.RoleId);
        Assert.Equal((CharacterAffinity?)2, result.Affinity);
        Assert.Equal((Rarity)5, result.Rarity);
        Assert.Equal((byte)10, result.ItemId);
    }

    [Fact]
    public void MapToCharacterMaxUpgradeCostDomain_WithNullOptionalValues_MapsCorrectly()
    {
        // Arrange
        var dto = new CharacterMaxUpgradeCostDto(
            Amount: (uint)250000,
            RoleId: null,
            AffinityId: null,
            Id: (byte)100,
            RarityId: (byte)4,
            ItemId: (byte)12
        );

        // Act
        var result = GameConfigMapper.MapToCharacterMaxUpgradeCostDomain(dto);

        // Assert
        Assert.Equal((uint)250000, result.Amount);
        Assert.Null(result.RoleId);
        Assert.Null(result.Affinity);
        Assert.Equal((Rarity)4, result.Rarity);
        Assert.Equal((byte)12, result.ItemId);
    }

    [Fact]
    public void MapToLimitedGachaGuaranteedPullCostDomain_ValidDto_MapsCorrectly()
    {
        // Arrange
        var dto = new LimitedGachaGuaranteedPullCostDto(
            Amount: (ushort)90,
            EntityTypeId: (byte)1,
            ItemId: (byte)1
        );

        // Act
        var result = GameConfigMapper.MapToLimitedGachaGuaranteedPullCostDomain(dto);

        // Assert
        Assert.Equal((ushort)90, result.Amount);
        Assert.Equal((byte)1, result.ItemId);
    }

    [Fact]
    public void MapToGameLevelConfigDomain_WithAllValues_MapsCorrectlyAndCastsEnums()
    {
        // Arrange
        var dto = new GameLevelConfigDto(
            RarityId: (byte?)5,
            StarRatingId: (byte?)3,
            SkillSubCategoryId: (byte?)1,
            MinLevel: (byte?)1,
            MaxLevel: (byte?)90,
            MinAscensionLevel: (byte?)0,
            MaxAscensionLevel: (byte?)6,
            Id: (byte)10,
            EntityTypeId: (byte)2
        );

        // Act
        var result = GameConfigMapper.MapToGameLevelConfigDomain(dto);

        // Assert
        Assert.Equal((Rarity?)5, result.Rarity);
        Assert.Equal((StarRating?)3, result.StarRating);
        Assert.Equal((byte?)1, result.SkillSubCategoryId);
        Assert.Equal((byte?)1, result.MinLevel);
        Assert.Equal((byte?)90, result.MaxLevel);
        Assert.Equal((byte?)0, result.MinAscensionLevel);
        Assert.Equal((byte?)6, result.MaxAscensionLevel);
        Assert.Equal((EntityType)2, result.EntityType);
    }

    [Fact]
    public void MapToGameLevelConfigDomain_WithNullOptionalValues_MapsCorrectly()
    {
        // Arrange
        var dto = new GameLevelConfigDto(
            RarityId: null,
            StarRatingId: null,
            SkillSubCategoryId: null,
            MinLevel: null,
            MaxLevel: null,
            MinAscensionLevel: null,
            MaxAscensionLevel: null,
            Id: (byte)20,
            EntityTypeId: (byte)1
        );

        // Act
        var result = GameConfigMapper.MapToGameLevelConfigDomain(dto);

        // Assert
        Assert.Null(result.Rarity);
        Assert.Null(result.StarRating);
        Assert.Null(result.SkillSubCategoryId);
        Assert.Null(result.MinLevel);
        Assert.Null(result.MaxLevel);
        Assert.Null(result.MinAscensionLevel);
        Assert.Null(result.MaxAscensionLevel);
        Assert.Equal((EntityType)1, result.EntityType);
    }
}

