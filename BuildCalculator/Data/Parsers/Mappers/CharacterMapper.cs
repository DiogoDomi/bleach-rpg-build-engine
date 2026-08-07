using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class CharacterMapper
{
    public static CharacterRole MapToRoleDomain(CharacterRoleDto dto)
    {
        return new CharacterRole(dto.Name, dto.Description);
    }

    public static Character MapToCharacterDomain(CharacterDto dto)
    {
        return new Character(
            dto.Id,
            dto.NameId,
            dto.DisplayOrder,
            (CharacterAffinity)dto.AffinityId,
            dto.RoleId,
            dto.FactionId,
            (Rarity)dto.RarityId);
    }

    public static CharacterBaseStat MapToBaseStatDomain(CharacterBaseStatDto dto)
    {
        return new CharacterBaseStat(
            dto.MaxBaseValue,
            dto.MinBaseValue,
            (StatType)dto.StatTypeId);
    }
}

