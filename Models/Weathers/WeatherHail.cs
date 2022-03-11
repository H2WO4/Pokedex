using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherHail : Weather
	{
		#region Class Variables
		private static WeatherHail? _singleton;
		#endregion

		#region Properties
		public static WeatherHail Singleton { get => _singleton ?? (_singleton = new WeatherHail()); }
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
		public override void OnTurnEnd(Combat context)
		{
			if (context.PlayerA.Active.Types
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerA.Active.Name} is buffeted by the locust swarm!");
				// Damage logic
			}

			if (context.PlayerB.Active.Types
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerB.Active.Name} is buffeted by the locust swarm!");
				// Damage logic
			}
		}

		// Flavor Text
		public override void OnTurnStart(Combat context) =>
			Console.WriteLine("Hail continues to fall.");
		public override void OnEnter() =>
			Console.WriteLine("It started to hail!");
		public override void OnExit() =>
			Console.WriteLine("The hail stopped.");

		#endregion
	}
}