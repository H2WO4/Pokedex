using Pokedex.Models.Weathers;


namespace Pokedex.Models.Abilities;

public class AbilitySandStream : Models.Ability
{
	#region Constructors
	public AbilitySandStream(Pokemon origin)
		: base("Sand Stream", origin) { }
	#endregion

	#region Methods
	public override void OnEnter()
	{
		Announce();
		Origin.Arena.Weather = WeatherZenith.Singleton;
	}
	#endregion
}