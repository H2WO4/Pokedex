using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHarden : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => +1;

    public MoveHarden()
        : base("Harden",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}