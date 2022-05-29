using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShoreUp : PokeMove, IM_Heal
{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => 50;

    public MoveShoreUp()
        : base("Shore Up",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}