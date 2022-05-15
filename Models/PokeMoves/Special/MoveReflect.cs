using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveReflect : PokeMove
{
    public MoveReflect()
        : base("Reflect",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}