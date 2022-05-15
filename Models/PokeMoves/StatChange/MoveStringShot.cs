using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveStringShot : PokeMove, IM_StatChange
{
    public Stat StatToChange
        => Stat.Spd;

    public int ChangeValue
        => -1;

    public MoveStringShot()
        : base("String Shot",
               MoveClass.Status,
               null, 95, // Pow & Acc
               40, 0, // PP & Priority
               TypeBug.Singleton) { }
}