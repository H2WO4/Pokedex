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
    string Name { get; }

    /// <summary>
    /// Types used for damage calculation
    /// </summary>
    List<PokeType> Types { get; }

    /// <summary>
    /// Moves that the Pokemon can use
    /// </summary>
    PokeMove?[] Moves { get; }

    /// <summary>
    /// The level the Pokemon is at [1-100]
    /// </summary>
    int Level { get; }

    /// <summary>
    /// The player whose team contains this
    /// </summary>
    I_Player Owner { get; set; }

    /// <summary>
    /// The combat instance the fight is happening in
    /// </summary>
    I_Combat Arena { get; }

    /// <summary>
    /// The passive talent of the Pokemon
    /// </summary>
    Ability Ability { get; set; }

    /// <summary>
    /// How much health the Pokemon has
    /// </summary>
    int CurrHP { get; set; }

    /// <summary>
    /// Status effects the Pokemon is afflicted with
    /// </summary>
    List<StatusEffect> StatusEffects { get; }
    #endregion

    #region Methods
    /// <summary>
    /// Effective HP stat
    /// </summary>
    int HP();

    /// <summary>
    /// Effective Atk stat
    /// </summary>
    int Atk();

    /// <summary>
    /// Effective Def stat
    /// </summary>
    int Def();

    /// <summary>
    /// Effective Special Atk stat
    /// </summary>
    int SpAtk();

    /// <summary>
    /// Effective Special Def stat
    /// </summary>
    int SpDef();

    /// <summary>
    /// Effective Speed stat
    /// </summary>
    int Spd();

    /// <summary>
    /// Get the corresponding effective stat
    /// </summary>
    /// <param name="stat">The stat to get</param>
    /// <exception cref="ArgumentException">Throws when the stat given is not found</exception>
    int GetStat(Stat stat);

    /// <summary>
    /// Calculates the damage modifier based on the incoming damage's type
    /// </summary>
    /// <param name="attacker">The incoming damage's type</param>
    /// <returns>Damage multiplier as a double</returns>
    double GetAffinity(PokeType attacker);

    /// <summary>
    /// Handles a Pokemon being K.O.
    /// </summary>
    void DoKO();

    /// <summary>
    /// String representation of the basic status of the battler
    /// </summary>
    string GetQuickStatus();

    /// <summary>
    /// String representation of most information about the battler
    /// </summary>
    string GetFullStatus();
    #endregion
}