using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveIceHammer : PokeMove, IM_StatChangeBonusUser
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
            yield return -1;
        }
    }

    public int EffectChance
        => 100;

    public MoveIceHammer()
        : base("Ice Hammer",
               MoveClass.Physical,
               100, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeIce.Singleton) { }
}