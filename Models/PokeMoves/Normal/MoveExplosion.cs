using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveExplosion : PokeMove, I_Skill
{
    public MoveExplosion()
        : base("Explosion",
               MoveClass.Physical,
               250, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public void DoBonusEffects(double applied, I_Battler target)
        => Caster.DoKO();
}