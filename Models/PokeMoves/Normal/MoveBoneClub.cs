using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBoneClub : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 10;

    public MoveBoneClub()
        : base("Bone Club",
               MoveClass.Physical,
               65, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeGround.Singleton) { }
}