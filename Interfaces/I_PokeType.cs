using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_PokeType
	{
		#region Properties
		string Name { get; }
		(int R, int G, int B) Color { get; }
		#endregion
	}
}