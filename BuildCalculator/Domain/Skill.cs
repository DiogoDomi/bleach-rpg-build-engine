namespace BuildCalculator.Domain;

public readonly record struct Skill(
    ushort Id,
    ushort NameId,
    byte SubCategoryId,
    byte DisplayOrder
);

