using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveVenomDrench : PokeMove, IM_StatChange
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.Attack;
            yield return Stat.SpecialAttack;
            yield return Stat.Speed;
        }
    }

    public IEnumerable<int> ChangeValues
    {
        get
        {
            yield return -1;
            yield return -1;
            yield return -1;
        }
    }

    public MoveVenomDrench()
        : base("Venom Drench",
               MoveClass.Status,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}