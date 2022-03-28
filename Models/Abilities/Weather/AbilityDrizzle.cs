using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities
{
	public class AbilityDrizzle : Ability
	{
		#region Constructors
		public AbilityDrizzle()
			: base("Drizzle")
		{ }
		#endregion

		#region Methods
		public override void OnEnter()
		{
			this.Announce();
			this.Origin.Arena.Weather = WeatherZenith.Singleton;
		}
		#endregion
	}
}