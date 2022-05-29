using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAncientPower : PokeMove, IM_StatChangeBonusUser
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
            yield return 1;
            yield return 1;
            yield return 1;
            yield return 1;
            yield return 1;
        }
    }

    public int EffectChance
        => 10;

    public MoveAncientPower()
        : base("Ancient Power",
               MoveClass.Special,
               60, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeRock.Singleton) { }
}