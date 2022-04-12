namespace Pokedex.Models.Abilities;

public class AbilityHugePower : Models.Ability
{
	#region Constructors
	public AbilityHugePower()
		: base("HugePower")
	{ }
	#endregion

	#region Methods
	public override int ChangeAtk(int atk)
		=> atk * 2;
	#endregion
}