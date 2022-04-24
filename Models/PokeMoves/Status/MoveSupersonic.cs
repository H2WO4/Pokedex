using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;

namespace Pokedex.Models.PokeMoves;

public class MoveSupersonic : PokeMove
{
    public MoveSupersonic()
        : base("Supersonic",
               MoveClass.Status,
               null, 55, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        var effect = new ConfusionEffect();
        
        effect.Apply(target);
    }
}