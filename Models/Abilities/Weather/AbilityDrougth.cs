using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities
{
	public class AbilityDrougth : Ability
	{
		#region Constructors
		public AbilityDrougth()
			: base("Drougth")
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