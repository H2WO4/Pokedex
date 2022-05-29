using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveTriAttack : PokeMove, I_Skill
{
    public MoveTriAttack()
        : base("Tri Attack",
               MoveClass.Special,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public void DoBonusEffects(double applied, I_Battler target)
    {
        StatusEffect effect = Program.Rnd.Next(1, 4) switch
                              {
                                  1 => new BurnEffect(),
                                  2 => new FreezeEffect(),
                                  3 => new ParalysisEffect(),

                                  _ => throw new InvalidOperationException()
                              };

        if (Program.Rnd.Next(0, 100) < 20)
            effect.Apply(target);
    }
}