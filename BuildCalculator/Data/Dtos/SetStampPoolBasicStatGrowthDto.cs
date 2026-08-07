namespace BuildCalculator.Data.Dtos;

public readonly record struct SetStampPoolBasicStatGrowthDto(
    float MinBaseValue,
    float MaxBaseValue,
    byte StarRatingId,
    byte StatTypeId
);

