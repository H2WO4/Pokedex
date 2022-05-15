using Pokedex.Enums;
using Pokedex.Interfaces;


namespace Pokedex.Models.StatusEffects;

public class ConfusionEffect : StatusEffect
{
	#region Constructor
	public ConfusionEffect()
		: this(null) { }

	private ConfusionEffect(I_Battler? origin)
		: base("Confusion", origin)
	{
		Timer = Program.Rnd.Next(2, 6);
	}
	#endregion

	#region Methods
	public override bool BeforeAttack(I_Skill move)
	{
		Console.WriteLine($"{Origin} is confused!");
		Timer--;
		
		if (Timer == 0)
		{
			Origin.StatusEffects.Remove(this);
			Console.WriteLine($"{Origin} snapped out of it!");

			return false;
		}
		
		if (Program.Rnd.Next(0, 100) >= 33)
			return false;
		
		Console.WriteLine($"{Origin} it hurt itself in its confusion!");
		var dmgInfo = new DamageInfo(CalcClass.Calculated, 40) { AttackStats = Stat.Atk, DefenseStats = Stat.Def };
		InteractionHandler.DoDamageNoCaster(dmgInfo, Origin);

		return true;
	}
	
	public override bool Apply(I_Battler target)
	{
		var  effect = new ConfusionEffect(target);
		bool cancel = target.Ability.OnReceiveStatusEffect(effect);

		if (cancel)
			return false;

		target.StatusEffects.Add(effect);

		return true;
	}
	#endregion
}