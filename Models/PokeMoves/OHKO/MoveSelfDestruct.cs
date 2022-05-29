using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSelfDestruct : PokeMove, I_Skill
{
    public MoveSelfDestruct()
        : base("Self Destruct",
               MoveClass.Physical,
               200, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public void OnMiss(I_Battler target)
    {
        Caster.DoKO();
    }

    public void DoBonusEffects(double applied, I_Battler target)
    {
        Caster.DoKO();
    }
}