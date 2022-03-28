namespace Pokedex.Models.Abilities
{
	public class AbilityCloudNine : Ability
	{
		#region Constructors
		public AbilityCloudNine()
			: base("CloudNine")
		{ }
		#endregion

		#region Methods
		public override bool AllowWeather() => false;
		#endregion
	}
}