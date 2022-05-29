using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDragonRage : PokeMove, IM_SpecialDamage
{
    public MoveDragonRage()
        : base("Dragon Rage",
               MoveClass.Special,
               null, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeDragon.Singleton) { }

    public double CalculateDamage(I_Battler target)
        => 40;
}