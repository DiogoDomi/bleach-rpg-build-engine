using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct CharacterDtoBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<byte, string> Affinities,
    IReadOnlyDictionary<byte, CharacterRoleDto> RoleDtos,
    IReadOnlyDictionary<byte, string> Factions,
    IReadOnlyDictionary<ushort, CharacterDto> CharacterDtos,
    IReadOnlyDictionary<ushort, CharacterBaseStatDto[]> BaseStatDtos
);

public static class CharacterRepositoryFactory
{
    public static ResultData<CharacterRepository> Create(CharacterDtoBag dtoBag)
    {
        var characters = dtoBag.CharacterDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => CharacterMapper.MapToCharacterDomain(kvp.Value));

        var roles = dtoBag.RoleDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => CharacterMapper.MapToRoleDomain(kvp.Value));

        var baseStats = dtoBag.BaseStatDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Select(
                dto => CharacterMapper.MapToBaseStatDomain(dto)).ToArray());

        var dataBag = new CharacterDataBag(
            dtoBag.Names,
            dtoBag.Affinities,
            roles,
            dtoBag.Factions,
            characters,
            baseStats);

        var repository = new CharacterRepository(dataBag);

        return ResultData<CharacterRepository>.Ok(repository);
    }
}

