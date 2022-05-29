using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveGrassWhistle : PokeMove, IM_StatusEffect<SleepEffect>
{
    public MoveGrassWhistle()
        : base("Grass Whistle",
               MoveClass.Status,
               null, 55, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}