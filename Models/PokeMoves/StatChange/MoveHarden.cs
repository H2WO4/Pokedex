using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHarden : PokeMove, IM_StatChange, IM_TargetSelf
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
            yield return 1;
        }
    }

    public MoveHarden()
        : base("Harden",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}