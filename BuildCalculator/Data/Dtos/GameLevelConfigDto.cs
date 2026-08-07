namespace BuildCalculator.Data.Dtos;

public readonly record struct GameLevelConfigDto(
    byte? RarityId,
    byte? StarRatingId,
    byte? SkillSubCategoryId,
    byte? MinLevel,
    byte? MaxLevel,
    byte? MinAscensionLevel,
    byte? MaxAscensionLevel,
    byte Id,
    byte EntityTypeId
);

