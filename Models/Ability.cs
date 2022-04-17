using Pokedex.Interfaces;


namespace Pokedex.Models;

public abstract class Ability
{
	#region Constructors
	protected Ability
	(
		string name,
		Pokemon origin
	)
	{
		Name   = name;
		Origin = origin;
	}
	#endregion

	#region Properties
	public string Name { get; }

	protected Pokemon Origin { get; }
	#endregion
	
	#region Methods
	protected void Announce()
	{
		Console.WriteLine($"{Origin.Name}'s {Name}");
	}
	#endregion

	#region Methods - Conditions
	/// <summary>
	///     Whether this ability eliminates the effect of weather
	/// </summary>
	public virtual bool AllowWeather()
	{
		return true;
	}
	#endregion

	#region Methods - Hooks
	/// <summary>
	///     Called whenever damage is dealt
	/// </summary>
	/// <param name="dmgInfo">The damage being dealt</param>
	/// <param name="target">The one receiving the damage</param>
	/// <returns>True if the damage is cancelled</returns>
	public virtual bool OnInflictDamage(DamageInfo dmgInfo, I_Battler target)
	{
		return false;
	}

	/// <summary>
	///     Called whenever damage is received
	/// </summary>
	/// <param name="dmgInfo">The damage being dealt</param>
	/// <param name="caster">The one dealing the damage</param>
	/// <returns>True if the damage is cancelled</returns>
	public virtual bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
	{
		return false;
	}

	/// <summary>
	///     Called whenever damage from self is received
	/// </summary>
	/// <param name="dmgInfo">The damage being dealt</param>
	/// <returns>True if the damage is cancelled</returns>
	public virtual bool OnSelfDamage(DamageInfo dmgInfo)
	{
		return false;
	}

	/// <summary>
	///     Called after damage is dealt
	/// </summary>
	/// <param name="dmgInfo">The damage being dealt</param>
	/// <param name="target">The one receiving the damage</param>
	public virtual void AfterInflictDamage(DamageInfo dmgInfo, I_Battler target) { }

	/// <summary>
	///     Called after damage is received
	/// </summary>
	/// <param name="dmgInfo">The damage being dealt</param>
	/// <param name="caster">The one dealing the damage</param>
	public virtual void AfterReceiveDamage(DamageInfo dmgInfo, I_Battler caster) { }

	/// <summary>
	///     Called whenever its owner is made K.O.
	/// </summary>
	public virtual void OnDeath() { }

	/// <summary>
	///     Called whenever its owner is made K.O. by an opponent
	/// </summary>
	/// <returns>HP after death</returns>
	public virtual int OnKilled(I_Battler killer)
	{
		return 0;
	}

	/// <summary>
	///     Called whenever this Pokemon K.O. another Pokemon
	/// </summary>
	public virtual void OnKill() { }

	/// <summary>
	///     Called before a move is used
	/// </summary>
	/// <param name="move">The move used</param>
	/// <returns>True if the attack is canceled</returns>
	public virtual bool BeforeAttack(I_PokeMove move)
	{
		return false;
	}

	/// <summary>
	///     Called before a move is used
	/// </summary>
	/// <param name="move">The move used</param>
	/// <returns>True if the attack is canceled</returns>
	public virtual bool BeforeDefend(I_PokeMove move)
	{
		return false;
	}

	/// <summary>
	///     Called before returning a Pokemon's type
	/// </summary>
	/// <returns>The new types, or null if identical</returns>
	public virtual List<PokeType>? ChangeType()
	{
		return null;
	}

	/// <summary>
	///     Called just after entering combat
	/// </summary>
	public virtual void OnEnter() { }

	/// <summary>
	///     Called just before exiting combat
	/// </summary>
	public virtual void OnExit() { }

	/// <summary>
	///     Called at the beginning of the turn
	/// </summary>
	public virtual void OnTurnStart() { }

	/// <summary>
	///     Called at the end of the turn
	/// </summary>
	public virtual void OnTurnEnd() { }

	/// <summary>
	///     Called whenever the weather changes in battle
	/// </summary>
	/// <param name="leaving">The weather that is leaving</param>
	/// <param name="entering">The weather that is entering</param>
	public virtual void OnWeatherChange(Weather leaving, Weather entering) { }

	/// <summary>
	///     Called when calculating Max HP
	/// </summary>
	/// <param name="hp">Current calculated max HP</param>
	/// <returns>New max HP value</returns>
	public virtual int ChangeHP(int hp)
	{
		return hp;
	}

	/// <summary>
	///     Called when calculating Max HP
	/// </summary>
	/// <param name="atk">Current calculated attack</param>
	/// <returns>New attack value</returns>
	public virtual int ChangeAtk(int atk)
	{
		return atk;
	}

	/// <summary>
	///     Called when calculating Max HP
	/// </summary>
	/// <param name="def">Current calculated defense</param>
	/// <returns>New defense value</returns>
	public virtual int ChangeDef(int def)
	{
		return def;
	}

	/// <summary>
	///     Called when calculating Max HP
	/// </summary>
	/// <param name="spAtk">Current calculated special attack</param>
	/// <returns>New special attack value</returns>
	public virtual int ChangeSpAtk(int spAtk)
	{
		return spAtk;
	}

	/// <summary>
	///     Called when calculating Max HP
	/// </summary>
	/// <param name="spDef">Current calculated special defense</param>
	/// <returns>New special defense value</returns>
	public virtual int ChangeSpDef(int spDef)
	{
		return spDef;
	}

	/// <summary>
	///     Called when calculating Max HP
	/// </summary>
	/// <param name="spd">Current calculated speed</param>
	/// <returns>New calculated speed value</returns>
	public virtual int ChangeSpd(int spd)
	{
		return spd;
	}

	/// <summary>
	///     Called whenever an additive stat change is made
	/// </summary>
	/// <param name="atk">The added attack bonus</param>
	/// <param name="def">The added defense bonus</param>
	/// <param name="spAtk">The added special attack bonus</param>
	/// <param name="spDef">The added special defense bonus</param>
	/// <param name="spd">The added speed bonus</param>
	/// <returns>Tuple of the new changed bonuses</returns>
	public virtual (int, int, int, int, int) OnStatChange(int atk, int def, int spAtk, int spDef, int spd)
	{
		return (atk, def, spAtk, spDef, spd);
	}

	/// <summary>
	///     Called at the start of a combat
	/// </summary>
	public virtual void OnCombatStart() { }

	/// <summary>
	///     Called at the end of a combat
	/// </summary>
	public virtual void OnCombatEnd() { }
	#endregion
}