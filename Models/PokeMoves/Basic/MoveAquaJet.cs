using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAquaJet : PokeMove
{
    public MoveAquaJet()
        : base("Aqua Jet",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               20, 1, // PP & Priority
               TypeWater.Singleton) { }
}