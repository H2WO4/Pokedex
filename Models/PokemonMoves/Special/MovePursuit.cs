using System.Reflection;
using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MovePursuit : PokeMove
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

		public override void PreAction(MoveEvent event_)
		{
			if (event_.Caster.Arena.EventQueue.Any(ev => ev is SwitchEvent))
			{
				this.doesPursuit = true;
				event_.Priority = 8;
			}
		}

		protected override void DoAction(Pokemon target)
		{
			if (this.doesPursuit)
				this._power *= 2;

			base.DoAction(target);

			if (this.doesPursuit)
				this._power /= 2;
		}

		protected override bool AccuracyCheck(Pokemon target)
			=> this.doesPursuit || base.AccuracyCheck(target);
	}
}