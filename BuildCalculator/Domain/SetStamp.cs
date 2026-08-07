namespace BuildCalculator.Domain;

public readonly record struct SetStamp(
    ushort Id,
    ushort NameId,
    ushort DisplayOrder
);

