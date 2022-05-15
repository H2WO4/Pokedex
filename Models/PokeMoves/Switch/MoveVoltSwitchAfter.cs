using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveVoltSwitchAfter : PokeMove, IM_SwitchAfter
{
    public MoveVoltSwitchAfter()
        : base("Volt Switch",
               MoveClass.Special,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}