using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSnarl : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialAttack;
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

    public MoveSnarl()
        : base("Snarl",
               MoveClass.Special,
               55, 95, // Pow & Acc
               15, 0, // PP & Priority
               TypeDark.Singleton) { }
}