using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMagnetBomb : PokeMove
{
    public MoveMagnetBomb()
        : base("Magnet Bomb",
               MoveClass.Physical,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeSteel.Singleton) { }
}