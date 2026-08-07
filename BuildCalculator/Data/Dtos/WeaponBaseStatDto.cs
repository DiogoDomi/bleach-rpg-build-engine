namespace BuildCalculator.Data.Dtos;

public readonly record struct WeaponBaseStatDto(
    ushort CharacterId,
    ushort MinBaseValue,
    ushort MaxBaseValue,
    byte StatTypeId
);

