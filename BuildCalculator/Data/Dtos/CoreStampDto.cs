namespace BuildCalculator.Data.Dtos;

public readonly record struct CoreStampDto(
    ushort? ExclusiveEffectCharacterId,
    ushort Id,
    ushort NameId,
    ushort DisplayOrder,
    byte RarityId,
    byte StarRatingId
);

