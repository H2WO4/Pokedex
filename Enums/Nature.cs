namespace Pokedex.Enums;

/// <summary>
///     Represents the natures a Pokemon can possess
/// </summary>
/// <remarks>Each valid value is the association of 2 flags</remarks>
[Flags]
public enum Nature
{
    #region Stat Flags
    // Stat Bonuses
    PlusAtk = 1 << 0,
    PlusDef = 1 << 1,
    PlusSpAtk = 1 << 2,
    PlusSpDef = 1 << 3,
    PlusSpd = 1 << 4,

    // Stat Minuses
    MinusAtk = 1 << 5,
    MinusDef = 1 << 6,
    MinusSpAtk = 1 << 7,
    MinusSpDef = 1 << 8,
    MinusSpd = 1 << 9,
    #endregion

    // Neutral
    Hardy = PlusAtk | MinusAtk,
    Docile = PlusDef | MinusDef,
    Bashful = PlusSpAtk | MinusSpAtk,
    Quirky = PlusSpDef | MinusSpDef,
    Serious = PlusSpd | MinusSpd,

    // Atk+
    Lonely = PlusAtk | MinusDef,
    Adamant = PlusAtk | MinusSpAtk,
    Naughty = PlusAtk | MinusSpDef,
    Brave = PlusAtk | MinusSpd,

    // Def+
    Bold = PlusDef | MinusAtk,
    Impish = PlusDef | MinusSpAtk,
    Lax = PlusDef | MinusSpDef,
    Relaxed = PlusDef | MinusSpd,

    // SpAtk+
    Modest = PlusSpAtk | MinusAtk,
    Mild = PlusSpAtk | MinusDef,
    Rash = PlusSpAtk | MinusSpDef,
    Quiet = PlusSpAtk | MinusSpd,

    // SpDef+
    Calm = PlusSpDef | MinusAtk,
    Gentle = PlusSpDef | MinusDef,
    Careful = PlusSpDef | MinusSpAtk,
    Sassy = PlusSpDef | MinusSpd,

    // Spd+
    Timid = PlusSpd | MinusAtk,
    Hasty = PlusSpd | MinusDef,
    Jolly = PlusSpd | MinusSpAtk,
    Naive = PlusSpd | MinusSpDef,
}