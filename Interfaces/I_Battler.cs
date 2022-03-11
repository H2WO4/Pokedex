using Pokedex.Models;

namespace Pokedex.Interfaces
{
	/// <summary>
	/// Classes implementing this interface can serve in a player's team
	/// </summary>
	public interface I_Battler
	{
		#region Properties
		/// <summary>
		/// Name used for display
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Types used for damage calculation
		/// </summary>
		List<PokeType> Types { get; }

		/// <summary>
		/// Moves that the Pokemon can use
		/// </summary>
		PokemonMove?[] Moves { get; }

		/// <summary>
		/// The player whose Team contains this
		/// </summary>
		/// <paramref name="Team">
		I_Player? Owner { get; }

		/// <summary>
		/// The combat instance the fight is happening in
		/// </summary>
		I_Combat? Arena { get; }
		#endregion

		#region Methods
		/// <summary>
		/// Effective HP stat
		/// </summary>
		int HP();

		// <summary>
		/// Effective Atk stat
		/// </summary>
		int Atk();

		// <summary>
		/// Effective Def stat
		/// </summary>
		int Def();

		// <summary>
		/// Effective Special Atk stat
		/// </summary>
		int SpAtk();

		// <summary>
		/// Effective Special Def stat
		/// </summary>
		int SpDef();

		// <summary>
		/// Effective Speed stat
		/// </summary>
		int Spd();

		/// <summary>
		/// Calculates the damage modifier based on the incoming damage's type
		/// </summary>
		/// <param name="attacker">The incoming damage's type</param>
		/// <returns>Damage multiplier as a double</returns>
		double GetAffinity(PokeType attacker);

		/// <summary>
		/// Receive damage via a DamageInfo
		/// </summary>
		/// <param name="caster">The pokemon inflicting the damage</param>
		/// <param name="dmgInfo">The DamageInfo describing the damage</param>
		/// <returns>If the damage was correctly applied, true, otherwise, false</returns>
		bool ReceiveDamage(Pokemon caster, DamageInfo dmgInfo);

		/// <summary>
		/// String representation of the basic status of the battler
		/// </summary>
		/// <returns></returns>
		string GetQuickStatus();

		/// <summary>
		/// String representation of most information about the battler
		/// </summary>
		/// <returns></returns>
		string GetFullStatus();
		#endregion
	}
}