using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveChargeBeam : PokeMove, IM_StatChangeBonusUser
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
            yield return 1;
        }
    }

    public int EffectChance
        => 70;

    public MoveChargeBeam()
        : base("Charge Beam",
               MoveClass.Special,
               50, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeElectric.Singleton) { }
}