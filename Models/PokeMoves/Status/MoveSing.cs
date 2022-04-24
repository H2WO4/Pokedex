using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;

namespace Pokedex.Models.PokeMoves;

public class MoveSing : PokeMove
{
    public MoveSing()
        : base("Sing",
               MoveClass.Status,
               null, 55, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        var effect = new SleepEffect();
        
        effect.Apply(target);
    }
}