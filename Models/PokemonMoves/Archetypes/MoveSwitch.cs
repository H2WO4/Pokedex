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

		protected override void DoAction(Pokemon target)
		{
			bool success = target.ReceiveDamage(this.Caster, this, this._type);
			if (!success)
				Console.WriteLine("But it failed");
			else
			{
				var ev = new SwitchInputEvent(this.Caster.Owner, this.Arena);
				this.Arena.AddToTop(ev);
			}
		}
	}
}