using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities;

public class AbilityDrougth : Models.Ability
{
	#region Constructors
	public AbilityDrougth()
		: base("Drougth")
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