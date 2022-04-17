using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves;

public class MoveBellyDrum : MoveSelf
{
    public MoveBellyDrum()
        : base("Belly Drum",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void OnUse()
    {
        if (Caster.CurrHP * 100 / Caster.HP() < 50)
        {
            Console.WriteLine("The move failed!");
            return;
        }

        base.OnUse();
    }

    protected override void DoAction(I_Battler target)
    {
        if (target is Pokemon pokeTarget)
            pokeTarget.ChangeStatBonuses(12, 0, 0, 0,
                                         0);
    }
}