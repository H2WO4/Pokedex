using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBreakneckBlitzSpecial : PokeMove
{
    public MoveBreakneckBlitzSpecial()
        : base("Breakneck Blitz  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeNormal.Singleton) { }
}