using System.Text;

using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;


namespace Pokedex.Models;

/// <summary>
/// A selectable Pokemon move
/// </summary>
public abstract class PokeMove : I_Skill
{
	#region Variables
	private I_Battler? _caster;
	#endregion

	#region Properties
	public string Name { get; }

	public int? Power { get; protected set; }

	public MoveClass Class { get; }

	public int? Accuracy { get; }

	public int MaxPP { get; }

	public int PP { get; protected set; }

	public int Priority { get; protected set; }

	public PokeType Type { get; }

	public I_Battler Caster { get => _caster ?? throw new InvalidOperationException(); set => _caster = value; }

	public I_Combat Arena
		=> Caster.Arena;

	public bool CanThaw
		=> false;
	#endregion

	#region Constructors
	protected PokeMove(
		string name,
		MoveClass @class,
		int? power,
		int? accuracy,
		int maxPp,
		int priority,
		PokeType type
	)
	{
		if (name != "")
			Name = name;
		else throw new ArgumentException("Name cannot be empty");

		Class    = @class;
		Power    = power;
		Accuracy = accuracy;
		MaxPP    = maxPp;
		PP       = maxPp;
		Priority = priority;
		Type     = type;
	}
	#endregion

	#region Methods
	public virtual void OnUse()
	{
		// Active the caster's ability
		bool cancel = Caster.Ability.BeforeAttack(this);
		cancel = Caster.StatusEffects
					   .Aggregate(cancel, (current, effect) => current || effect.BeforeAttack(this));

		// Cancel the attack if needed
		if (cancel)
			return;

		// For each target, if the move hits, deal damage
		foreach (I_Battler target in GetTargets())
		{
			bool hit = AccuracyCheck(target);

			if (hit)
			{
				// Active the target's ability
				cancel = target.Ability.BeforeDefend(this);
				cancel = target.StatusEffects
							   .Aggregate(cancel, (current, effect) => current || effect.BeforeDefend(this));
		
				// Cancel the attack if needed
				if (cancel)
					return;
				
				DoAction(target);
			}
			else
				Console.WriteLine($"{Caster}'s {Name} missed {target}\n");
		}
	}

	/// <summary>
	/// Get the targets of the move
	/// </summary>
	/// <returns>All targets to be hit by the move</returns>
	protected virtual IEnumerable<I_Battler> GetTargets()
	{
		return Arena.Players
					.Where(player => player != Caster.Owner)
					.Select(player => player.Active);
	}

	/// <summary>
	/// Checks whether the move hits a target
	/// </summary>
	/// <param name="target">The target to check for</param>
	/// <returns>If the move hits, true, else false</returns>
	protected virtual bool AccuracyCheck(I_Battler target)
	{
		if (Accuracy == null)
			return true;

		return (Accuracy ?? 100) >= Program.Rnd.Next(1, 100);
	}

	/// <summary>
	/// Execute the action of the move unto the target
	/// </summary>
	/// <param name="target">The target to use</param>
	/// <exception cref="InvalidOperationException">Thrown if a status move does not override this</exception>
	protected virtual void DoAction(I_Battler target)
	{
		// Create the damage
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

		// Do the damage
		bool success = DamageHandler.DoDamage(dmgInfo, Caster, target);
		// Inform the player if it failed
		if (!success)
			Console.WriteLine("But it failed");
	}

	public virtual void PreAction(MoveEvent @event) { }

	public string GetQuickStatus()
		=> $"{Name} - {PP}/{MaxPP} PP";

	public string GetFullStatus()
	{
		var status = new StringBuilder();

		// Add the name
		status.Append($"{Name,-12}   ");
		// Add the class and type
		status.AppendLine($"{Class}-{Type}");
		// Add the Power, '---' if null
		status.Append($"Power: {Power?.ToString() ?? "---",4}      ");
		// Add the Accuracy, '---' if null
		status.AppendLine($"Accuracy: {Accuracy?.ToString("#'%'") ?? "---",4}");
		// Add the PP
		status.Append($"PP:   {PP,2}/{MaxPP,2}      ");
		// Add the Priority, with sign if positive, but not if 0
		status.AppendLine($"Priority:  {Priority,3:+#;-#;0}");

		return status.ToString();
	}

	public override string ToString()
		=> Name;
	#endregion
}