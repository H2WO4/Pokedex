using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLowKick : PokeMove, IM_SpecialDamage
{
    public MoveLowKick()
        : base("Low Kick",
               MoveClass.Physical,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }

    public double CalculateDamage(I_Battler target)
    {
        if (target is not Pokemon poke)
            return 0;

        return poke.Weight switch
               {
                   <= 10  => 20,
                   <= 25  => 40,
                   <= 50  => 60,
                   <= 100 => 80,
                   <= 200 => 100,
                   _      => 120,
               };
    }
}