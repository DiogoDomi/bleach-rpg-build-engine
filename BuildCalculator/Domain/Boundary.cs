namespace BuildCalculator.Domain;

public readonly record struct Boundary(
    ushort? SkillNameId,
    ushort Id,
    byte? ImprovementValue,
    byte AscensionId,
    byte TypeId
);

