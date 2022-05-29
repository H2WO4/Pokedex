using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSuperFang : PokeMove, I_Skill
{
    public MoveSuperFang()
        : base("Super Fang",
               MoveClass.Physical,
               null, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public object CreateInfo(I_Battler target)
    {
        return new DamageInfo(CalcClass.Percent, 50);
    }
}