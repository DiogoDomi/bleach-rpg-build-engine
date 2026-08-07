using BuildCalculator.Domain;

namespace BuildCalculator.Data.Repositories;

public readonly record struct ItemDataBag(
    IReadOnlyDictionary<byte, string> Names,
    IReadOnlyDictionary<byte, string> Categories,
    IReadOnlyDictionary<byte, string> Types,
    IReadOnlyDictionary<byte, Item> Items,
    IReadOnlyDictionary<byte, string> Descriptions
);

public class ItemRepository
{
    private readonly IReadOnlyDictionary<byte, string> _names;
    private readonly IReadOnlyDictionary<byte, string> _categories;
    private readonly IReadOnlyDictionary<byte, string> _types;
    private readonly IReadOnlyDictionary<byte, Item> _items;
    private readonly IReadOnlyDictionary<byte, string> _descriptions;

    public ItemRepository(ItemDataBag bag)
    {
        _names = bag.Names;
        _categories = bag.Categories;
        _types = bag.Types;
        _items = bag.Items;
        _descriptions = bag.Descriptions;
    }

    public IReadOnlyDictionary<byte, string> GetNames() => _names;
    public IReadOnlyDictionary<byte, string> GetCategories() => _categories;
    public IReadOnlyDictionary<byte, string> GetTypes() => _types;
    public IReadOnlyDictionary<byte, Item> GetItems() => _items;
    public IReadOnlyDictionary<byte, string> GetDescriptions() => _descriptions;

    public bool TryGetName(byte nameId, out string? name)
    {
        if (nameId == 0)
        {
            name = default!;
            return false;
        }
        return _names.TryGetValue(nameId, out name);
    }

    public bool TryGetCategory(byte categoryId, out string? category)
    {
        if (categoryId == 0)
        {
            category = default!;
            return false;
        }
        return _categories.TryGetValue(categoryId, out category);
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

    public bool TryGetItem(byte itemId, out Item item)
    {
        if (itemId == 0)
        {
            item = default!;
            return false;
        }
        return _items.TryGetValue(itemId, out item);
    }

    public bool TryGetDescription(byte descriptionId, out string? description)
    {
        if (descriptionId == 0)
        {
            description = default!;
            return false;
        }
        return _descriptions.TryGetValue(descriptionId, out description);
    }
}

