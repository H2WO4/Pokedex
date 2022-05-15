using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAcidArmor : PokeMove, IM_TargetSelf, IM_StatChange
{
    public Stat StatToChange
        => Stat.Def;

    public int ChangeValue
        => +2;

    public MoveAcidArmor()
        : base("Acid Armor",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}