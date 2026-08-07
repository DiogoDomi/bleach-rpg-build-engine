using Xunit;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Domain;
using BuildCalculator.Domain.Enums;

namespace BuildCalculator.Tests.Data.Repositories;

public class SkillRepositoryTests
{
    private SkillRepository GetFakeRepository(
        IReadOnlyDictionary<ushort, string>? names = null,
        IReadOnlyDictionary<byte, SkillCategory>? categories = null,
        IReadOnlyDictionary<byte, SkillSubCategory>? subCategories = null,
        IReadOnlyDictionary<ushort, Skill[]>? skills = null,
        IReadOnlyDictionary<ushort, string>? useStates = null,
        IReadOnlyDictionary<ushort, string>? templates = null,
        IReadOnlyDictionary<byte, string>? tags = null,
        IReadOnlyDictionary<ushort, byte>? tagMapping = null)
    {
        var bag = new SkillDataBag(
            names ?? new Dictionary<ushort, string>(),
            categories ?? new Dictionary<byte, SkillCategory>(),
            subCategories ?? new Dictionary<byte, SkillSubCategory>(),
            skills ?? new Dictionary<ushort, Skill[]>(),
            useStates ?? new Dictionary<ushort, string>(),
            templates ?? new Dictionary<ushort, string>(),
            tags ?? new Dictionary<byte, string>(),
            tagMapping ?? new Dictionary<ushort, byte>()
        );

        return new SkillRepository(bag);
    }

    private IReadOnlyDictionary<ushort, string> GetFakeNames() => new Dictionary<ushort, string>
    {
        [1] = "Flash Step",
        [2] = "Flash Step"
    };

    private IReadOnlyDictionary<byte, SkillCategory> GetFakeCategories() => new Dictionary<byte, SkillCategory>
    {
        [1] = new SkillCategory("Dodge", 10),
        [2] = new SkillCategory("Dodge", 10)
    };

    private IReadOnlyDictionary<byte, SkillSubCategory> GetFakeSubCategories() => new Dictionary<byte, SkillSubCategory>
    {
        [1] = new SkillSubCategory("Dodge", 1, 10),
        [2] = new SkillSubCategory("Dodge", 1, 10)
    };

    private IReadOnlyDictionary<ushort, Skill[]> GetFakeSkills() => new Dictionary<ushort, Skill[]>
    {
        [1] = [new Skill(1, 1, 1, 1)],
        [2] = [new Skill(1, 1, 1, 1)]
    };

    private IReadOnlyDictionary<ushort, string> GetFakeUseStates() => new Dictionary<ushort, string>
    {
        [1] = "Bankai",
        [2] = "Bankai"
    };

    private IReadOnlyDictionary<ushort, string> GetFakeTemplates() => new Dictionary<ushort, string>
    {
        [1] = "Use Flash Step to avoid attacks right before they hit.",
        [2] = "Use Flash Step to avoid attacks right before they hit."
    };

    private IReadOnlyDictionary<byte, string> GetFakeTags() => new Dictionary<byte, string>
    {
        [1] = "Damage",
        [2] = "Damage"
    };

