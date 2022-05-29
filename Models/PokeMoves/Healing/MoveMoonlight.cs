using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMoonlight : PokeMove, IM_Heal
{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => 50;

    public MoveMoonlight()
        : base("Moonlight",
               MoveClass.Status,
               null, null, // Pow & Acc
               5, 0, // PP & Priority
               TypeFairy.Singleton) { }
}