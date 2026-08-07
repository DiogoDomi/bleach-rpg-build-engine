namespace BuildCalculator.Data.Dtos;

public readonly record struct ItemDto(
    byte Id,
    byte NameId,
    byte CategoryId,
    byte TypeId
);

