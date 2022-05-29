using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHyperVoice : PokeMove
{
    public MoveHyperVoice()
        : base("Hyper Voice",
               MoveClass.Special,
               90, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}