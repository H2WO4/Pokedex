using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFissure : PokeMove, IM_OHKO
{
    public MoveFissure()
        : base("Fissure",
               MoveClass.Physical,
               null, 30, // Pow & Acc
               5, 0, // PP & Priority
               TypeGround.Singleton) { }
}