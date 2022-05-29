using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePrismaticLaser : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MovePrismaticLaser()
        : base("Prismatic Laser",
               MoveClass.Special,
               160, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypePsychic.Singleton) { }
}