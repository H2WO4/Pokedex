using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSharpen : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Atk;

    public int ChangeValue
        => +1;

    public MoveSharpen()
        : base("Sharpen",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}