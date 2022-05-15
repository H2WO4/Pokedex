using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSleepPowder : PokeMove, IM_StatusEffect<SleepEffect>
{
    public MoveSleepPowder()
        : base("Sleep Powder",
               MoveClass.Status,
               null, 75, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}