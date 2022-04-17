using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Events;

namespace Pokedex.Interfaces;

/// <summary>
/// Classes implementing this interface can be used by Pokemons
/// </summary>
public interface I_PokeMove
{
    #region Properties
    /// <summary>
    /// Name used for display
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The class the move belongs to
    /// </summary>
    MoveClass Class { get; }

    /// <summary>
    /// The damaging power of the move
    /// </summary>
    int? Power { get; }

    /// <summary>
    /// The chance out of 100 that the move has to hit its target
    /// </summary>
    int? Accuracy { get; }

    /// <summary>
    /// The type of the damage inflicted
    /// </summary>
    PokeType Type { get; }

    /// <summary>
    /// How much PP the move can have
    /// </summary>
    int MaxPP { get; }

    /// <summary>
    /// How much PP the move currently has
    /// </summary>
    int PP { get; }

    /// <summary>
    /// How much priority the event of using the move has in the event queue
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// The Pokemon who uses the move
    /// </summary>
    I_Battler Caster { get; }

    /// <summary>
    /// The combat instance the fight is happening in
    /// </summary>
    I_Combat Arena { get; }
    #endregion

    #region Methods
    /// <summary>
    /// Called when the move is used
    /// </summary>
    void OnUse();

    /// <summary>
    /// Called before the queue is sorted
    /// </summary>
    /// <param name="ev">The event that uses this move</param>
    void PreAction(MoveEvent ev);
    #endregion
}