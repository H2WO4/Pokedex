namespace Pokedex.Models.Weathers;

public class WeatherClear : Weather
{
	#region Class Variables
	private static WeatherClear? _singleton;
	#endregion

	#region Properties
	public static WeatherClear Singleton => _singleton ??= new WeatherClear();
	#endregion

	#region Constructors
	private WeatherClear() : base("Clear") { }
	#endregion

	#region Methods
	// Flavor Text
	public override void OnEnter()
		=> Console.WriteLine("The sky clears up.");

	#endregion
}