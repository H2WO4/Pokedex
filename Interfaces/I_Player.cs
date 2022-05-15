using System.Diagnostics.CodeAnalysis;

namespace Pokedex.Interfaces;

/// <summary>
/// Classes implementing this interface can participate in combat
/// </summary>
public interface I_Player
{
    #region Properties
    /// <summary>
    /// Name used for display
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Pokemon that will execute the orders
    /// </summary>
    public I_Battler Active { get; }

    /// <summary>
    /// Pokemons held by the player, including their active one
    /// </summary>
    public I_Battler[] Team { get; }

    /// <summary>
    /// The combat instance the fight is happening in
    /// </summary>
    [NotNull]
    public I_Combat? Arena { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Called during the player's turn
    /// </summary>
    public void PlayTurn();

    /// <summary>
    /// Change the player's active Pokemon to the one with the corresponding index
    /// </summary>
    /// <param name="index">The index of the Pokemon to switch to</param>
    /// <param name="forced">Whether this change was intended by the player</param>
    public void ChangeActive(int index, bool forced = false);

    /// <summary>
    /// Give control to the player and let them change their active Pokemon
    /// </summary>
    public void AskActiveChange();
    #endregion
}