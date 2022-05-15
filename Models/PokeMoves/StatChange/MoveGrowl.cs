using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGrowl : PokeMove, IM_StatChange
{
    public Stat StatToChange
        => Stat.Atk;

    public int ChangeValue
        => -1;

    public MoveGrowl()
        : base("Growl",
               MoveClass.Status,
               null, 100, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }
}