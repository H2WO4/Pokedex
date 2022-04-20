using Pokedex.Interfaces;


namespace Pokedex.Models.StatusEffects;

public class FlinchEffect : StatusEffect
{
	#region Constructor
	public FlinchEffect(I_Battler origin)
		: base("Flinch", origin) { }
	#endregion

	#region Methods
	public override bool BeforeAttack(I_Skill move)
	{
		return true;
	}
	
	public static void Apply(I_Battler target)
	{
		Console.WriteLine($"{target} flinched!");
		target.StatusEffects.Add(new FlinchEffect(target) { Timer = 0 });
	}
	#endregion
}