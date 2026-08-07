using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct SetStampPoolAdvancedStatGrowth(
    ushort? MaxBaseValue,
    ushort MinBaseValue,
    StatType StatType
);

