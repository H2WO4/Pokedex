using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePursuit : PokeMove, I_Skill
{
    private bool _doesPursuit;

    public MovePursuit()
        : base("Pursuit",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeDark.Singleton)
    {
        _doesPursuit = false;
    }

    void I_Skill.PreAction(MoveEvent @event)
    {
        if (@event.Caster.Arena.EventQueue
                  .OfType<SwitchEvent>()
                  .Any(ev => ev.Origin != Caster.Owner))
        {
            _doesPursuit    = true;
            @event.Priority = 8;
        }
    }

    void I_Skill.DoAction(I_Battler target)
    {
        if (_doesPursuit)
            Power *= 2;

        I_Skill.DoAction(this, target);

        if (_doesPursuit)
            Power /= 2;
    }

    bool I_Skill.AccuracyCheck(I_Battler target)
        => _doesPursuit || (this as I_Skill).AccuracyCheck(target);
}