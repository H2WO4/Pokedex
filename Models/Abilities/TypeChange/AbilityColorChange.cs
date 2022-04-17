using Pokedex.Interfaces;


namespace Pokedex.Models.Abilities;

public class AbilityColorChange : Models.Ability
{
	#region Variables
	private PokeType? _tempType;
	#endregion

	#region Constructors
	public AbilityColorChange(Pokemon origin)
		: base("Color Change", origin) { }
	#endregion

	#region Methods
	public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
	{
		if (dmgInfo.Type != null)
		{
			Announce();
			_tempType = dmgInfo.Type;
		}

		return true;
	}

	public override List<PokeType>? ChangeType()
	{
		return _tempType != null ? new List<PokeType> { _tempType } : null;
	}
	#endregion
}