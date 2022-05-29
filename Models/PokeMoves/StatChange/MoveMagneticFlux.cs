using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMagneticFlux : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Defense;
            yield return Stat.SpecialDefense;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return 1;
            yield return 1;
        }
    }

    public MoveMagneticFlux()
        : base("Magnetic Flux",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}