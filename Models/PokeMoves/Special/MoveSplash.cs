using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSplash : PokeMove, I_Skill
{
    public MoveSplash()
        : base("Splash",
               MoveClass.Status,
               null, null, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }

    void I_Skill.OnUse()
    {
        Console.WriteLine($"{Caster} splashes around!");
    }
}