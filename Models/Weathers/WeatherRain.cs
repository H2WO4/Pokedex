using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models.Weathers;

public class WeatherRain : Weather
{
	#region Class Variables
	private static WeatherRain? _singleton;
	#endregion

	#region Constructors
	private WeatherRain()
		: base("Rain")
	{
		TypePower.Add(TypeWater.Singleton, 1.5f);
		TypePower.Add(TypeFire.Singleton, 0.5f);
	}
	#endregion

	#region Properties
	public static WeatherRain Singleton => _singleton ??= new WeatherRain();
	#endregion

	#region Methods
	// Flavor Text
	public override void OnTurnStart(I_Combat arena)
	{
		Console.WriteLine("Rain continues to fall.");
	}

	public override void OnEnter()
	{
		Console.WriteLine("It started to rain.");
	}

	public override void OnExit()
	{
		Console.WriteLine("The rain stopped.");
	}
	#endregion
}