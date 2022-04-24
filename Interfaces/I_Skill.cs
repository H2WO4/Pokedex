using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Events;

namespace Pokedex.Interfaces;

/// <summary>
/// Classes implementing this interface can be used by Pokemons
/// </summary>
public interface I_Skill
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
    int? Power { get; set; }

    /// <summary>
    /// The chance out of 100 that the move has to hit its target
    /// </summary>
    int? Accuracy { get; set; }

    /// <summary>
    /// The type of the damage inflicted
    /// </summary>
    PokeType Type { get; set; }

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

    bool CanThaw { get; }
    #endregion

    #region Methods
    /// <summary>
    /// Called when the move is used
    /// </summary>
    public void OnUse();

    /// <summary>
    /// Get the targets of the move
    /// </summary>
    /// <returns>All targets to be hit by the move</returns>
    public IEnumerable<I_Battler> GetTargets();

    /// <summary>
    /// Checks whether the move hits a target
    /// </summary>
    /// <param name="target">The target to check for</param>
    /// <returns>If the move hits, true, else false</returns>
    public bool AccuracyCheck(I_Battler target);

    /// <summary>
    /// Execute the action of the move unto the target
    /// </summary>
    /// <param name="target">The target to use</param>
    /// <exception cref="InvalidOperationException">Thrown if a status move does not override this</exception>
    public void DoAction(I_Battler target);

    /// <summary>
    /// Called whenever the attack miss a target
    /// </summary>
    /// <param name="target">The target that the attack just missed</param>
    public void OnMiss(I_Battler target);

    /// <summary>
    /// Called whenever a move successfully damage its target
    /// </summary>
    /// <param name="target">The target that was stricken</param>
    public void DoBonusEffects(I_Battler target);

    /// <summary>
    /// Called before the queue is sorted
    /// </summary>
    /// <param name="ev">The event that uses this move</param>
    public void PreAction(MoveEvent ev);
    #endregion
}