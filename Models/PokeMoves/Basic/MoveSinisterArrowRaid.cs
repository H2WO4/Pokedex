using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSinisterArrowRaid : PokeMove
{
    public MoveSinisterArrowRaid()
        : base("Sinister Arrow Raid",
               MoveClass.Physical,
               180, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGhost.Singleton) { }
}