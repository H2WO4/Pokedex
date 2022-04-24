using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveLeer : PokeMove
{
    public MoveLeer()
        : base("Leer",
               MoveClass.Status,
               null, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        if (target is Pokemon poke)
            poke.ChangeStatBonus(Stat.Def, -1);
    }
}