using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;
using Pokedex.Models.Weathers;


namespace Pokedex.Models.PokeMoves;

public class MoveBlizzard : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MoveBlizzard()
        : base("Blizzard",
               MoveClass.Special,
               110, 70, // Pow & Acc
               5, 0, // PP & Priority
               TypeIce.Singleton) { }

    bool I_Skill.AccuracyCheck(I_Battler target)
    {
        if (Arena.Weather == WeatherAurora.Singleton
         || Arena.Weather == WeatherHail.Singleton)
            return true;

        return I_Skill.AccuracyCheck(this, target);
    }
}