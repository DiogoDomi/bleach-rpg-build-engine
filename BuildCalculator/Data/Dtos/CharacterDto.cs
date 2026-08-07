namespace BuildCalculator.Data.Dtos;

public readonly record struct CharacterDto(
    ushort Id,
    ushort NameId,
    ushort DisplayOrder,
    byte AffinityId,
    byte RoleId,
    byte FactionId,
    byte RarityId
);

