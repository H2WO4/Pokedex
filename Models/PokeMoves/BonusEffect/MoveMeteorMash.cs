using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMeteorMash : PokeMove, IM_StatChangeBonusUser
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
        => 20;

    public MoveMeteorMash()
        : base("Meteor Mash",
               MoveClass.Physical,
               90, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeSteel.Singleton) { }
}