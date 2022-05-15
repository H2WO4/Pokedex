using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveWithdraw : PokeMove, IM_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => +1;

    public MoveWithdraw()
        : base("Withdraw",
               MoveClass.Status,
               null, null, // Pow & Acc
               40, 0, // PP & Priority
               TypeWater.Singleton) { }
}