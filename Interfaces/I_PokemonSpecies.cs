using Pokedex.Models;
using Pokedex.Enums;

namespace Pokedex.Interfaces
{
	public interface I_PokemonSpecies
	{
		# region Properties
		// Important Infos
		int ID { get; }
		string Name { get; }
		List<PokemonType> Types { get; }
		Dictionary<string, int> Stats { get; }

		// Flavor
		string Genus { get; }
		PokeClass Class { get; }
		int Height { get; }
		int Weight { get; }
		int Generation { get; }
		# endregion
	}
}