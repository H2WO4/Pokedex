using Pokedex.Enums;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveBellyDrum : MoveSelf
	{
		public MoveBellyDrum() : base(
			"Belly Drum",
			MoveClass.Status,
			null, null, // Pow & Acc
			10, 0, // PP & Priority
			TypeNormal.Singleton
		)
		{ }

		public override void OnUse(Pokemon caster, Trainer origin, Combat context)
		{
			if (caster.CurrHP * 100 / caster.HP() < 50)
			{
				Console.WriteLine("The move failed!");
				return;
			}

			base.OnUse(caster, origin, context);
		}

		public override void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
			=> target.ChangeStatBonuses(12, 0, 0, 0, 0);
	}
}