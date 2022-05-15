using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTailWhip : PokeMove, I_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => -1;

    public MoveTailWhip()
        : base("Tail Whip",
               MoveClass.Status,
               null, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}