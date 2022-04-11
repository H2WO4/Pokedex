using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherHail : Weather
	{
		#region Class Variables
		private static WeatherHail? _singleton;
		#endregion

		#region Properties
		public static WeatherHail Singleton => _singleton ??= new();
		#endregion

		#region Constructors
		private WeatherHail() : base("Hail")
		{
			TypePower.Add(TypeIce.Singleton, 1.5f);

			TypeSelector.Add(TypeIce.Singleton);
			TypeSelector.Add(TypeWater.Singleton);
			TypeSelector.Add(TypeLight.Singleton);
		}
		#endregion

		#region Methods
		public override void OnTurnEnd(I_Combat arena)
		{
			arena.Players
				.Select(player => player.Active)
				.Where(poke => poke.Types.Intersect(TypeSelector).Count() > 0)
				.ToList()
				.ForEach(poke => Console.WriteLine($"{poke.Name} is buffeted by the hail!"));
		}

		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Hail continues to fall.");
		public override void OnEnter()
			=> Console.WriteLine("It started to hail!");
		public override void OnExit()
			=> Console.WriteLine("The hail stopped.");

		#endregion
	}
}