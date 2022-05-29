using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFieryDance : PokeMove, IM_StatChangeBonusUser
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
            yield return 1;
        }
    }

    public int EffectChance
        => 50;

    public MoveFieryDance()
        : base("Fiery Dance",
               MoveClass.Special,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeFire.Singleton) { }
}