using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSpore : PokeMove, IM_StatusEffect<SleepEffect>
{
    public MoveSpore()
        : base("Spore",
               MoveClass.Status,
               null, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}