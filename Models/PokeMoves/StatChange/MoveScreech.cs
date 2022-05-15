using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveScreech : PokeMove, IM_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => -2;

    public MoveScreech()
        : base("Screech",
               MoveClass.Status,
               null, 85, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }
}