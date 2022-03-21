using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherHail : Weather
	{
		#region Class Variables
		private static WeatherHail? __singleton;
		#endregion

		#region Properties
		public static WeatherHail Singleton { get => __singleton ?? (__singleton = new WeatherHail()); }
		#endregion

		#region Constructors
		protected WeatherHail() : base("Hail")
		{
			this._typePower.Add(TypeIce.Singleton, 1.5f);

			this._typeSelector.Append(TypeIce.Singleton);
			this._typeSelector.Append(TypeWater.Singleton);
			this._typeSelector.Append(TypeLight.Singleton);
		}
		#endregion

		#region Methods
		public override void OnTurnEnd(I_Combat arena)
		{
			arena.Players
				.Select(player => player.Active)
				.Where(poke => poke.Types.Intersect(this._typeSelector).Count() > 0)
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