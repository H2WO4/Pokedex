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

		public override void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
		{
			int damage = caster.CurrHP;

			target.ReceivePureDamage(damage, owner, caster, this, this._type, context);

			caster.DoKO(origin, context);
		}
	}
}