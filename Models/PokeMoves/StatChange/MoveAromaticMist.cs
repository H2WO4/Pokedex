using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAromaticMist : PokeMove, IM_StatChange
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
            yield return 1;
        }
    }

    public MoveAromaticMist()
        : base("Aromatic Mist",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeFairy.Singleton) { }
}