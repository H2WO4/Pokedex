using Pokedex.Models.Pokemons;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities;

public class AbilityForecast : Models.Ability
{
	#region Constructors
	public AbilityForecast(Pokemon origin)
		: base("Forecast", origin)
	{ }
	#endregion

	#region Methods
	public override void OnEnter()
		=> ChangeType(Origin.Arena.Weather);

	public override void OnExit()
	{
		if (Origin.ID != 351) return;
		
		typeof(Pokemon).GetProperty("Species")!
			.SetValue(Origin, Castform.Singleton);
	}

	public override void OnWeatherChange(Weather leaving, Weather entering)
		=> ChangeType(entering);

	public override void OnCombatEnd()
		=> typeof(Pokemon).GetProperty("Species")!
			.SetValue(this, Castform.Singleton);

	private void ChangeType(Weather current)
	{
		if (Origin.ID != 351) return;

		Announce();
		bool blockedWeather = Origin.Arena.Players
			.Any(player => !player.Active.Ability.AllowWeather());
		
		typeof(Pokemon).GetProperty("Species")!
			.SetValue(Origin, current switch
			{
				_ when blockedWeather => Castform.Singleton,
				
				WeatherAsh => CastformAsh.Singleton,
				WeatherAurora => CastformAurora.Singleton,
				WeatherEclipse => CastformEclipse.Singleton,
				WeatherFog => CastformFog.Singleton,
				WeatherHail => CastformSnowy.Singleton,
				WeatherLocust => CastformLocust.Singleton,
				WeatherMagnetic => CastformMagnetic.Singleton,
				WeatherMidnight => CastformMidnight.Singleton,
				WeatherRain => CastformRainy.Singleton,
				WeatherRainbow => CastformRainbow.Singleton,
				WeatherSandstorm => CastformSand.Singleton,
				WeatherSilence => CastformSilent.Singleton,
				WeatherThunderstorm => CastformThunder.Singleton,
				WeatherTornado => CastformWindy.Singleton,
				WeatherZenith => CastformSunny.Singleton,
				
				_ => Castform.Singleton,
			});
	}
	#endregion
}