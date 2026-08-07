using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Domain;

public readonly record struct CoreStamp(
    ushort? ExclusiveEffectCharacterId,
    ushort Id,
    ushort NameId,
    ushort DisplayOrder,
    Rarity Rarity,
    StarRating StarRating
);

