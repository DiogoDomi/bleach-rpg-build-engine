using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct CharacterBaseStat(
    ushort? MaxBaseValue,
    ushort MinBaseValue,
    StatType StatType
);

