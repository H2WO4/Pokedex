using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveThunder : PokemonMove
	{
		public MoveThunder() : base(
			"Thunder",
			MoveClass.Special,
			110, 70, // Pow & Acc
			10, 0, // PP & Priority
			TypeElectric.Singleton
		) {}

        public override bool AccuracyCheck(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
        {
			if (context.Weather == WeatherRain.Singleton ||
				context.Weather == WeatherThunderstorm.Singleton)
				return true;
			
            return base.AccuracyCheck(target, owner, caster, origin, context);
        }
    }
}