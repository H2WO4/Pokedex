using Pokedex.Enums;
using Pokedex.Models.Events;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public class MoveSwitch : PokemonMove
	{
		public MoveSwitch
		(
			string name,
			MoveClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
		) : base(name, class_, power, accuracy, maxPp, priority, type) { }

		public override void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
		{
			bool success = target.ReceiveDamage(owner, caster, this, this._type, context);
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