using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSwordsDance : PokeMove, IM_StatChange, IM_TargetSelf
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
            yield return 2;
        }
    }

    public MoveSwordsDance()
        : base("Swords Dance",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}