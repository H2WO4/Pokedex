using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBellyDrum : PokeMove, I_Self, I_StatChange
{
    public Stat StatToChange
        => Stat.Atk;

    public int ChangeValue
        => +12;

    public MoveBellyDrum()
        : base("Belly Drum",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public void OnUse()
    {
        if (Caster.HP() - Caster.CurrHP >= Caster.CurrHP)
        {
            Console.WriteLine("The move failed!");

            return;
        }

        I_Skill.OnUse(this);
    }
}