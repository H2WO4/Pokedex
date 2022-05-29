using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAuroraBeam : PokeMove, IM_StatChangeBonus
{
    public Stat StatToChange
        => Stat.Atk;

    public int ChangeValue
        => -1;

    public int EffectChance
        => 10;

    public MoveAuroraBeam()
        : base("Aurora Beam",
               MoveClass.Special,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeIce.Singleton) { }
}