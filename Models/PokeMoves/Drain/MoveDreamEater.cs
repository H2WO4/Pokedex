using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDreamEater : PokeMove, IM_Drain
{
    public int DrainPower
        => 50;

    public MoveDreamEater()
        : base("Dream Eater",
               MoveClass.Special,
               100, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypePsychic.Singleton) { }
}