using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSoftBoiled : PokeMove, IM_TargetSelf, IM_Heal
{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => 50;

    public MoveSoftBoiled()
        : base("Soft Boiled",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}