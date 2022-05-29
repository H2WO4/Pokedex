using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLiquidation : PokeMove, IM_StatChangeBonus
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
            yield return -1;
        }
    }

    public int EffectChance
        => 20;

    public MoveLiquidation()
        : base("Liquidation",
               MoveClass.Physical,
               85, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeWater.Singleton) { }
}