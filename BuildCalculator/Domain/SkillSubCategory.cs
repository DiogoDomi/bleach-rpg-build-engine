namespace BuildCalculator.Domain;

public readonly record struct SkillSubCategory(
    string Name,
    byte CategoryId,
    byte DisplayOrder
);

