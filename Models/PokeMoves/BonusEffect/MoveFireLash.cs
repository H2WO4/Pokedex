using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFireLash : PokeMove, IM_StatChangeBonus
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
        => 100;

    public MoveFireLash()
        : base("Fire Lash",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}