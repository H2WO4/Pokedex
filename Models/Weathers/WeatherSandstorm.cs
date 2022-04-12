using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers;

public class WeatherSandstorm : Weather
{
	#region Class Variables
	private static WeatherSandstorm? _singleton;
	#endregion

	#region Properties
	public static WeatherSandstorm Singleton => _singleton ??= new WeatherSandstorm();
	#endregion

	#region Constructors
	private WeatherSandstorm() : base("Sandstorm")
	{
		TypePower.Add(TypeRock.Singleton, 1.5f);

		TypeSelector.Add(TypeRock.Singleton);
		TypeSelector.Add(TypeSteel.Singleton);
		TypeSelector.Add(TypeGround.Singleton);
	}
	#endregion

	#region Methods
	public override void OnTurnEnd(I_Combat arena)
	{
		arena.Players
			.Select(player => player.Active)
			.Where(poke => poke.Types.Intersect(TypeSelector).Any())
			.ToList()
			.ForEach(poke => Console.WriteLine($"{poke.Name} is buffeted by the sandstorm!"));
	}

	// Flavor Text
	public override void OnTurnStart(I_Combat arena)
		=> Console.WriteLine("The sandstorm rages.");
	public override void OnEnter()
		=> Console.WriteLine("A sandstorm kicked up!");
	public override void OnExit()
		=> Console.WriteLine("The sandstorm subsided.");

	#endregion
}