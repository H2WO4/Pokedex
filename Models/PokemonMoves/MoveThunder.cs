using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveThunder : PokemonMove
	{
		public MoveThunder() : base(
			"Thunder",
			SkillClass.Special,
			110,
			70,
			10,
			0,
			TypeElectric.Singleton
		){}

		public override void OnUse(Pokemon origin, List<Pokemon> targets, CombatInstance context)
		{
			throw new NotImplementedException();
		}
	}
}