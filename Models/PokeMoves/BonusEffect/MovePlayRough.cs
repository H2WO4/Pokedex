using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePlayRough : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
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

    public MovePlayRough()
        : base("Play Rough",
               MoveClass.Physical,
               90, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeFairy.Singleton) { }
}