using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveSwordsDance : PokeMove, I_Self
{
    public MoveSwordsDance()
        : base("Swords Dance",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        if (target is Pokemon pokeTarget)
            pokeTarget.ChangeStatBonuses(2, 0, 0, 0,
                                         0);
    }
}