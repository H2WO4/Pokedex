using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCottonSpore : PokeMove, IM_StatChange
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

    public MoveCottonSpore()
        : base("Cotton Spore",
               MoveClass.Status,
               null, 100, // Pow & Acc
               40, 0, // PP & Priority
               TypeGrass.Singleton) { }
}