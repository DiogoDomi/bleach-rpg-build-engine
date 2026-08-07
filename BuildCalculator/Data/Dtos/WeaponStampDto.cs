namespace BuildCalculator.Data.Dtos;

public readonly record struct WeaponStampDto(
    ushort? ExclusiveEffectCharacterId,
    ushort Id,
    ushort NameId,
    ushort DisplayOrder,
    byte RarityId,
    byte StatsMultiplierValue
);

