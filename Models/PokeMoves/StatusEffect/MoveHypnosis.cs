using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveHypnosis : PokeMove, I_Effect<SleepEffect>
{
    public MoveHypnosis()
        : base("Hypnosis",
               MoveClass.Status,
               null, 60, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}