using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSkullBash : PokeMove
{
    public MoveSkullBash()
        : base("Skull Bash",
               MoveClass.Physical,
               130, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}