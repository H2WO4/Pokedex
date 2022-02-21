using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveVoltSwitch : PokemonMove
	{
		public MoveVoltSwitch() : base(
			"Volt Switch",
			MoveClass.Special,
			70, 100, // Pow & Acc
			20, 0, // PP & Priority
			TypeElectric.Singleton
		) {}
		
		public override void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
		{
			bool success = target.ReceiveDamage(owner, caster, this, context);
			if (!success)
				Console.WriteLine("But it failed");
			else
			{
				var ev = new SwitchInputEvent(origin, context);
				context.AddToTop(ev);
			}
		}
    }
}