    private IReadOnlyDictionary<ushort, byte> GetFakeTagMapping() => new Dictionary<ushort, byte>
    {
        [3] = 1,
        [4] = 1 | 2 | 4
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
    public void TryGetCategory_IdIsValid_ReturnsTrueAndCategory(byte categoryId)
    {
        var fakeCategories = GetFakeCategories();
        var repo = GetFakeRepository(categories: fakeCategories);

        var result = repo.TryGetCategory(categoryId, out var category);

        Assert.True(result);
        Assert.Equal(fakeCategories[categoryId], category);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetCategory_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(byte categoryId)
    {
        var fakeCategories = GetFakeCategories();
        var repo = GetFakeRepository(categories: fakeCategories);

        var result = repo.TryGetCategory(categoryId, out var category);

        Assert.False(result);
        Assert.Equal(default(SkillCategory), category);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetSubCategory_IdIsValid_ReturnsTrueAndSubCategory(byte subCategoryId)
    {
        var fakeSubCategories = GetFakeSubCategories();
        var repo = GetFakeRepository(subCategories: fakeSubCategories);

        var result = repo.TryGetSubCategory(subCategoryId, out var subCategory);

        Assert.True(result);
        Assert.Equal(fakeSubCategories[subCategoryId], subCategory);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetSubCategory_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(byte subCategoryId)
    {
        var fakeSubCategories = GetFakeSubCategories();
        var repo = GetFakeRepository(subCategories: fakeSubCategories);

        var result = repo.TryGetSubCategory(subCategoryId, out var subCategory);

        Assert.False(result);
        Assert.Equal(default(SkillSubCategory), subCategory);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetSkills_IdIsValid_ReturnsTrueAndSkills(ushort key)
    {
        var fakeSkills = GetFakeSkills();
        var repo = GetFakeRepository(skills: fakeSkills);

        var result = repo.TryGetSkills(key, out var skills);

        Assert.True(result);
        Assert.Equal(fakeSkills[key], skills);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetSkills_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort key)
    {
        var fakeSkills = GetFakeSkills();
        var repo = GetFakeRepository(skills: fakeSkills);

        var result = repo.TryGetSkills(key, out var skills);

        Assert.False(result);
        Assert.Null(skills);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetUseState_IdIsValid_ReturnsTrueAndUseState(ushort useStateId)
    {
        var fakeUseStates = GetFakeUseStates();
        var repo = GetFakeRepository(useStates: fakeUseStates);

        var result = repo.TryGetUseState(useStateId, out var useState);

        Assert.True(result);
        Assert.Equal(fakeUseStates[useStateId], useState);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetUseState_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort useStateId)
    {
        var fakeUseStates = GetFakeUseStates();
        var repo = GetFakeRepository(useStates: fakeUseStates);

        var result = repo.TryGetUseState(useStateId, out var useState);

        Assert.False(result);
        Assert.Null(useState);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetTemplate_IdIsValid_ReturnsTrueAndTemplate(ushort templateId)
    {
        var fakeTemplates = GetFakeTemplates();
        var repo = GetFakeRepository(templates: fakeTemplates);

        var result = repo.TryGetTemplate(templateId, out var template);

        Assert.True(result);
        Assert.Equal(fakeTemplates[templateId], template);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetTemplate_IdIsInvalidOrNotFound_ReturnsFalseAndNull(ushort templateId)
    {
        var fakeTemplates = GetFakeTemplates();
        var repo = GetFakeRepository(templates: fakeTemplates);

        var result = repo.TryGetTemplate(templateId, out var template);

        Assert.False(result);
        Assert.Null(template);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void TryGetTag_IdIsValid_ReturnsTrueAndTag(byte tagId)
    {
        var fakeTags = GetFakeTags();
        var repo = GetFakeRepository(tags: fakeTags);

        var result = repo.TryGetTag(tagId, out var tag);

        Assert.True(result);
        Assert.Equal(fakeTags[tagId], tag);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void TryGetTag_IdIsInvalidOrNotFound_ReturnsFalseAndNull(byte tagId)
    {
        var fakeTags = GetFakeTags();
        var repo = GetFakeRepository(tags: fakeTags);

        var result = repo.TryGetTag(tagId, out var tag);

        Assert.False(result);
        Assert.Null(tag);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public void TryGetTagMapping_IdIsValid_ReturnsTrueAndTagId(ushort key)
    {
        var fakeTagMapping = GetFakeTagMapping();
        var repo = GetFakeRepository(tagMapping: fakeTagMapping);

        var result = repo.TryGetTagMapping(key, out var tagId);

        Assert.True(result);
        Assert.Equal(fakeTagMapping[key], tagId);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void TryGetTagMapping_IdIsInvalidOrNotFound_ReturnsFalseAndDefault(ushort key)
    {
        var fakeTagMapping = GetFakeTagMapping();
        var repo = GetFakeRepository(tagMapping: fakeTagMapping);

        var result = repo.TryGetTagMapping(key, out var tagId);

        Assert.False(result);
        Assert.Equal(default(byte), tagId);
    }
}

