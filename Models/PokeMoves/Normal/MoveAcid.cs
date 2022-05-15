using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAcid : PokeMove, IM_StatChangeBonus
{
    public Stat StatToChange
        => Stat.SpDef;

    public int ChangeValue
        => -1;

    public int EffectChance
        => 10;

    public MoveAcid()
        : base("Acid",
               MoveClass.Special,
               40, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypePoison.Singleton) { }
}