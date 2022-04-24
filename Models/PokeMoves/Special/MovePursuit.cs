using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MovePursuit : PokeMove
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

    public override void PreAction(MoveEvent @event)
    {
        if (@event.Caster.Arena.EventQueue
                  .OfType<SwitchEvent>()
                  .Any(ev => ev.Origin != Caster.Owner))
        {
            _doesPursuit    = true;
            @event.Priority = 8;
        }
    }

    public override void DoAction(I_Battler target)
    {
        if (_doesPursuit)
            Power *= 2;

        base.DoAction(target);

        if (_doesPursuit)
            Power /= 2;
    }

    public override bool AccuracyCheck(I_Battler target)
        => _doesPursuit || base.AccuracyCheck(target);
}