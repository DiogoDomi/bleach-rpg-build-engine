using BuildCalculator.Domain;

namespace BuildCalculator.Data.Repositories;

public readonly record struct WeaponDataBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<byte, string> Types,
    IReadOnlyDictionary<ushort, Weapon> Weapons,
    IReadOnlyDictionary<ushort, WeaponBaseStat[]> BaseStats
);

public class WeaponRepository
{
    private readonly IReadOnlyDictionary<ushort, string> _names;
    private readonly IReadOnlyDictionary<byte, string> _types;
    private readonly IReadOnlyDictionary<ushort, Weapon> _weapons;
    private readonly IReadOnlyDictionary<ushort, WeaponBaseStat[]> _baseStats;

    public WeaponRepository(WeaponDataBag bag)
    {
        _names = bag.Names;
        _types = bag.Types;
        _weapons = bag.Weapons;
        _baseStats = bag.BaseStats;
    }

    public IReadOnlyDictionary<ushort, string> GetNames() => _names;
    public IReadOnlyDictionary<byte, string> GetTypes() => _types;
    public IReadOnlyDictionary<ushort, Weapon> GetWeapons() => _weapons;

    public bool TryGetName(ushort nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetType(byte typeId, out string? typeName)
    {
        if (typeId == 0)
        {
            typeName = default!;
            return false;
        }
        return _types.TryGetValue(typeId, out typeName);
    }

    public bool TryGetWeapon(ushort weaponId, out Weapon weapon)
    {
        if (weaponId == 0)
        {
            weapon = default!;
            return false;
        }
        return _weapons.TryGetValue(weaponId, out weapon);
    }

    public bool TryGetBaseStats(ushort weaponId, out WeaponBaseStat[]? baseStats)
    {
        if (weaponId == 0)
        {
            baseStats = default!;
            return false;
        }
        return _baseStats.TryGetValue(weaponId, out baseStats);
    }
}

