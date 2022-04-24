using Pokedex.Interfaces;


namespace Pokedex.Models.StatusEffects;

public class FlinchEffect : StatusEffect
{
	#region Constructor
	public FlinchEffect()
		: this(null) { }

	private FlinchEffect(I_Battler? origin)
		: base("Flinch", origin) { }
	#endregion

	#region Methods
	public override bool BeforeAttack(I_Skill move)
	{
		Origin.StatusEffects.Remove(this);
		return true;
	}

	public override void OnTurnEnd()
	{
		Origin.StatusEffects.Remove(this);
	}

	public override void Apply(I_Battler target)
	{
		Console.WriteLine($"{target} flinched!");
		target.StatusEffects.Add(new FlinchEffect(target) { Timer = 0 });
	}
	#endregion
}