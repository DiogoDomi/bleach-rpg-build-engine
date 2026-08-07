using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class ItemMapper
{
    public static Item MapToItemDomain(ItemDto dto)
    {
        return new Item(
            dto.Id,
            dto.NameId,
            dto.CategoryId,
            dto.TypeId
        );
    }
}

