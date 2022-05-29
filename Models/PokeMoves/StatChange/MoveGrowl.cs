using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGrowl : PokeMove, IM_StatChange
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
            yield return -1;
        }
    }

    public MoveGrowl()
        : base("Growl",
               MoveClass.Status,
               null, 100, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }
}