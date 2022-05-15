using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLeechLife : PokeMove
{
    public MoveLeechLife()
        : base("Leech Life",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeBug.Singleton) { }
}