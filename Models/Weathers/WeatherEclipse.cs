using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherEclipse : Weather
	{
		#region Class Variables
		private static WeatherEclipse? _singleton;
		#endregion

		#region Properties
		public static WeatherEclipse Singleton { get => _singleton ?? (_singleton = new WeatherEclipse()); }
		#endregion

		#region Constructors
		protected WeatherEclipse() : base("Solar Eclipse")
		{
			this._typePower.Add(TypeDragon.Singleton, 1.5f);
			this._typePower.Add(TypeFairy.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The sun is still eclipsed.");
		public override void OnEnter()
			=> Console.WriteLine("The sun is still eclipsed.");
		public override void OnExit()
			=> Console.WriteLine("The sun is still eclipsed.");

		#endregion
	}
}