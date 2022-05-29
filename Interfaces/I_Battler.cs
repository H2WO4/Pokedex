using System.Diagnostics.Contracts;

using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces;

/// <summary>
/// Classes implementing this interface can serve in a player's team
/// </summary>
public interface I_Battler
{
    #region Properties
    /// <summary>
    /// Name used for display
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The species the battler belongs to
    /// </summary>
    public PokeSpecies Species { get; }

    /// <summary>
    /// Types used for damage calculation
    /// </summary>
    public IEnumerable<PokeType> Types { get; }

    /// <summary>
    /// Moves that the Pokemon can use
    /// </summary>
    public PokeMove?[] Moves { get; }

    /// <summary>
    /// The level the Pokemon is at [1-100]
    /// </summary>
    public int Level { get; }

    /// <summary>
    /// The player whose team contains this
    /// </summary>
    public I_Player Owner { get; set; }

    /// <summary>
    /// The combat instance the fight is happening in
    /// </summary>
    public I_Combat Arena { get; }

    /// <summary>
    /// The passive talent of the Pokemon
    /// </summary>
    public Ability Ability { get; set; }

    /// <summary>
    /// How much health the Pokemon has
    /// </summary>
    public int CurrHP { get; set; }

    /// <summary>
    /// Status effects the Pokemon is afflicted with
    /// </summary>
    public List<StatusEffect> StatusEffects { get; }
    #endregion

    #region Methods
    /// <summary>
    /// Effective HP stat
    /// </summary>
    [Pure]
    public int HP();

    /// <summary>
    /// Effective Atk stat
    /// </summary>
    [Pure]
    public int Atk();

    /// <summary>
    /// Effective Def stat
    /// </summary>
    [Pure]
    public int Def();

    /// <summary>
    /// Effective Special Atk stat
    /// </summary>
    [Pure]
    public int SpAtk();

    /// <summary>
    /// Effective Special Def stat
    /// </summary>
    [Pure]
    public int SpDef();

    /// <summary>
    /// Effective Speed stat
    /// </summary>
    [Pure]
    public int Spd();

    /// <summary>
    /// Get the corresponding effective stat
    /// </summary>
    /// <param name="stat">The stat to get</param>
    /// <exception cref="ArgumentException">Throws when the stat given is not found</exception>
    [Pure]
    public int GetStat(Stat stat);

    /// <summary>
    /// Calculates the damage modifier based on the incoming damage's type
    /// </summary>
    /// <param name="attacker">The incoming damage's type</param>
    /// <returns>Damage multiplier as a double</returns>
    [Pure]
    public double GetAffinity(PokeType attacker);

    /// <summary>
    /// Handles a Pokemon being K.O.
    /// </summary>
    public void DoKO();

    /// <summary>
    /// String representation of the basic status of the battler
    /// </summary>
    [Pure]
    public string GetQuickStatus();

    /// <summary>
    /// String representation of most information about the battler
    /// </summary>
    [Pure]
    public string GetFullStatus();
    #endregion
}