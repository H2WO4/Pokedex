using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMaliciousMoonsault : PokeMove
{
    public MoveMaliciousMoonsault()
        : base("Malicious Moonsault",
               MoveClass.Physical,
               180, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeDark.Singleton) { }
}