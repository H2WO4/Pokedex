using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveExtremeEvoboost : PokeMove, IM_StatChange, IM_TargetSelf
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
            yield return Stat.Defense;
            yield return Stat.SpecialAttack;
            yield return Stat.SpecialDefense;
            yield return Stat.Speed;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return 2;
            yield return 2;
            yield return 2;
            yield return 2;
            yield return 2;
        }
    }

    public MoveExtremeEvoboost()
        : base("Extreme Evoboost",
               MoveClass.Status,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeNormal.Singleton) { }
}