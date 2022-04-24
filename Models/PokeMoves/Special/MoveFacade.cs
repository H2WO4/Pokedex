using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveFacade : PokeMove
{
    public MoveFacade()
        : base("Facade",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        var changed = false;

        if (Caster.StatusEffects.Any())
        {
            Power   *= 2;
            changed =  true;
        }

        base.DoAction(target);

        if (changed)
            Power /= 2;
    }
}