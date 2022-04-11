using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherAurora : Weather
	{
		#region Class Variables
		private static WeatherAurora? _singleton;
		#endregion

		#region Properties
		public static WeatherAurora Singleton => _singleton ??= new();
		#endregion

		#region Constructors
		private WeatherAurora() : base("Aurora Borealis")
		{
			TypePower.Add(TypeFairy.Singleton, 1.5f);
			TypePower.Add(TypeDragon.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The aurora borealis shines brightly.");
		public override void OnEnter()
			=> Console.WriteLine("An aurora borealis has appeared!");
		public override void OnExit()
			=> Console.WriteLine("The aurora borealis has disappeared.");

		#endregion
	}
}