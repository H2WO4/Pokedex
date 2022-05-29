using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveNightShade : PokeMove, I_Skill
{
    public MoveNightShade()
        : base("Night Shade",
               MoveClass.Special,
               null, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGhost.Singleton) { }
    
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