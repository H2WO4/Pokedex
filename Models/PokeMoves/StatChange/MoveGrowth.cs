using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGrowth : PokeMove, I_Self, I_MultipleStatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Atk;
            yield return Stat.SpAtk;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return +1;
            yield return +1;
        }
    }

    public MoveGrowth()
        : base("Growth",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}