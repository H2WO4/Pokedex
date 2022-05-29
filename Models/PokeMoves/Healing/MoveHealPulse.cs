using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHealPulse : PokeMove, IM_Heal
{
    public CalcClass CalcClass
        => CalcClass.Percent;

    public int HealingPower
        => 50;

    public MoveHealPulse()
        : base("Heal Pulse",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypePsychic.Singleton) { }
}