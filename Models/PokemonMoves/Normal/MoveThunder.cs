using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveThunder : PokeMove
	{
		public MoveThunder() : base(
			"Thunder",
			MoveClass.Special,
			110, 70, // Pow & Acc
			10, 0, // PP & Priority
			TypeElectric.Singleton
		)
		{ }

		protected override bool AccuracyCheck(I_Battler target)
		{
			if (this.Arena.Weather == WeatherRain.Singleton ||
				this.Arena.Weather == WeatherThunderstorm.Singleton)
				return true;

			return base.AccuracyCheck(target);
		}
	}
}