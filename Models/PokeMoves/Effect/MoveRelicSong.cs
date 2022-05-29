using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRelicSong : PokeMove, IM_StatusEffectBonus<SleepEffect>
{
    public int EffectChance
        => 10;

    public MoveRelicSong()
        : base("Relic Song",
               MoveClass.Special,
               75, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}