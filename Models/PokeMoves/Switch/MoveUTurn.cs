using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveUTurn : PokeMove, IM_SwitchAfter
{
    public MoveUTurn()
        : base("U Turn",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeBug.Singleton) { }
}