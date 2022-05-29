using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMorningSun : PokeMove, IM_Heal
{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => 50;

    public MoveMorningSun()
        : base("Morning Sun",
               MoveClass.Status,
               null, null, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }
}