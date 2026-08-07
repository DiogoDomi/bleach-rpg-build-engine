namespace BuildCalculator.Data.Dtos;

public readonly record struct SetStampPoolAdvancedStatGrowthDto(
    float? MaxBaseValue,
    float MinBaseValue,
    byte StarRatingId,
    byte StatTypeId
);

