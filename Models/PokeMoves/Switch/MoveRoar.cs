using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveRoar : PokeMove
{
    public MoveRoar()
        : base("Roar",
               MoveClass.Status,
               null, null, // Pow & Acc
               20, -6, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        var possibleSwitch = new int[target.Owner.Team.Length];
        int newIndex =
            possibleSwitch.Where(i => target.Owner.Team[i] != target.Owner.Active)
                          .Where(i => target.Owner.Team[i]
                                            .CurrHP
                                    > 0)
                          .MinBy(_ => Program.Rnd.Next());

        target.Owner.ChangeActive(newIndex, true);
    }
}