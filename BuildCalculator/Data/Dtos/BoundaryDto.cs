namespace BuildCalculator.Data.Dtos;

public readonly record struct BoundaryDto(
    ushort? SkillNameId,
    ushort Id,
    ushort CharacterId,
    byte? ImprovementValue,
    byte AscensionId,
    byte TypeId
);

