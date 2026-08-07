namespace BuildCalculator.Data.Dtos;

public readonly record struct SkillSubCategoryDto(
    string Name,
    byte Id,
    byte CategoryId,
    byte DisplayOrder
);

