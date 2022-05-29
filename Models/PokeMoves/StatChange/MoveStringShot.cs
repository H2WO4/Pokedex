using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveStringShot : PokeMove, IM_StatChange
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
            yield return -2;
        }
    }

    public MoveStringShot()
        : base("String Shot",
               MoveClass.Status,
               null, 95, // Pow & Acc
               40, 0, // PP & Priority
               TypeBug.Singleton) { }
}