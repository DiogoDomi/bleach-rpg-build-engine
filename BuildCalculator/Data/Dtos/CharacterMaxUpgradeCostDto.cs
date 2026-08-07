namespace BuildCalculator.Data.Dtos;

public readonly record struct CharacterMaxUpgradeCostDto(
    uint Amount,
    byte? RoleId,
    byte? AffinityId,
    byte Id,
    byte RarityId,
    byte ItemId
);

