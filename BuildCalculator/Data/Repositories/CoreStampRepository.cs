using BuildCalculator.Domain;

namespace BuildCalculator.Data.Repositories;

public readonly record struct CoreStampDataBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<ushort, CoreStamp> CoreStamps,
    IReadOnlyDictionary<ushort, string> Templates,
    IReadOnlyDictionary<ushort, CoreStampBaseStat[]> BaseStats
);

public class CoreStampRepository
{
    private readonly IReadOnlyDictionary<ushort, string> _names;
    private readonly IReadOnlyDictionary<ushort, CoreStamp> _coreStamps;
    private readonly IReadOnlyDictionary<ushort, string> _templates;
    private readonly IReadOnlyDictionary<ushort, CoreStampBaseStat[]> _baseStats;

    public CoreStampRepository(CoreStampDataBag bag)
    {
        _names = bag.Names;
        _coreStamps = bag.CoreStamps;
        _templates = bag.Templates;
        _baseStats = bag.BaseStats;
    }

    public IReadOnlyDictionary<ushort, string> GetNames() => _names;
    public IReadOnlyDictionary<ushort, CoreStamp> GetCoreStamps() => _coreStamps;
    public IReadOnlyDictionary<ushort, string> GetTemplates() => _templates;
    public IReadOnlyDictionary<ushort, CoreStampBaseStat[]> GetAllBaseStats() => _baseStats;

    public bool TryGetName(ushort nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetCoreStamp(ushort coreStampId, out CoreStamp coreStamp)
    {
        if (coreStampId == 0)
        {
            coreStamp = default!;
            return false;
        }
        return _coreStamps.TryGetValue(coreStampId, out coreStamp);
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

    public bool TryGetBaseStats(ushort coreStampId, out CoreStampBaseStat[]? baseStats)
    {
        if (coreStampId == 0)
        {
            baseStats = default!;
            return false;
        }
        return _baseStats.TryGetValue(coreStampId, out baseStats);
    }
}

