using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct GameLevelConfig(
    Rarity? Rarity,
    StarRating? StarRating,
    byte? SkillSubCategoryId,
    byte? MinLevel,
    byte? MaxLevel,
    byte? MinAscensionLevel,
    byte? MaxAscensionLevel,
    EntityType EntityType
);

