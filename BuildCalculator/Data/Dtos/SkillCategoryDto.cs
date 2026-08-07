namespace BuildCalculator.Data.Dtos;

public readonly record struct SkillCategoryDto(
    string Name,
    byte Id,
    byte DisplayOrder
);

