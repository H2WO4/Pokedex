using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBubbleBeam : PokeMove, IM_StatChangeBonus
{
    public Stat StatToChange
        => Stat.Spd;

    public int ChangeValue
        => -1;

    public int EffectChance
        => 10;
    
    public MoveBubbleBeam()
        : base("Bubble Beam",
               MoveClass.Special,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeWater.Singleton) { }
}