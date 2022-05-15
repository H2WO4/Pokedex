using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRecover : PokeMove, I_Heal
{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => 50;

    public MoveRecover()
        : base("Recover",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}