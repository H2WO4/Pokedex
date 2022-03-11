using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_Combat
	{
		#region Properties
		// Players
		public Trainer PlayerA { get; }
		public Trainer PlayerB { get; }

		// System
		public Queue<I_Event> EventQueue { get; }

		// Terrain Effects
		public Weather Weather { get; set; }
		#endregion

		#region Methods
		public void AddToBottom(I_Event ev);
		public void AddToTop(I_Event ev);

		public bool DoTurn();
		#endregion
	}
}