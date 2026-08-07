using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class GameConfigMapper
{
    public static CharacterMaxUpgradeCost MapToCharacterMaxUpgradeCostDomain(
            CharacterMaxUpgradeCostDto dto)
    {
        return new CharacterMaxUpgradeCost(
            dto.Amount,
            dto.RoleId,
            (CharacterAffinity?)dto.AffinityId,
            (Rarity)dto.RarityId,
            dto.ItemId
        );
    }

    public static LimitedGachaGuaranteedPullCost MapToLimitedGachaGuaranteedPullCostDomain(
            LimitedGachaGuaranteedPullCostDto dto)
    {
        return new LimitedGachaGuaranteedPullCost(
            dto.Amount,
            dto.ItemId
        );
    }

    public static GameLevelConfig MapToGameLevelConfigDomain(
            GameLevelConfigDto dto)
    {
        return new GameLevelConfig(
            (Rarity?)dto.RarityId,
            (StarRating?)dto.StarRatingId,
            dto.SkillSubCategoryId,
            dto.MinLevel,
            dto.MaxLevel,
            dto.MinAscensionLevel,
            dto.MaxAscensionLevel,
            (EntityType)dto.EntityTypeId
        );
    }
}

