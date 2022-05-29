using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDisarmingVoice : PokeMove
{
    public MoveDisarmingVoice()
        : base("Disarming Voice",
               MoveClass.Special,
               40, null, // Pow & Acc
               15, 0, // PP & Priority
               TypeFairy.Singleton) { }
}