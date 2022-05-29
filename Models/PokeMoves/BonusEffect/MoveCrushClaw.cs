using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCrushClaw : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Defense;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -1;
        }
    }

    public int EffectChance
        => 50;

    public MoveCrushClaw()
        : base("Crush Claw",
               MoveClass.Physical,
               75, 95, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}