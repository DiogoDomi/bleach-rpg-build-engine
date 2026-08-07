using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct WeaponBaseStat(
    ushort MinBaseValue,
    ushort MaxBaseValue,
    StatType StatType
);

