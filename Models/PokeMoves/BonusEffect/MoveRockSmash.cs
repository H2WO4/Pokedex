using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRockSmash : PokeMove, IM_StatChangeBonus
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
        => 50;

    public MoveRockSmash()
        : base("Rock Smash",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFighting.Singleton) { }
}