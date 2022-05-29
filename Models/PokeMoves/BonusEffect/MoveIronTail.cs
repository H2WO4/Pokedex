using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveIronTail : PokeMove, IM_StatChangeBonus
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
        => 30;

    public MoveIronTail()
        : base("Iron Tail",
               MoveClass.Physical,
               100, 75, // Pow & Acc
               15, 0, // PP & Priority
               TypeSteel.Singleton) { }
}