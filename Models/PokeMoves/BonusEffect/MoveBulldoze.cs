using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBulldoze : PokeMove, IM_StatChangeBonus
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
        => 100;

    public MoveBulldoze()
        : base("Bulldoze",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeGround.Singleton) { }
}