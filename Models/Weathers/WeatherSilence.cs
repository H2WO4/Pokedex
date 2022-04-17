using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models.Weathers;

public class WeatherSilence : Weather
{
	#region Class Variables
	private static WeatherSilence? _singleton;
	#endregion

	#region Constructors
	private WeatherSilence()
		: base("Silence")
	{
		TypePower.Add(TypePsychic.Singleton, 1.5f);
		TypePower.Add(TypeGhost.Singleton, 0.5f);
	}
	#endregion

	#region Properties
	public static WeatherSilence Singleton => _singleton ??= new WeatherSilence();
	#endregion

	#region Methods
	// Flavor Text
	public override void OnTurnStart(I_Combat arena)
	{
		Console.WriteLine("The battlefield is shrouded in silence.");
	}

	public override void OnEnter()
	{
		Console.WriteLine("Silence has befallen the battlefield!");
	}

	public override void OnExit()
	{
		Console.WriteLine("The silence has been lifted.");
	}
	#endregion
}