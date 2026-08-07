using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct SetStampFixedBasicStatGrowth(
    ushort MinBaseValue,
    ushort MaxBaseValue,
    StarRating StarRating
);

