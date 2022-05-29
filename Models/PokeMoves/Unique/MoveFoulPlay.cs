using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFoulPlay : PokeMove, I_Skill
{
    public MoveFoulPlay()
        : base("Foul Play",
               MoveClass.Physical,
               95, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeDark.Singleton) { }

    public object CreateInfo(I_Battler target)
    {
        return new DamageInfo(CalcClass.Calculated, Power ?? 0, Type)
               {
                   AttackStats = Stat.Attack, DefenseStats = Stat.Attack, Contact = true,
               };
    }
}