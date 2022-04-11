using Pokedex.Enums;

namespace Pokedex.Models
{
	/// <summary>
	/// Contains the immutable informations of a Pokemon
	/// </summary>
	public abstract class PokeSpecies
	{
		#region Properties
		/// <summary>
		/// ID of the Pokemon in the Pokedex
		/// </summary>
		public int ID { get; }

		/// <summary>
		/// Name of the species the Pokemon belongs to
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Types the Pokemon posseses
		/// </summary>
		public List<PokeType> Types { get; }

		/// <summary>
		/// Stats at level 50
		/// </summary>
		public Dictionary<Stat, int> Stats { get; }

		/// <summary>
		/// Which generation was the Pokemon introduced in
		/// </summary>
		public int Generation { get; }

		/// <summary>
		/// What type the species is
		/// </summary>
		public string Genus { get; }

		/// <summary>
		/// What class the Pokemon is
		/// </summary>
		public PokeClass Class { get; }

		/// <summary>
		/// How tall is the Pokemon
		/// </summary>
		public int Height { get; }

		/// <summary>
		/// How much the Pokemon weights
		/// </summary>
		public int Weight { get; }
		#endregion

		#region Constructors
		public PokeSpecies(
			int id, string name,
			List<PokeType> types,
			Dictionary<Stat, int> stats,

			int generation, string genus, PokeClass class_,
			int height, int weight
		)
		{
			this.ID = id;
			this.Name = name;
			this.Types = types;
			this.Stats = stats;
			this.Generation = generation;
			this.Genus = genus;
			this.Class = class_;
			this.Height = height;
			this.Weight = weight;
		}
		#endregion
	}
}