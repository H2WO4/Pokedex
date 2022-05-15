using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDefenseCurl : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => +1;

    public MoveDefenseCurl()
        : base("Defense Curl",
               MoveClass.Status,
               null, null, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }
}