using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShadowBall : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialDefense;
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

    public MoveShadowBall()
        : base("Shadow Ball",
               MoveClass.Special,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGhost.Singleton) { }
}