using Pokedex.Models;

namespace Pokedex.Interfaces
{
	/// <summary>
	/// Classes implementing this interface can host a fight between multiple players
	/// </summary>
	public interface I_Combat
	{
		#region Properties
		/// <summary>
		/// The list of all players in combat
		/// </summary>
		I_Player[] Players { get; }

		/// <summary>
		/// The list of all currently scheduled events
		/// </summary>
		Queue<I_Event> EventQueue { get; }

		/// <summary>
		/// The currently active weather on the field
		/// </summary>
		Weather Weather { get; set; }
		#endregion

		#region Methods
		/// <summary>
		/// Add an event to the end of the queue
		/// </summary>
		/// <param name="ev">The event to add</param>
		void AddToBottom(I_Event ev);

		/// <summary>
		/// Add an event to the start of the queue
		/// </summary>
		/// <param name="ev">The event to add</param>
		void AddToTop(I_Event ev);

		/// <summary>
		/// Called during a full game turn
		/// </summary>
		/// <returns>The player that won the fight</returns>
		I_Player DoTurn();
		#endregion
	}
}