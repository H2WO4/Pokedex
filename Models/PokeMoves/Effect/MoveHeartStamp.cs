using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveHeartStamp : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveHeartStamp()
        : base("Heart Stamp",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypePsychic.Singleton) { }
}