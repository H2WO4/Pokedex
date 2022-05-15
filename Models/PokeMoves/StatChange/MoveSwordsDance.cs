using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSwordsDance : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Atk;

    public int ChangeValue
        => +2;

    public MoveSwordsDance()
        : base("Swords Dance",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}