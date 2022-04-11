using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities
{
	public class AbilityDrizzle : Models.Ability
	{
		#region Constructors
		public AbilityDrizzle()
			: base("Drizzle")
		{ }
		#endregion

		#region Methods
		public override void OnEnter()
		{
			Announce();
			Origin.Arena.Weather = WeatherZenith.Singleton;
		}
		#endregion
	}
}