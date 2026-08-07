using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class WeaponStampMapper
{
    public static WeaponStamp MapToWeaponStampDomain(WeaponStampDto dto)
    {
        return new WeaponStamp(
            dto.ExclusiveEffectCharacterId,
            dto.Id,
            dto.NameId,
            dto.DisplayOrder,
            (Rarity)dto.RarityId,
            dto.StatsMultiplierValue);
    }
}

