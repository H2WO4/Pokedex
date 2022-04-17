using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.PokemonMoves.Archetypes;

public abstract class MoveOHKO : PokeMove
{
    protected MoveOHKO
    (
        string name,
        MoveClass @class,
        int? accuracy,
        int maxPp,
        int priority,
        PokeType type
    )
        : base(name, @class, null, accuracy,
               maxPp, priority, type) { }

    protected override void DoAction(I_Battler target)
        => target.DoKO();
}