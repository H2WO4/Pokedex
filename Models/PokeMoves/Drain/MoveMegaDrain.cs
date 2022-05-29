using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMegaDrain : PokeMove, IM_Drain
{
    public int DrainPower
        => 50;

    public MoveMegaDrain()
        : base("Mega Drain",
               MoveClass.Special,
               40, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}