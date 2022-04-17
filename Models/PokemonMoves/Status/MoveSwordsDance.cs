using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves;

public class MoveSwordsDance : MoveSelf
{
    public MoveSwordsDance()
        : base("Swords Dance",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }

    protected override void DoAction(I_Battler target)
    {
        if (target is Pokemon pokeTarget)
            pokeTarget.ChangeStatBonuses(2, 0, 0, 0,
                                         0);
    }
}