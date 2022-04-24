using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveGrowl : PokeMove
{
    public MoveGrowl()
        : base("Growl",
               MoveClass.Status,
               null, 100, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        if (target is Pokemon poke)
            poke.ChangeStatBonus(Stat.Atk, -1);
    }
}