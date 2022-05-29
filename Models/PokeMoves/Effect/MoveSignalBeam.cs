using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSignalBeam : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 10;

    public MoveSignalBeam()
        : base("Signal Beam",
               MoveClass.Special,
               75, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeBug.Singleton) { }
}