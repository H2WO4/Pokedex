using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMetalClaw : PokeMove, IM_StatChangeBonusUser
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return 1;
        }
    }

    public int EffectChance
        => 10;

    public MoveMetalClaw()
        : base("Metal Claw",
               MoveClass.Physical,
               50, 95, // Pow & Acc
               35, 0, // PP & Priority
               TypeSteel.Singleton) { }
}