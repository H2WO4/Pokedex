namespace Pokedex.Models.Abilities
{
	public class AbilityAirLock : Ability
	{
		#region Constructors
		public AbilityAirLock()
			: base("Air Lock")
		{ }
		#endregion

		#region Methods
		public override bool AllowWeather() => false;
		#endregion
	}
}