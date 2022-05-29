using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLeafStorm : PokeMove, IM_StatChangeBonusUser
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
            yield return -2;
        }
    }

    public int EffectChance
        => 100;

    public MoveLeafStorm()
        : base("Leaf Storm",
               MoveClass.Special,
               130, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeGrass.Singleton) { }
}