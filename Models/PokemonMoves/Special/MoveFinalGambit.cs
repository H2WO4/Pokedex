using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveFinalGambit : PokeMove
	{
		public MoveFinalGambit() : base(
			"Final Gambit",
			MoveClass.Special,
			null, 100, // Pow & Acc
			5, 0, // PP & Priority
			TypeFighting.Singleton
		)
		{ }

		protected override void DoAction(I_Battler target)
		{
			/* int damage = this.Caster.CurrHP;

			target.ReceiveDamage(this.Caster, new DamageInfo(InterType.DmgPure, damage, this.Type));

			this.Caster.DoKO(); */
		}
	}
}