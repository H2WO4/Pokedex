using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_Pokemon
	{
		# region Properties
		// Inherited from the Species
		int ID { get; }
		string Name { get; }
		PokemonSpecies Species { get; }
		public List<PokemonType> Types { get; }
		public Dictionary<string, int> BaseStats { get; }

		// Unique per Pokemon
		int Level { get; }
		string Nickname { get; set; }
		Dictionary<string, int> IVs { get; }
		Dictionary<string, int> EVs { get; }

		PokemonSkill[] Moves { get; }

		// Stats
		int HP { get; }
		int Atk { get; }
		int Def { get; }
		int SpAtk { get; }
		int SpDef { get; }
		int Spd { get; }
		# endregion

		# region Methods
		void SetIV(string stat, int val);
		void SetIVs(int hp, int atk, int def, int spAtk, int spDef, int spd);
		void SetMoves(PokemonSkill move1, PokemonSkill move2, PokemonSkill move3, PokemonSkill move4);
		double getAffinity(PokemonType attacker);
		# endregion
	}
}