using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct CoreStampBaseStat(
    uint MinBaseValue,
    uint MaxBaseValue,
    StatType StatType
);

