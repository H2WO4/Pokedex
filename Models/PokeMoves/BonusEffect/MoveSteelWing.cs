using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSteelWing : PokeMove, IM_StatChangeBonusUser
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

    public int EffectChance
        => 10;

    public MoveSteelWing()
        : base("Steel Wing",
               MoveClass.Physical,
               70, 90, // Pow & Acc
               25, 0, // PP & Priority
               TypeSteel.Singleton) { }
}