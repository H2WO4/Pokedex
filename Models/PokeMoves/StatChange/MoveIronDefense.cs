using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveIronDefense : PokeMove, IM_StatChange, IM_TargetSelf
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
            yield return 2;
        }
    }

    public MoveIronDefense()
        : base("Iron Defense",
               MoveClass.Status,
               null, null, // Pow & Acc
               15, 0, // PP & Priority
               TypeSteel.Singleton) { }
}