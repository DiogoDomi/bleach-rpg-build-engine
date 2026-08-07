namespace BuildCalculator.Data.Dtos;

public readonly record struct LimitedGachaGuaranteedPullCostDto(
    ushort Amount,
    byte EntityTypeId,
    byte ItemId
);

