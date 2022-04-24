using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveVoltSwitch : PokeMove, I_Switch
{
    public MoveVoltSwitch()
        : base("Volt Switch",
               MoveClass.Special,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}