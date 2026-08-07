using BuildCalculator.Data.Dtos;
using BuildCalculator.Domain;

namespace BuildCalculator.Data.Parsers.Mappers;

public static class BoundaryMapper
{
    public static Boundary MapToBoundaryDomain(BoundaryDto dto)
    {
        return new Boundary(
            dto.SkillNameId,
            dto.Id,
            dto.ImprovementValue,
            dto.AscensionId,
            dto.TypeId);
    }
}

