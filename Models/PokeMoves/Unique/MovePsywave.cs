using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePsywave : PokeMove, IM_SpecialDamage
{
    public MovePsywave()
        : base("Psywave",
               MoveClass.Special,
               null, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypePsychic.Singleton) { }

    public double CalculateDamage(I_Battler target)
        => Caster.Level * Program.Rnd.Next(50, 150);
}