using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBoneClub : PokeMove
{
    public MoveBoneClub()
        : base("Bone Club",
               MoveClass.Physical,
               65, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeGround.Singleton) { }
}