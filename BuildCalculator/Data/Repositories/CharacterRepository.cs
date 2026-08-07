using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Repositories;

public readonly record struct CharacterDataBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<byte, string> Affinities,
    IReadOnlyDictionary<byte, CharacterRole> Roles,
    IReadOnlyDictionary<byte, string> Factions,
    IReadOnlyDictionary<ushort, Character> Characters,
    IReadOnlyDictionary<ushort, CharacterBaseStat[]> BaseStats
);

public class CharacterRepository
{
    private readonly IReadOnlyDictionary<ushort, string> _names;
    private readonly IReadOnlyDictionary<byte, string> _affinities;
    private readonly IReadOnlyDictionary<byte, CharacterRole> _roles;
    private readonly IReadOnlyDictionary<byte, string> _factions;
    private readonly IReadOnlyDictionary<ushort, Character> _characters;
    private readonly IReadOnlyDictionary<ushort, CharacterBaseStat[]> _baseStats;

    public CharacterRepository(CharacterDataBag bag)
    {
        _names = bag.Names;
        _affinities = bag.Affinities;
        _roles = bag.Roles;
        _factions = bag.Factions;
        _characters = bag.Characters;
        _baseStats = bag.BaseStats;
    }

    public IReadOnlyDictionary<ushort, string> GetNames() => _names;
    public IReadOnlyDictionary<byte, string> GetAffinities() => _affinities;
    public IReadOnlyDictionary<byte, CharacterRole> GetRoles() => _roles;
    public IReadOnlyDictionary<byte, string> GetFactions() => _factions;
    public IReadOnlyDictionary<ushort, Character> GetCharacters() => _characters;

    public bool TryGetName(ushort nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetAffinity(CharacterAffinity affinity, out string? affinityName)
    {
        byte affinityId = (byte)affinity;
        if (affinityId == 0)
        {
            affinityName = default!;
            return false;
        }
        return _affinities.TryGetValue(affinityId, out affinityName);
    }

    public bool TryGetRole(byte roleId, out CharacterRole role)
    {
        if (roleId == 0)
        {
            role = default!;
            return false;
        }
        return _roles.TryGetValue(roleId, out role);
    }

    public bool TryGetFaction(byte factionId, out string? factionName)
    {
        if (factionId == 0)
        {
            factionName = default!;
            return false;
        }
        return _factions.TryGetValue(factionId, out factionName);
    }

    public bool TryGetCharacter(ushort characterId, out Character character)
    {
        if (characterId == 0)
        {
            character = default!;
            return false;
        }
        return _characters.TryGetValue(characterId, out character);
    }

    public bool TryGetBaseStats(ushort characterId, out CharacterBaseStat[]? baseStats)
    {
        if (characterId == 0)
        {
            baseStats = default!;
            return false;
        }
        return _baseStats.TryGetValue(characterId, out baseStats);
    }
}

