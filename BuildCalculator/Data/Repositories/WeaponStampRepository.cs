using BuildCalculator.Domain;

namespace BuildCalculator.Data.Repositories;

public readonly record struct WeaponStampDataBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<ushort, WeaponStamp> WeaponStamps,
    IReadOnlyDictionary<ushort, string> Templates
);

public class WeaponStampRepository
{
    private readonly IReadOnlyDictionary<ushort, string> _names;
    private readonly IReadOnlyDictionary<ushort, WeaponStamp> _weaponStamps;
    private readonly IReadOnlyDictionary<ushort, string> _templates;

    public WeaponStampRepository(WeaponStampDataBag bag)
    {
        _names = bag.Names;
        _weaponStamps = bag.WeaponStamps;
        _templates = bag.Templates;
    }

    public IReadOnlyDictionary<ushort, string> GetNames() => _names;
    public IReadOnlyDictionary<ushort, WeaponStamp> GetWeaponStamps() => _weaponStamps;
    public IReadOnlyDictionary<ushort, string> GetTemplates() => _templates;

    public bool TryGetName(ushort nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetWeaponStamp(ushort weaponStampId, out WeaponStamp weaponStamp)
    {
        if (weaponStampId == 0)
        {
            weaponStamp = default!;
            return false;
        }
        return _weaponStamps.TryGetValue(weaponStampId, out weaponStamp);
    }

    public bool TryGetTemplate(ushort templateId, out string? template)
    {
        if (templateId == 0)
        {
            template = default!;
            return false;
        }
        return _templates.TryGetValue(templateId, out template);
    }
}

