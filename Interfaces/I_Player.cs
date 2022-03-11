using Pokedex.Models;

namespace Pokedex.Interfaces
{
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
		Pokemon Active { get; }

		/// <summary>
		/// Pokemons held by the player, including their active one
		/// </summary>
		Pokemon[] Team { get; }

		I_Combat Arena { get; }
		#endregion

		#region Methods
		/// <summary>
		/// Called during the player's turn
		/// </summary>
		void PlayTurn();
		#endregion
	}
}