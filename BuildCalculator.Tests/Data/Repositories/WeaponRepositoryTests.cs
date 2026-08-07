using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class WeaponRepositoryTests
{
    private WeaponRepository GetFakeRepository(
        IReadOnlyDictionary<ushort, string>? names = null,
        IReadOnlyDictionary<byte, string>? types = null,
        IReadOnlyDictionary<ushort, Weapon>? weapons = null,
        IReadOnlyDictionary<ushort, WeaponBaseStat[]>? baseStats = null)
    {

        var bag = new WeaponDataBag(
            names ?? new Dictionary<ushort, string>(),
            types ?? new Dictionary<byte, string>(),
            weapons ?? new Dictionary<ushort, Weapon>(),
            baseStats ?? new Dictionary<ushort, WeaponBaseStat[]>()
        );

        return new WeaponRepository(bag);
    }

    private IReadOnlyDictionary<ushort, string> GetFakeNames() => new Dictionary<ushort, string>
    {
        [1] = "Senbonzakura",
        [2] = "Senbonzakura"
    };

    private IReadOnlyDictionary<byte, string> GetFakeTypes() => new Dictionary<byte, string>
    {
        [1] = "Zanpakuto",
        [2] = "Zanpakuto"
    };

    private IReadOnlyDictionary<ushort, Weapon> GetFakeWeapons() => new Dictionary<ushort, Weapon>
    {
        [1] = new(1, 1, Rarity.Ssr),
        [2] = new(1, 1, Rarity.Ssr)
    };

    private IReadOnlyDictionary<ushort, WeaponBaseStat[]> GetFakeBaseStats() => new Dictionary<ushort, WeaponBaseStat[]>
    {
        [1] = [new(118, 594, StatType.HpFlat)],
        [2] = [new(118, 594, StatType.HpFlat)]
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
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetType_IdIsValid_ReturnsTrueAndType(byte typeId)
    {
        var fakeTypes = GetFakeTypes();
        var repo = GetFakeRepository(types: fakeTypes);

        var result = repo.TryGetType(typeId, out var typeName);

        Assert.True(result);
        Assert.Equal(fakeTypes[typeId], typeName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetType_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte typeId)
    {
        var fakeTypes = GetFakeTypes();
        var repo = GetFakeRepository(types: fakeTypes);

        var result = repo.TryGetType(typeId, out var typeName);

        Assert.False(result);
        Assert.Null(typeName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetWeapon_IdIsValid_ReturnsTrueAndWeapon(ushort weaponId)
    {
        var fakeWeapons = GetFakeWeapons();
        var repo = GetFakeRepository(weapons: fakeWeapons);

        var result = repo.TryGetWeapon(weaponId, out var weapon);

        Assert.True(result);
        Assert.Equal(fakeWeapons[weaponId], weapon);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetWeapon_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(ushort weaponId)
    {
        var fakeWeapons = GetFakeWeapons();
        var repo = GetFakeRepository(weapons: fakeWeapons);

        var result = repo.TryGetWeapon(weaponId, out var weapon);

        Assert.False(result);
        Assert.Equal(default(Weapon), weapon);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetBaseStats_IdIsValid_ReturnsTrueAndBaseStats(ushort weaponId)
    {
        var fakeBaseStats = GetFakeBaseStats();
        var repo = GetFakeRepository(baseStats: fakeBaseStats);

        var result = repo.TryGetBaseStats(weaponId, out var baseStats);

        Assert.True(result);
        Assert.Equal(fakeBaseStats[weaponId], baseStats);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetBaseStats_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort weaponId)
    {
        var fakeBaseStats = GetFakeBaseStats();
        var repo = GetFakeRepository(baseStats: fakeBaseStats);

        var result = repo.TryGetBaseStats(weaponId, out var baseStats);

        Assert.False(result);
        Assert.Null(baseStats);
    }
}

