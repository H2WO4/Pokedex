﻿using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models.StatusEffects;

public class FreezeEffect : StatusEffect
{
	#region Constructor
	public FreezeEffect(I_Battler origin)
		: base("Freeze", origin) { }
	#endregion

	#region Methods
	public override bool BeforeAttack(I_Skill move)
	{
		if (!move.CanThaw
		 && Program.Rnd.Next(0, 100) < 80)
			return true;
		
		Console.WriteLine($"{Origin} thawed out of the ice!");
		Origin.StatusEffects.Remove(this);

		return false;

	}

	public override bool BeforeDefend(I_Skill move)
	{
		if (move.Type != TypeFire.Singleton)
			return false;

		Console.WriteLine($"{Origin} was thawed out of the ice!");
		Origin.StatusEffects.Remove(this);

		return false;
	}

	public static void Apply(I_Battler target)
	{
		if (target.Types.Contains(TypeIce.Singleton))
			return;

		target.StatusEffects.Add(new FreezeEffect(target));
	}
	#endregion
}