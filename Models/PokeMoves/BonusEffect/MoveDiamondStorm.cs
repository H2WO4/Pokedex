using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDiamondStorm : PokeMove, IM_StatChangeBonusUser
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
            yield return 2;
        }
    }

    public int EffectChance
        => 50;

    public MoveDiamondStorm()
        : base("Diamond Storm",
               MoveClass.Physical,
               100, 95, // Pow & Acc
               5, 0, // PP & Priority
               TypeRock.Singleton) { }
}