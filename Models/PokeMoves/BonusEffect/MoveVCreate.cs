using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveVCreate : PokeMove, IM_StatChangeBonusUser
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Defense;
            yield return Stat.SpecialDefense;
            yield return Stat.Speed;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -1;
            yield return -1;
            yield return -1;
        }
    }

    public int EffectChance
        => 100;

    public MoveVCreate()
        : base("V Create",
               MoveClass.Physical,
               180, 95, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}