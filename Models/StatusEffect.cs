﻿using Pokedex.Interfaces;


namespace Pokedex.Models;

public abstract class StatusEffect
{
	#region Constructors
	protected StatusEffect
	(
		string name,
		int? timer = null
	)
	{
		Name  = name;
		Timer = timer;
	}
	#endregion

	#region Properties
	public string Name { get; }

	public int? Timer { get; set; }
	#endregion

	#region Methods
    /// <summary>
    ///     Called at the start of the turn
    /// </summary>
    public virtual void OnTurnStart() { }

    /// <summary>
    ///     Called at the end of the turn
    /// </summary>
    public virtual void OnTurnEnd() { }

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
    ///     Called when calculating Max HP
    /// </summary>
    /// <param name="hp">Current calculated max HP</param>
    /// <returns></returns>
    public virtual int ChangeHP(int hp)
	{
		return hp;
	}

    /// <summary>
    ///     Called when calculating Max HP
    /// </summary>
    /// <param name="atk">Current calculated attack</param>
    /// <returns></returns>
    public virtual int ChangeAtk(int atk)
	{
		return atk;
	}

    /// <summary>
    ///     Called when calculating Max HP
    /// </summary>
    /// <param name="def">Current calculated defense</param>
    /// <returns></returns>
    public virtual int ChangeDef(int def)
	{
		return def;
	}

    /// <summary>
    ///     Called when calculating Max HP
    /// </summary>
    /// <param name="spAtk">Current calculated special attack</param>
    /// <returns></returns>
    public virtual int ChangeSpAtk(int spAtk)
	{
		return spAtk;
	}

    /// <summary>
    ///     Called when calculating Max HP
    /// </summary>
    /// <param name="spDef">Current calculated special defense</param>
    /// <returns></returns>
    public virtual int ChangeSpDef(int spDef)
	{
		return spDef;
	}

    /// <summary>
    ///     Called when calculating Max HP
    /// </summary>
    /// <param name="spd">Current calculated speed</param>
    /// <returns></returns>
    public virtual int ChangeSpd(int spd)
	{
		return spd;
	}
	#endregion
}