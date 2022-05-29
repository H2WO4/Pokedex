using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMoonblast : PokeMove, IM_StatChangeBonus
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
        => 30;

    public MoveMoonblast()
        : base("Moonblast",
               MoveClass.Special,
               95, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFairy.Singleton) { }
}