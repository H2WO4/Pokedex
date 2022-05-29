using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePowerUpPunch : PokeMove, IM_StatChangeBonusUser
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
        => 100;

    public MovePowerUpPunch()
        : base("Power Up Punch",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }
}