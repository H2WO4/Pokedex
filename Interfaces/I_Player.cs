using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_Player
	{
		#region Properties
		Pokemon Active { get; }
		List<Pokemon> Team { get; }
		string Name { get; }
		#endregion

		#region Methods
		int ChangeActive(int index);
		void PlayTurn();
		#endregion
	}
}