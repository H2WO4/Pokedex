using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveTakeDown : PokeMove, I_Recoil
{
    public int RecoilPower
        => 25;

    public MoveTakeDown()
        : base("Take Down",
               MoveClass.Physical,
               90, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}