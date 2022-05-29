using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSeedFlare : PokeMove, IM_StatChangeBonus
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
            yield return -2;
        }
    }

    public int EffectChance
        => 40;

    public MoveSeedFlare()
        : base("Seed Flare",
               MoveClass.Special,
               120, 85, // Pow & Acc
               5, 0, // PP & Priority
               TypeGrass.Singleton) { }
}