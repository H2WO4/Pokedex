using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAgility : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Spd;

    public int ChangeValue
        => +2;

    public MoveAgility()
        : base("Agility",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypePsychic.Singleton) { }
}