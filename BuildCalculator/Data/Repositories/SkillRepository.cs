using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Data.Repositories;

public readonly record struct SkillDataBag(
    IReadOnlyDictionary<ushort, string> Names,
    IReadOnlyDictionary<byte, SkillCategory> Categories,
    IReadOnlyDictionary<byte, SkillSubCategory> SubCategories,
    IReadOnlyDictionary<ushort, Skill[]> Skills,
    IReadOnlyDictionary<ushort, string> UseStates,
    IReadOnlyDictionary<ushort, string> Templates,
    IReadOnlyDictionary<byte, string> Tags,
    IReadOnlyDictionary<ushort, byte> TagMapping
);

public class SkillRepository
{
    private readonly IReadOnlyDictionary<ushort, string> _names;
    private readonly IReadOnlyDictionary<byte, SkillCategory> _categories;
    private readonly IReadOnlyDictionary<byte, SkillSubCategory> _subCategories;
    private readonly IReadOnlyDictionary<ushort, Skill[]> _skills;
    private readonly IReadOnlyDictionary<ushort, string> _useStates;
    private readonly IReadOnlyDictionary<ushort, string> _templates;
    private readonly IReadOnlyDictionary<byte, string> _tags;
    private readonly IReadOnlyDictionary<ushort, byte> _tagMapping;

    public SkillRepository(SkillDataBag bag)
    {
        _skills = bag.Skills;
        _categories = bag.Categories;
        _subCategories = bag.SubCategories;
        _names = bag.Names;
        _useStates = bag.UseStates;
        _templates = bag.Templates;
        _tags = bag.Tags;
        _tagMapping = bag.TagMapping;
    }

    public IReadOnlyDictionary<ushort, string> GetNames() => _names;
    public IReadOnlyDictionary<byte, SkillCategory> GetCategories() => _categories;
    public IReadOnlyDictionary<byte, SkillSubCategory> GetSubCategories() => _subCategories;
    public IReadOnlyDictionary<ushort, Skill[]> GetSkills() => _skills;
    public IReadOnlyDictionary<ushort, string> GetUseStates() => _useStates;
    public IReadOnlyDictionary<ushort, string> GetTemplates() => _templates;
    public IReadOnlyDictionary<byte, string> GetTags() => _tags;
    public IReadOnlyDictionary<ushort, byte> GetTagMapping() => _tagMapping;

    public bool TryGetName(ushort nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetCategory(byte categoryId, out SkillCategory category)
    {
        if (categoryId == 0)
        {
            category = default!;
            return false;
        }
        return _categories.TryGetValue(categoryId, out category);
    }

    public bool TryGetSubCategory(byte subCategoryId, out SkillSubCategory subCategory)
    {
        if (subCategoryId == 0)
        {
            subCategory = default!;
            return false;
        }
        return _subCategories.TryGetValue(subCategoryId, out subCategory);
    }

    public bool TryGetSkills(ushort key, out Skill[]? skills)
    {
        if (key == 0)
        {
            skills = default!;
            return false;
        }
        return _skills.TryGetValue(key, out skills);
    }

    public bool TryGetUseState(ushort useStateId, out string? useState)
    {
        if (useStateId == 0)
        {
            useState = default!;
            return false;
        }
        return _useStates.TryGetValue(useStateId, out useState);
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

    public bool TryGetTag(byte tagId, out string? tag)
    {
        if (tagId == 0)
        {
            tag = default!;
            return false;
        }
        return _tags.TryGetValue(tagId, out tag);
    }

    public bool TryGetTagMapping(ushort key, out byte tagId)
    {
        if (key == 0)
        {
            tagId = default!;
            return false;
        }
        return _tagMapping.TryGetValue(key, out tagId);
    }
}
