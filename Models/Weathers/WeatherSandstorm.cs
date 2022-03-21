using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherSandstorm : Weather
	{
		#region Class Variables
		private static WeatherSandstorm? __singleton;
		#endregion

		#region Properties
		public static WeatherSandstorm Singleton { get => __singleton ?? (__singleton = new WeatherSandstorm()); }
		#endregion

		#region Constructors
		protected WeatherSandstorm() : base("Sandstorm")
		{
			this._typePower.Add(TypeRock.Singleton, 1.5f);

			this._typeSelector.Append(TypeRock.Singleton);
			this._typeSelector.Append(TypeSteel.Singleton);
			this._typeSelector.Append(TypeGround.Singleton);
		}
		#endregion

		#region Methods
		public override void OnTurnEnd(I_Combat arena)
		{
			arena.Players
				.Select(player => player.Active)
				.Where(poke => poke.Types.Intersect(this._typeSelector).Count() > 0)
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
}