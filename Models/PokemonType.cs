using System.Text;
using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public abstract class PokemonType : I_PokemonType
	{
		# region Variables
		protected string _name = "";
		protected (int, int, int) _color = (0, 0, 0);
		# endregion

		# region Class Variables
		public static Dictionary<string, Dictionary<string, double>> _affinities = new Dictionary<string, Dictionary<string, double>>();
		# endregion

		# region Properties
		public string Name { get => _name; }
		public (int, int, int) Color { get => _color; }
		# endregion

		# region Constructor
		public PokemonType
		(
			string name,
			(int R, int G, int B) color
		)
		{
			if (name != "")
				this._name = name;
			else throw new ArgumentException("Name must not be empty");

			if (color.R >= 0 && color.R <= 255 &&
				color.G >= 0 && color.G <= 255 &&
				color.B >= 0 && color.B <= 255)
				this._color = color;
			else throw new ArgumentException("Color channels must be between 0-255");

			_affinities[name] = new Dictionary<string, double>();
		}
		# endregion

		# region Methods
		// GetWeakness
		public static double GetAffinity(PokemonType attacker, PokemonType defender) =>
			_affinities[attacker.Name][defender.Name];
		public static double GetAffinity(string attacker, string defender) =>
			_affinities[attacker][defender];

		// SetWeakness
		public static void SetAffinity(PokemonType attacker, PokemonType defender, double value) =>
			_affinities[attacker.Name][defender.Name] = value;
		public static void SetAffinity(string attacker, string defender, double value) =>
			_affinities[attacker][defender] = value;

		// SetWeaknesses
		public void SetAffinities(Dictionary<PokemonType, double> weaknesses) =>
			weaknesses
				.ToList()
				.ForEach(pair => PokemonType.SetAffinity(this, pair.Key, pair.Value));
		public void SetAffinities(Dictionary<string, double> weaknesses) =>
			weaknesses
				.ToList()
				.ForEach(pair => PokemonType.SetAffinity(this.Name, pair.Key, pair.Value));

		// Static CalculateWeakness
		public static double CalculateAffinity(PokemonType attacker, IEnumerable<PokemonType> defenders) =>
			defenders
				.Select(defender => GetAffinity(attacker, defender))
				.Aggregate((a,b) => a * b);
		
		// Non-Static CalculateWeakness
		public double CalculateAffinity(IEnumerable<PokemonType> defenders) =>
			PokemonType.CalculateAffinity(this, defenders);

		public static void DisplayAffinityTable()
		{
			List<(string type, string name)> types = _affinities
				.Select(pair => pair.Key)
				.Select(name => name.Length >= 7
						? (name, name.Substring(0, 5) + '.')
						: (name, name))
				.ToList();

			int maxLen = types.Select(type => type.name.Length).Max()+1;
			var output = new StringBuilder("".PadRight(maxLen+1));
			
			types.ForEach(defender =>
				output.Append(' ' + defender.name
									.PadLeft(maxLen - (maxLen-defender.name.Length)/2)
									.PadRight(maxLen)));
			output.AppendLine();

			types.ForEach(attacker => {
				output.Append(attacker.name
								.PadLeft(maxLen - (maxLen-attacker.name.Length)/2)
								.PadRight(maxLen)+ ' ');
				types.Select(type => GetAffinity(attacker.type, type.type))
					.Select(affinity => affinity == 0 ? "-" :
										affinity == 0.5 ? "1/2" :
										affinity == 1 ? "" :
										"2")
					.ToList()
					.ForEach(affinity => output
						.Append('|' + affinity
						.PadLeft(maxLen - (maxLen-affinity.Length)/2)
						.PadRight(maxLen))
					);
				output.AppendLine("|");
			});

			Console.WriteLine(output);
		}
		
		public override string ToString() => this._name;
		# endregion
	}
}