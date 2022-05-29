using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSonicBoom : PokeMove, IM_SpecialDamage
{
    public MoveSonicBoom()
        : base("Sonic Boom",
               MoveClass.Special,
               null, 90, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public double CalculateDamage(I_Battler target)
        => 20;
}