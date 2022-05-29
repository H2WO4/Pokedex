using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTearfulLook : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
            yield return Stat.SpecialAttack;
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

    public MoveTearfulLook()
        : base("Tearful Look",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}