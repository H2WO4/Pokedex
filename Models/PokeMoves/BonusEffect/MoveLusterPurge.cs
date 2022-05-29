using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLusterPurge : PokeMove, IM_StatChangeBonus
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
        => 50;

    public MoveLusterPurge()
        : base("Luster Purge",
               MoveClass.Special,
               70, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypePsychic.Singleton) { }
}