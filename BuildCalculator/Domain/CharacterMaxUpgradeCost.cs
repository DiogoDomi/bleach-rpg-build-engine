using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct CharacterMaxUpgradeCost(
    uint Amount,
    byte? RoleId,
    CharacterAffinity? Affinity,
    Rarity Rarity,
    byte ItemId
);

