using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveScaryFace : PokeMove, IM_StatChange
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

    public MoveScaryFace()
        : base("Scary Face",
               MoveClass.Status,
               null, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}