using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveStruggleBug : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialAttack;
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

    public MoveStruggleBug()
        : base("Struggle Bug",
               MoveClass.Special,
               50, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeBug.Singleton) { }
}