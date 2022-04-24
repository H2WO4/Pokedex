using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveBellyDrum : PokeMove, I_Self
{
    public MoveBellyDrum()
        : base("Belly Drum",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void OnUse()
    {
        if (Caster.HP() - Caster.CurrHP >= Caster.CurrHP)
        {
            Console.WriteLine("The move failed!");
            return;
        }

        base.OnUse();
    }

    public override void DoAction(I_Battler target)
    {
        if (target is not Pokemon pokeTarget)
            return;

        pokeTarget.CurrHP -= pokeTarget.HP() / 2;
        pokeTarget.ChangeStatBonus(Stat.Atk, +12);
    }
}