using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCharm : PokeMove, IM_StatChange
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

    public MoveCharm()
        : base("Charm",
               MoveClass.Status,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFairy.Singleton) { }
}