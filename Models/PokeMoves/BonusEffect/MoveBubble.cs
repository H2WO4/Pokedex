using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBubble : PokeMove, IM_StatChangeBonus
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

    public MoveBubble()
        : base("Bubble",
               MoveClass.Special,
               40, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeWater.Singleton) { }
}