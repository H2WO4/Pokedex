using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTickle : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
            yield return Stat.Defense;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -1;
            yield return -1;
        }
    }

    public MoveTickle()
        : base("Tickle",
               MoveClass.Status,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}