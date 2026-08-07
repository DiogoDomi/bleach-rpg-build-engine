namespace BuildCalculator.Data.Dtos;

public readonly record struct SetStampFixedBasicStatGrowthDto(
    ushort MinBaseValue,
    ushort MaxBaseValue,
    byte PieceIndex,
    byte StarRatingId
);

