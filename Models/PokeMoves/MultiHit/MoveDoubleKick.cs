using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveImDoubleKick : PokeMove, IM_DoubleHit
{
    public MoveImDoubleKick()
        : base("Double Kick",
               MoveClass.Physical,
               30, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeFighting.Singleton) { }
}