using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct SetStampPoolBasicStatGrowth(
    uint MinBaseValue,
    uint MaxBaseValue,
    StatType StatType
);

