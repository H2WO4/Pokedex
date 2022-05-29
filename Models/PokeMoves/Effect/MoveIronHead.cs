using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveIronHead : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveIronHead()
        : base("Iron Head",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeSteel.Singleton) { }
}