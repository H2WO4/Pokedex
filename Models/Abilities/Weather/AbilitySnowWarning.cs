using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities
{
	public class AbilitySnowWarning : Ability
	{
		#region Constructors
		public AbilitySnowWarning()
			: base("Snow Warning")
		{ }
		#endregion

		#region Methods
		public override void OnEnter()
		{
			this.Announce();
			this.Origin.Arena.Weather = WeatherHail.Singleton;
		}
		#endregion
	}
}