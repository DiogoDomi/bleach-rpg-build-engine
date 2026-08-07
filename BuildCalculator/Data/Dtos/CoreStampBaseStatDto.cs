namespace BuildCalculator.Data.Dtos;

public readonly record struct CoreStampBaseStatDto(
    float MinBaseValue,
    float MaxBaseValue,
    ushort CoreStampId,
    byte StatTypeId
);

