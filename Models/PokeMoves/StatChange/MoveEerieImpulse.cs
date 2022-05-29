using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveEerieImpulse : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialAttack;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -2;
        }
    }

    public MoveEerieImpulse()
        : base("Eerie Impulse",
               MoveClass.Status,
               null, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}