using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFurySwipes : PokeMove
{
    public MoveFurySwipes()
        : base("Fury Swipes",
               MoveClass.Physical,
               18, 80, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}