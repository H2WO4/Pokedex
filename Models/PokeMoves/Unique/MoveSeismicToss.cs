using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSeismicToss : PokeMove, I_Skill
{
    public MoveSeismicToss()
        : base("Seismic Toss",
               MoveClass.Physical,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }

    public void DoAction(I_Battler target)
    {
        if (Type.CalculateAffinity(target.Types) == 0)
        {
            Console.WriteLine("But it failed!");
            return;
        }

        int damage = Caster.Level;
        InteractionHandler.DoDamage(new DamageInfo(CalcClass.Pure, damage), Caster, target);
    }
}