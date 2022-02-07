using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonSkills
{
	public class SkillThunder : PokemonMove
	{
		public SkillThunder() : base(
			"Thunder",
			SkillClass.Special,
			110,
			70,
			10,
			0,
			TypeElectric.Singleton
		){}

		public override void OnUse(Pokemon user, List<Pokemon> targets, List<PokemonMove> skillQueue)
		{
			throw new NotImplementedException();
		}
	}
}