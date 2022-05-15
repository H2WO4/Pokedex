using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAmnesia : PokeMove, IM_TargetSelf, IM_StatChange
{
    public Stat StatToChange
        => Stat.SpDef;

    public int ChangeValue
        => +2;

    public MoveAmnesia()
        : base("Amnesia",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}