namespace Pokedex.Enums;

[Flags]
public enum Stat
{
    HP = 1 << 0,
    Attack = 1 << 1,
    Defense = 1 << 2,
    SpecialAttack = 1 << 3,
    SpecialDefense = 1 << 4,
    Speed = 1 << 5,
}