using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRapidSpin : PokeMove, IM_StatChangeBonusUser
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Speed;
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

    public MoveRapidSpin()
        : base("Rapid Spin",
               MoveClass.Physical,
               50, 100, // Pow & Acc
               40, 0, // PP & Priority
               TypeNormal.Singleton) { }
}