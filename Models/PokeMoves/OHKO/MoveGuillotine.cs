using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGuillotine : PokeMove, IM_OHKO
{
    public MoveGuillotine()
        : base("Guillotine",
               MoveClass.Physical,
               null, 30, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }
}