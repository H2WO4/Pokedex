using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSpacialRend : PokeMove
{
    public MoveSpacialRend()
        : base("Spacial Rend",
               MoveClass.Special,
               100, 95, // Pow & Acc
               5, 0, // PP & Priority
               TypeDragon.Singleton) { }
}