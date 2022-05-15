using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBarrier : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => +2;
    
    public MoveBarrier()
        : base("Barrier",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}