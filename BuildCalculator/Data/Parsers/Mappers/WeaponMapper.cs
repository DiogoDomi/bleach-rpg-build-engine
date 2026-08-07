using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class WeaponMapper
{
    public static Weapon MapToWeaponDomain(WeaponDto dto)
    {
        return new Weapon(
            dto.NameId,
            dto.TypeId,
            (Rarity)dto.RarityId);
    }

    public static WeaponBaseStat MapToBaseStatDomain(WeaponBaseStatDto dto)
    {
        return new WeaponBaseStat(
            dto.MinBaseValue,
            dto.MaxBaseValue,
            (StatType)dto.StatTypeId);
    }
}

