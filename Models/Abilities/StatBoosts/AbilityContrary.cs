namespace Pokedex.Models.Abilities
{
	public class AbilityContrary : Models.Ability
	{
		#region Constructors
		public AbilityContrary()
			: base("Contrary")
		{ }
		#endregion

		#region Methods
		public override (int, int, int, int, int) OnStatChange(int atk, int def, int spAtk, int spDef, int spd)
		{
			Announce();
			return (-atk, -def, -spAtk, -spDef, -spd);
		}
		#endregion
	}
}