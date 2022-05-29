using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveQuiverDance : PokeMove, IM_StatChange, IM_TargetSelf
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialAttack;
            yield return Stat.SpecialDefense;
            yield return Stat.Speed;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return 1;
            yield return 1;
            yield return 1;
        }
    }

    public MoveQuiverDance()
        : base("Quiver Dance",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeBug.Singleton) { }
}