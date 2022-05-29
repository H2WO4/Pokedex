using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBabyDollEyes : PokeMove, IM_StatChange
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

    public MoveBabyDollEyes()
        : base("Baby Doll Eyes",
               MoveClass.Status,
               null, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeFairy.Singleton) { }
}