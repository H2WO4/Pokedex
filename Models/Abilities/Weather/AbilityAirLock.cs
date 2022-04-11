namespace Pokedex.Models.Abilities
{
	public class AbilityAirLock : Models.Ability
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