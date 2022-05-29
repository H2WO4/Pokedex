using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveEnergyBall : PokeMove, IM_StatChangeBonus
{
    public IEnumerable<Stat> StatsToChange
    {
        get
        {
            yield return Stat.SpecialDefense;
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
        => 10;

    public MoveEnergyBall()
        : base("Energy Ball",
               MoveClass.Special,
               90, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGrass.Singleton) { }
}