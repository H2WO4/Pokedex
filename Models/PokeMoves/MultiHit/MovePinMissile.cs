using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePinMissile : PokeMove, IM_MultiHit
{
    public MovePinMissile()
        : base("Pin Missile",
               MoveClass.Physical,
               25, 95, // Pow & Acc
               20, 0, // PP & Priority
               TypeBug.Singleton) { }
}