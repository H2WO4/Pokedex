using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePsychic : PokeMove, IM_StatChangeBonus
{
    public Stat StatToChange
        => Stat.SpDef;

    public int ChangeValue
        => -1;

    public int EffectChance
        => 10;

    public MovePsychic()
        : base("Psychic",
               MoveClass.Special,
               90, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypePsychic.Singleton) { }
}