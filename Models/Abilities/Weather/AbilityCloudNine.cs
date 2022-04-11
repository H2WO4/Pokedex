namespace Pokedex.Models.Abilities
{
	public class AbilityCloudNine : Models.Ability
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