using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTeleport : PokeMove, I_Skill
{
    public MoveTeleport()
        : base("Teleport",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, -6, // PP & Priority
               TypePsychic.Singleton) { }

    void I_Skill.OnUse()
    {
        Caster.Owner.AskActiveChange();
    }
}