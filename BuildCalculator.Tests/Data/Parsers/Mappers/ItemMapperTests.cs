using Xunit;
using BuildCalculator.Data.Dtos;
using BuildCalculator.Data.Parsers.Mappers;

namespace BuildCalculator.Tests.Data.Parsers.Mappers;

public class ItemMapperTests
{
    [Fact]
    public void MapToItemDomain_ValidDto_MapsCorrectly()
    {
        // Arrange
        var dto = new ItemDto(
            Id: (byte)10,
            NameId: (byte)25,
            CategoryId: (byte)50,
            TypeId: (byte)75
        );

        // Act
        var result = ItemMapper.MapToItemDomain(dto);

        // Assert
        Assert.Equal((byte)10, result.Id);
        Assert.Equal((byte)25, result.NameId);
        Assert.Equal((byte)50, result.CategoryId);
        Assert.Equal((byte)75, result.TypeId);
    }
}

