using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MovePursuit : PokemonMove
	{
		private bool doesPursuit;

		public MovePursuit() : base(
			"Pursuit",
			MoveClass.Physical,
			40, 100, // Pow & Acc
			20, 0, // PP & Priority
			TypeDark.Singleton
		)
		{
			this.doesPursuit = false;
		}

		public override void PreAction(MoveEvent event_, CombatInstance context)
		{
			if (context.EventQueue.Any(ev => ev is SwitchEvent))
			{
				this.doesPursuit = true;
				event_.Priority = 8;
			}
		}

		public override void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
		{
			if (this.doesPursuit)
				this._power *= 2;

			base.DoAction(target, owner, caster, origin, context);

			if (this.doesPursuit)
				this._power /= 2;
		}

		public override bool AccuracyCheck(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
			=> this.doesPursuit || base.AccuracyCheck(target, owner, caster, origin, context);
	}
}