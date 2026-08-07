namespace BuildCalculator.Data.Dtos;

public readonly record struct CharacterBaseStatDto(
    ushort? MaxBaseValue,
    ushort MinBaseValue,
    ushort CharacterId,
    byte StatTypeId
);

