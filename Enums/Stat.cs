namespace Pokedex.Enums;

[Flags]
public enum Stat
{
    HP = 1 << 0,
    Atk = 1 << 1,
    Def = 1 << 2,
    SpAtk = 1 << 3,
    SpDef = 1 << 4,
    Spd = 1 << 5,
}