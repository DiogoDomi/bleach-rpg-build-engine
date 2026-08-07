using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class CoreStampMapper
{
    private const byte ScalingFactor = 100;

    public static CoreStamp MapToCoreStampDomain(CoreStampDto dto)
    {
        return new CoreStamp(
            dto.ExclusiveEffectCharacterId,
            dto.Id,
            dto.NameId,
            dto.DisplayOrder,
            (Rarity)dto.RarityId,
            (StarRating)dto.StarRatingId);
    }

    public static CoreStampBaseStat MapToBaseStatDomain(CoreStampBaseStatDto dto)
    {
        return new CoreStampBaseStat(
            (uint)Math.Round(dto.MinBaseValue * ScalingFactor),
            (uint)Math.Round(dto.MaxBaseValue * ScalingFactor),
            (StatType)dto.StatTypeId);
    }
}

