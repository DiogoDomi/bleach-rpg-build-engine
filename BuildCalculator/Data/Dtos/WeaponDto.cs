namespace BuildCalculator.Data.Dtos;

public readonly record struct WeaponDto(
    ushort CharacterId,
    ushort NameId,
    byte TypeId,
    byte RarityId
);

