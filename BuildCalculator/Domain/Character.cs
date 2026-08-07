using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct Character(
    ushort Id,
    ushort NameId,
    ushort DisplayOrder,
    CharacterAffinity Affinity,
    byte RoleId,
    byte FactionId,
    Rarity Rarity
);

