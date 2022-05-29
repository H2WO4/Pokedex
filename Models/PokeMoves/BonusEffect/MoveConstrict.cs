using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveConstrict : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Speed;
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
        => 10;

    public MoveConstrict()
        : base("Constrict",
               MoveClass.Physical,
               10, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeNormal.Singleton) { }
}