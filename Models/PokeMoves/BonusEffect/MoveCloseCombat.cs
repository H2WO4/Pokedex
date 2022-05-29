using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCloseCombat : PokeMove, IM_StatChangeBonusUser
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
            yield return -1;
            yield return -1;
        }
    }

    public int EffectChance
        => 100;

    public MoveCloseCombat()
        : base("Close Combat",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeFighting.Singleton) { }
}