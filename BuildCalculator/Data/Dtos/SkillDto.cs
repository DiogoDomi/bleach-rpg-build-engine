namespace BuildCalculator.Data.Dtos;

public readonly record struct SkillDto(
    ushort Id,
    ushort CharacterId,
    ushort NameId,
    byte SubCategoryId,
    byte DisplayOrder
);

