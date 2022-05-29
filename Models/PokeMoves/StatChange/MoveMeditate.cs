using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMeditate : PokeMove, IM_StatChange, IM_TargetSelf
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
            yield return 1;
        }
    }

    public MoveMeditate()
        : base("Meditate",
               MoveClass.Status,
               null, null, // Pow & Acc
               40, 0, // PP & Priority
               TypePsychic.Singleton) { }
}