using BuildCalculator.Data.Repositories;

namespace BuildCalculator.Data;

public record class GameData(
    LookupRepository LookupRepository,
    CharacterRepository CharacterRepository,
    WeaponRepository WeaponRepository,
    SkillRepository SkillRepository,
    BoundaryRepository BoundaryRepository,
    WeaponStampRepository WeaponStampRepository,
    CoreStampRepository CoreStampRepository,
    SetStampRepository SetStampRepository,
    ItemRepository ItemRepository,
    GameConfigRepository GameConfigRepository
);

