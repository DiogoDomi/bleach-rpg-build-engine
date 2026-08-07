namespace BuildCalculator.Domain;

public readonly record struct Item(
    byte Id,
    byte NameId,
    byte CategoryId,
    byte TypeId
);

