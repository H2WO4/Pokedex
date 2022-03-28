using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public abstract class MoveSwitch : PokeMove
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

		protected override void DoAction(I_Battler target)
		{
			/* InterType dmgClass = this.Class == MoveClass.Physical
									? InterType.Physical
									: InterType.Special;

			bool success = target.ReceiveDamage(this.Caster, new Interaction(dmgClass, this.Power ?? 0, this.Type));
			if (!success)
				Console.WriteLine("But it failed");
			else
			{
				var ev = new SwitchInputEvent(this.Caster.Owner, this.Arena);
				this.Arena.AddToTop(ev);
			} */
		}
	}
}