using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTailWhip : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Defense;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -1;
        }
    }

    public MoveTailWhip()
        : base("Tail Whip",
               MoveClass.Status,
               null, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}