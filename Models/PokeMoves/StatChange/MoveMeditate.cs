using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMeditate : PokeMove, IM_TargetSelf, IM_StatChange
{
    public Stat StatToChange
        => Stat.Atk;

    public int ChangeValue
        => +1;

    public MoveMeditate()
        : base("Meditate",
               MoveClass.Status,
               null, null, // Pow & Acc
               40, 0, // PP & Priority
               TypePsychic.Singleton) { }
}