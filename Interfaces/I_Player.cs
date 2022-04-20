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
    string Name { get; }

    /// <summary>
    /// Pokemon that will execute the orders
    /// </summary>
    I_Battler Active { get; }

    /// <summary>
    /// Pokemons held by the player, including their active one
    /// </summary>
    I_Battler[] Team { get; }

    /// <summary>
    /// The combat instance the fight is happening in
    /// </summary>
    I_Combat? Arena { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Called during the player's turn
    /// </summary>
    void PlayTurn();

    /// <summary>
    /// Change the player's active Pokemon to the one with the corresponding index
    /// </summary>
    /// <param name="index">The index of the Pokemon to switch to</param>
    void ChangeActive(int index);

    /// <summary>
    /// Give control to the player and let them change their active Pokemon
    /// </summary>
    void AskActiveChange();
    #endregion
}