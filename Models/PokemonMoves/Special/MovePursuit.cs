using System.Reflection;
using Pokedex.Enums;
using Pokedex.Interfaces;
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
			if (event_.Caster.Arena.EventQueue
					.OfType<SwitchEvent>()
					.Any(ev => ev.Origin != this.Caster.Owner))
			{
				this.doesPursuit = true;
				event_.Priority = 8;
			}
		}

		protected override void DoAction(I_Battler target)
		{
			if (this.doesPursuit)
				this.Power *= 2;

			base.DoAction(target);

			if (this.doesPursuit)
				this.Power /= 2;
		}

		protected override bool AccuracyCheck(I_Battler target)
			=> this.doesPursuit || base.AccuracyCheck(target);
	}
}