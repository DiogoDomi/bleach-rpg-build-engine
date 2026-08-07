using BuildCalculator.Data.Dtos;
using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Data.Factories;

public readonly record struct ItemDtoBag(
    IReadOnlyDictionary<byte, string> Names,
    IReadOnlyDictionary<byte, string> Categories,
    IReadOnlyDictionary<byte, string> Types,
    IReadOnlyDictionary<byte, ItemDto> ItemDtos,
    IReadOnlyDictionary<byte, string> Descriptions
);

public static class ItemRepositoryFactory
{
    public static ResultData<ItemRepository> Create(ItemDtoBag dtoBag)
    {
        var items = dtoBag.ItemDtos.ToDictionary(
            kvp => kvp.Key,
            kvp => ItemMapper.MapToItemDomain(kvp.Value));

        var dataBag = new ItemDataBag(
            dtoBag.Names,
            dtoBag.Categories,
            dtoBag.Types,
            items,
            dtoBag.Descriptions
        );

        var repository = new ItemRepository(dataBag);

        return ResultData<ItemRepository>.Ok(repository);
    }
}

