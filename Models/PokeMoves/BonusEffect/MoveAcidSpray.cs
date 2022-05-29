using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAcidSpray : PokeMove, IM_StatChangeBonus
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
        => 100;

    public MoveAcidSpray()
        : base("Acid Spray",
               MoveClass.Special,
               40, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}