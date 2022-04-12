namespace Pokedex.Models.Abilities;

public class AbilitySimple : Models.Ability
{
	#region Constructors
	public AbilitySimple()
		: base("Simple")
	{ }
	#endregion

	#region Methods
	public override (int, int, int, int, int) OnStatChange(int atk, int def, int spAtk, int spDef, int spd)
	{
		Announce();	
		return (2*atk, 2*def, 2*spAtk, 2*spDef, 2*spd);
	}
	#endregion
}