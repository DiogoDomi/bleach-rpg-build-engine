using BuildCalculator.Core;
using BuildCalculator.Data.Repositories;
using BuildCalculator.Data.Parsers.Loaders.Csv;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Builders.Csv;
using BuildCalculator.Data.Factories;

namespace BuildCalculator.Data.Parsers.Loaders.Csv;

public static class CsvItemLoader
{
    public static ResultData<ItemRepository> LoadRepository(string csvDirPath)
    {
        var nameData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "item_names.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!nameData.IsSuccess)
            return ResultData<ItemRepository>.Fail(nameData.Error,
                $"[LoadItemRepository] (nameData) Failed to load names -> {nameData.Message}");

        var categoryData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "item_categories.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!categoryData.IsSuccess)
            return ResultData<ItemRepository>.Fail(categoryData.Error,
                $"[LoadItemRepository] (categoryData) Failed to load categories -> {categoryData.Message}");

        var typeData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "item_types.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!typeData.IsSuccess)
            return ResultData<ItemRepository>.Fail(typeData.Error,
                $"[LoadItemRepository] (typeData) Failed to load types -> {typeData.Message}");

        var itemData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "items.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, ItemDto>(
                reader, CsvItemBuilder.BuildItemDto));

        if (!itemData.IsSuccess)
            return ResultData<ItemRepository>.Fail(itemData.Error,
                $"[LoadItemRepository] (itemData) Failed to load items -> {itemData.Message}");

        var descriptionData = CsvSharedLoaders.ExecuteLoader(csvDirPath, "item_descriptions.csv",
            reader => CsvSharedLoaders.LoadSingleDomainData<byte, string>(
                reader, CsvSharedBuilders.BuildIdAndText<byte>));

        if (!descriptionData.IsSuccess)
            return ResultData<ItemRepository>.Fail(descriptionData.Error,
                $"[LoadItemRepository] (descriptionData) Failed to load descriptions -> {descriptionData.Message}");

        var dtoBag = new ItemDtoBag(
            nameData.Item,
            categoryData.Item,
            typeData.Item,
            itemData.Item,
            descriptionData.Item
        );

        return ItemRepositoryFactory.Create(dtoBag);
    }
}

