using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFeatherDance : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -2;
        }
    }

    public MoveFeatherDance()
        : base("Feather Dance",
               MoveClass.Status,
               null, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFlying.Singleton) { }
}