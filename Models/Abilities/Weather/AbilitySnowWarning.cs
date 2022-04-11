using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities
{
	public class AbilitySnowWarning : Models.Ability
	{
		#region Constructors
		public AbilitySnowWarning()
			: base("Snow Warning")
		{ }
		#endregion

		#region Methods
		public override void OnEnter()
		{
			Announce();
			Origin.Arena.Weather = WeatherHail.Singleton;
		}
		#endregion
	}
}