using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveFinalGambit : PokemonMove
	{
		public MoveFinalGambit() : base(
			"Final Gambit",
			MoveClass.Special,
			null, 100, // Pow & Acc
			5, 0, // PP & Priority
			TypeFighting.Singleton
		)
		{ }

		protected override void DoAction(Pokemon target)
		{
			int damage = this.Caster.CurrHP;

			target.ReceivePureDamage(damage, this.Caster, this, this._type);

			this.Caster.DoKO();
		}
	}
}