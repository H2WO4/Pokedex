using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAmnesia : PokeMove, IM_StatChange, IM_TargetSelf
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialDefense;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return 2;
        }
    }

    public MoveAmnesia()
        : base("Amnesia",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}