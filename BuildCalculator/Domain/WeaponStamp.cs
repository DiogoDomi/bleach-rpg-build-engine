using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct WeaponStamp(
    ushort? ExclusiveEffectCharacterId,
    ushort Id,
    ushort NameId,
    ushort DisplayOrder,
    Rarity Rarity,
    byte StatsMultiplierValue
);

