using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFrenzyPlant : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MoveFrenzyPlant()
        : base("Frenzy Plant",
               MoveClass.Special,
               150, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeGrass.Singleton) { }
}