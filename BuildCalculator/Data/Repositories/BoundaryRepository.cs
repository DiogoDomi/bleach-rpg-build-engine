using BuildCalculator.Domain;

namespace BuildCalculator.Data.Repositories;

public readonly record struct BoundaryDataBag(
    IReadOnlyDictionary<byte, string> Ascensions,
    IReadOnlyDictionary<byte, string> Types,
    IReadOnlyDictionary<ushort, string> SkillNames,
    IReadOnlyDictionary<ushort, Boundary[]> Boundaries,
    IReadOnlyDictionary<ushort, string> Templates
);

public class BoundaryRepository
{
    private readonly IReadOnlyDictionary<byte, string> _ascensions;
    private readonly IReadOnlyDictionary<byte, string> _types;
    private readonly IReadOnlyDictionary<ushort, string> _skillNames;
    private readonly IReadOnlyDictionary<ushort, Boundary[]> _boundaries;
    private readonly IReadOnlyDictionary<ushort, string> _templates;

    public BoundaryRepository(BoundaryDataBag bag)
    {
        _ascensions = bag.Ascensions;
        _types = bag.Types;
        _skillNames = bag.SkillNames;
        _boundaries = bag.Boundaries;
        _templates = bag.Templates;
    }

    public IReadOnlyDictionary<byte, string> GetAscensions() => _ascensions;
    public IReadOnlyDictionary<byte, string> GetTypes() => _types;
    public IReadOnlyDictionary<ushort, string> GetSkillNames() => _skillNames;
    public IReadOnlyDictionary<ushort, Boundary[]> GetBoundaries() => _boundaries;
    public IReadOnlyDictionary<ushort, string> GetTemplates() => _templates;

    public bool TryGetAscension(byte ascensionId, out string? ascension)
    {
        if (ascensionId == 0)
        {
            ascension = default!;
            return false;
        }
        return _ascensions.TryGetValue(ascensionId, out ascension);
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

    public bool TryGetSkillName(ushort skillNameId, out string? skillName)
    {
        if (skillNameId == 0)
        {
            skillName = default!;
            return false;
        }
        return _skillNames.TryGetValue(skillNameId, out skillName);
    }

    public bool TryGetBoundaries(ushort key, out Boundary[]? boundaries)
    {
        if (key == 0)
        {
            boundaries = default!;
            return false;
        }
        return _boundaries.TryGetValue(key, out boundaries);
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

