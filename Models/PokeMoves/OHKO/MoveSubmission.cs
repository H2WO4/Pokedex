using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSubmission : PokeMove, IM_RecoilPercent
{
    public int RecoilPower
        => 25;

    public MoveSubmission()
        : base("Submission",
               MoveClass.Physical,
               80, 80, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }
}