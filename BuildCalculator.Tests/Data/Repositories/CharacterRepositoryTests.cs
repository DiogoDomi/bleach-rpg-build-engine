using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class CharacterRepositoryTests
{
    private CharacterRepository GetFakeRepository(
        IReadOnlyDictionary<ushort, string>? names = null,
        IReadOnlyDictionary<byte, string>? affinities = null,
        IReadOnlyDictionary<byte, CharacterRole>? roles = null,
        IReadOnlyDictionary<byte, string>? factions = null,
        IReadOnlyDictionary<ushort, Character>? characters = null,
        IReadOnlyDictionary<ushort, CharacterBaseStat[]>? baseStats = null)
    {
        var bag = new CharacterDataBag(
            names ?? new Dictionary<ushort, string>(),
            affinities ?? new Dictionary<byte, string>(),
            roles ?? new Dictionary<byte, CharacterRole>(),
            factions ?? new Dictionary<byte, string>(),
            characters ?? new Dictionary<ushort, Character>(),
            baseStats ?? new Dictionary<ushort, CharacterBaseStat[]>()
        );

        return new CharacterRepository(bag);
    }

    private IReadOnlyDictionary<ushort, string> GetFakeNames() => new Dictionary<ushort, string>
    {
        [1] = "Byakuya Kuchiki",
        [2] = "Byakuya Kuchiki"
    };

    private IReadOnlyDictionary<byte, string> GetFakeAffinities() => new Dictionary<byte, string>
    {
        [1] = "Slash",
        [2] = "Slash"
    };

    private IReadOnlyDictionary<byte, CharacterRole> GetFakeRoles() => new Dictionary<byte, CharacterRole>
    {
        [1] = new CharacterRole("Tactic","A team-oriented character with unique Battlefield Skills, capable of dealing serious damage in the backline by working with other teammates."),
        [2] = new CharacterRole("Tactic","A team-oriented character with unique Battlefield Skills, capable of dealing serious damage in the backline by working with other teammates."),
    };

    private IReadOnlyDictionary<byte, string> GetFakeFactions() => new Dictionary<byte, string>
    {
        [1] = "Shinigami",
        [2] = "Shinigami"
    };

    private IReadOnlyDictionary<ushort, Character> GetFakeCharacters() => new Dictionary<ushort, Character>
    {
        [1] = new Character(1, 1, 102, CharacterAffinity.Slash, 1, 1, Rarity.Ssr),
        [2] = new Character(2, 1, 102, CharacterAffinity.Slash, 1, 1, Rarity.Ssr)
    };

    private IReadOnlyDictionary<ushort, CharacterBaseStat[]> GetFakeBaseStats() => new Dictionary<ushort, CharacterBaseStat[]>
    {
        [1] = [new CharacterBaseStat(6288, 1048, StatType.HpFlat)],
        [2] = [new CharacterBaseStat(null, 1048, StatType.HpFlat)]
    };

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetName_IdIsValid_ReturnsTrueAndName(ushort nameId)
    {
        var fakeNames = GetFakeNames();
        var repo = GetFakeRepository(names: fakeNames);

        var result = repo.TryGetName(nameId, out var name);

        Assert.True(result);
        Assert.Equal(fakeNames[nameId], name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetName_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort nameId)
    {
        var fakeNames = GetFakeNames();
        var repo = GetFakeRepository(names: fakeNames);

        var result = repo.TryGetName(nameId, out var name);

        Assert.False(result);
        Assert.Null(name);
    }

    [Theory]
    [InlineData((CharacterAffinity)1)]
    [InlineData((CharacterAffinity)2)]
    public void TryGetAffinity_EnumIsValid_ReturnsTrueAndName(CharacterAffinity affinity)
    {
        var fakeAffinities = GetFakeAffinities();
        var repo = GetFakeRepository(affinities: fakeAffinities);

        var result = repo.TryGetAffinity(affinity, out var affinityName);

        Assert.True(result);
        Assert.Equal(fakeAffinities[(byte)affinity], affinityName);
    }

    [Theory]
    [InlineData((CharacterAffinity)0)]
    [InlineData((CharacterAffinity)3)]
    public void TryGetAffinity_EnumIsInvalidOrNotFound_ReturnsFalseAndNull(CharacterAffinity affinity)
    {
        var fakeAffinities = GetFakeAffinities();
        var repo = GetFakeRepository(affinities: fakeAffinities);

        var result = repo.TryGetAffinity(affinity, out var affinityName);

        Assert.False(result);
        Assert.Null(affinityName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetRole_IdIsValid_ReturnsTrueAndRole(byte roleId)
    {
        var fakeRoles = GetFakeRoles();
        var repo = GetFakeRepository(roles: fakeRoles);

        var result = repo.TryGetRole(roleId, out var role);

        Assert.True(result);
        Assert.Equal(fakeRoles[roleId], role);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetRole_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(byte roleId)
    {
        var fakeRoles = GetFakeRoles();
        var repo = GetFakeRepository(roles: fakeRoles);

        var result = repo.TryGetRole(roleId, out var role);

        Assert.False(result);
        Assert.Equal(default(CharacterRole), role);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetFaction_IdIsValid_ReturnsTrueAndFaction(byte factionId)
    {
        var fakeFactions = GetFakeFactions();
        var repo = GetFakeRepository(factions: fakeFactions);

        var result = repo.TryGetFaction(factionId, out var faction);

        Assert.True(result);
        Assert.Equal(fakeFactions[factionId], faction);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetFaction_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte factionId)
    {
        var fakeFactions = GetFakeFactions();
        var repo = GetFakeRepository(factions: fakeFactions);

        var result = repo.TryGetFaction(factionId, out var faction);

        Assert.False(result);
        Assert.Null(faction);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetCharacter_IdIsValid_ReturnsTrueAndCharacter(ushort characterId)
    {
        var fakeCharacters = GetFakeCharacters();
        var repo = GetFakeRepository(characters: fakeCharacters);

        var result = repo.TryGetCharacter(characterId, out var character);

        Assert.True(result);
        Assert.Equal(fakeCharacters[characterId], character);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetCharacter_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(ushort characterId)
    {
        var fakeCharacters = GetFakeCharacters();
        var repo = GetFakeRepository(characters: fakeCharacters);

        var result = repo.TryGetCharacter(characterId, out var character);

        Assert.False(result);
        Assert.Equal(default(Character), character);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetBaseStats_IdIsValid_ReturnsTrueAndBaseStats(ushort characterId)
    {
        var fakeBaseStats = GetFakeBaseStats();
        var repo = GetFakeRepository(baseStats: fakeBaseStats);

        var result = repo.TryGetBaseStats(characterId, out var baseStats);

        Assert.True(result);
        Assert.Equal(fakeBaseStats[characterId], baseStats);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetBaseStats_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort characterId)
    {
        var fakeBaseStats = GetFakeBaseStats();
        var repo = GetFakeRepository(baseStats: fakeBaseStats);

        var result = repo.TryGetBaseStats(characterId, out var baseStats);

        Assert.False(result);
        Assert.Null(baseStats);
    }
}
