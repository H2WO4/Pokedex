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

		public override void OnUse()
		{
			if (this.Caster.CurrHP * 100 / this.Caster.HP() < 50)
			{
				Console.WriteLine("The move failed!");
				return;
			}

			base.OnUse();
		}

		protected override void DoAction(Pokemon target)
			=> target.ChangeStatBonuses(12, 0, 0, 0, 0);
	}
}