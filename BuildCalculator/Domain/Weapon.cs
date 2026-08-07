using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct Weapon(
    ushort NameId,
    byte TypeId,
    Rarity Rarity
);

