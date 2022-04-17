using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;


namespace Pokedex.Models.PokemonMoves.Archetypes;

public abstract class MoveSwitch : PokeMove
{
	protected MoveSwitch
	(
		string name,
		MoveClass @class,
		int? power,
		int? accuracy,
		int maxPp,
		int priority,
		PokeType type
	)
		: base(name, @class, power, accuracy,
			   maxPp, priority, type) { }

	protected override void DoAction(I_Battler target)
	{
		// Activate the target's ability
		bool cancel = target.Ability.BeforeDefend(this);

		// Cancel the attack if needed
		if (cancel)
			return;

		DamageInfo dmgInfo =
			Class switch
			{
				MoveClass.Physical => DamageInfo.CreatePhysical(Power ?? 0, Type),
				MoveClass.Special  => DamageInfo.CreateSpecial(Power ?? 0, Type),

				_ => throw new InvalidOperationException(),
			};

		// Apply STAB
		if (Caster.Types.Contains(Type))
			dmgInfo.Power = (int)(dmgInfo.Power * 1.5);

		bool success = DamageHandler.DoDamage(dmgInfo, Caster, target);
		if (!success)
			Console.WriteLine("But it failed");
		else
			Arena.AddToTop(new SwitchInputEvent(Caster.Owner, Arena));
	}
}