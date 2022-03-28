using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities
{
	public class AbilitySandStream : Ability
	{
		#region Constructors
		public AbilitySandStream()
			: base("Sand Stream")
		{ }
		#endregion

		#region Methods
		public override void OnEnter()
		{
			this.Announce();
			this.Origin.Arena.Weather = WeatherZenith.Singleton;
		}
		#endregion
	}
}