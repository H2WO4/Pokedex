using System.Text;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models
{
	public abstract class PokeType : I_PokeType
	{
		#region Variables
		protected string _name = "";
		protected (int R, int G, int B) _color = (0, 0, 0);
		#endregion

		#region Class Variables
		public static Dictionary<PokeType, Dictionary<PokeType, double>> __affinities = new Dictionary<PokeType, Dictionary<PokeType, double>>();
		#endregion

		#region Properties
		public string Name { get => _name; }
		public (int, int, int) Color { get => _color; }
		#endregion

		#region Constructor
		public PokeType
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

			__affinities[this] = new Dictionary<PokeType, double>();
		}
		#endregion

		#region Methods
		public static void InitializeTypes()
		{
			__affinities = new Dictionary<PokeType, Dictionary<PokeType, double>>()
			{
				{ TypeNormal.Singleton, new Dictionary<PokeType, double>() },
				{ TypeFire.Singleton, new Dictionary<PokeType, double>() },
				{ TypeWater.Singleton, new Dictionary<PokeType, double>() },
				{ TypeElectric.Singleton, new Dictionary<PokeType, double>() },
				{ TypeGrass.Singleton, new Dictionary<PokeType, double>() },
				{ TypeIce.Singleton, new Dictionary<PokeType, double>() },
				{ TypeFighting.Singleton, new Dictionary<PokeType, double>() },
				{ TypePoison.Singleton, new Dictionary<PokeType, double>() },
				{ TypeGround.Singleton, new Dictionary<PokeType, double>() },
				{ TypeFlying.Singleton, new Dictionary<PokeType, double>() },
				{ TypePsychic.Singleton, new Dictionary<PokeType, double>() },
				{ TypeBug.Singleton, new Dictionary<PokeType, double>() },
				{ TypeRock.Singleton, new Dictionary<PokeType, double>() },
				{ TypeGhost.Singleton, new Dictionary<PokeType, double>() },
				{ TypeDragon.Singleton, new Dictionary<PokeType, double>() },
				{ TypeDark.Singleton, new Dictionary<PokeType, double>() },
				{ TypeSteel.Singleton, new Dictionary<PokeType, double>() },
				{ TypeFairy.Singleton, new Dictionary<PokeType, double>() },
				{ TypeLight.Singleton, new Dictionary<PokeType, double>() },
			};

			TypeNormal.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeRock.Singleton, 0.5},
				{TypeGhost.Singleton, 0},
				{TypeSteel.Singleton, 0.5},
				{TypeFairy.Singleton, 2},
			});
			TypeFire.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 0.5},
				{TypeWater.Singleton, 0.5},
				{TypeGrass.Singleton, 2},
				{TypeIce.Singleton, 2},
				{TypeBug.Singleton, 2},
				{TypeRock.Singleton, 0.5},
				{TypeDragon.Singleton, 0.5},
				{TypeSteel.Singleton, 2},
			});
			TypeWater.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 2},
				{TypeWater.Singleton, 0.5},
				{TypeGrass.Singleton, 0.5},
				{TypeGround.Singleton, 2},
				{TypeRock.Singleton, 2},
				{TypeDragon.Singleton, 0.5},
				{TypeLight.Singleton, 0.5}
			});
			TypeElectric.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 2},
				{TypeWater.Singleton, 2},
				{TypeElectric.Singleton, 0.5},
				{TypeGrass.Singleton, 0.5},
				{TypeGround.Singleton, 0},
				{TypeFlying.Singleton, 2},
				{TypeDragon.Singleton, 0.5},
				{TypeLight.Singleton, 0.5}
			});
			TypeGrass.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 0.5},
				{TypeWater.Singleton, 2},
				{TypeGrass.Singleton, 0.5},
				{TypePoison.Singleton, 0.5},
				{TypeGround.Singleton, 2},
				{TypeFlying.Singleton, 0.5},
				{TypeBug.Singleton, 0.5},
				{TypeRock.Singleton, 2},
				{TypeDragon.Singleton, 0.5},
				{TypeSteel.Singleton, 0.5},
			});
			TypeIce.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 0.5},
				{TypeWater.Singleton, 0.5},
				{TypeGrass.Singleton, 2},
				{TypeIce.Singleton, 0.5},
				{TypeGround.Singleton, 2},
				{TypeFlying.Singleton, 2},
				{TypeDragon.Singleton, 2},
				{TypeSteel.Singleton, 0.5},
				{TypeLight.Singleton, 2}
			});
			TypeFighting.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeNormal.Singleton, 2},
				{TypeIce.Singleton, 2},
				{TypePoison.Singleton, 0.5},
				{TypeFlying.Singleton, 0.5},
				{TypePsychic.Singleton, 0.5},
				{TypeBug.Singleton, 0.5},
				{TypeRock.Singleton, 2},
				{TypeGhost.Singleton, 0},
				{TypeDark.Singleton, 2},
				{TypeSteel.Singleton, 2},
				{TypeFairy.Singleton, 0.5},
			});
			TypePoison.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeGrass.Singleton, 2},
				{TypePoison.Singleton, 0.5},
				{TypeGround.Singleton, 0.5},
				{TypeRock.Singleton, 0.5},
				{TypeGhost.Singleton, 0.5},
				{TypeSteel.Singleton, 0},
				{TypeFairy.Singleton, 2},
			});
			TypeGround.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 2},
				{TypeElectric.Singleton, 2},
				{TypeGrass.Singleton, 0.5},
				{TypePoison.Singleton, 2},
				{TypeFlying.Singleton, 0},
				{TypeBug.Singleton, 0.5},
				{TypeRock.Singleton, 2},
				{TypeSteel.Singleton, 2},
				{TypeLight.Singleton, 0.5}
			});
			TypeFlying.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeElectric.Singleton, 0.5},
				{TypeGrass.Singleton, 2},
				{TypeFighting.Singleton, 2},
				{TypeFlying.Singleton, 0.5},
				{TypeBug.Singleton, 2},
				{TypeRock.Singleton, 0.5},
				{TypeSteel.Singleton, 0.5},
			});
			TypePsychic.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeNormal.Singleton, 0.5},
				{TypeFighting.Singleton, 2},
				{TypePoison.Singleton, 2},
				{TypePsychic.Singleton, 0.5},
				{TypeDark.Singleton, 0},
				{TypeSteel.Singleton, 2},
				{TypeLight.Singleton, 2}
			});
			TypeBug.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 0.5},
				{TypeElectric.Singleton, 0.5},
				{TypeGrass.Singleton, 2},
				{TypeFighting.Singleton, 0.5},
				{TypePoison.Singleton, 0.5},
				{TypeFlying.Singleton, 0.5},
				{TypePsychic.Singleton, 2},
				{TypeGhost.Singleton, 0.5},
				{TypeDark.Singleton, 2},
				{TypeSteel.Singleton, 0.5},
				{TypeFairy.Singleton, 0.5},
			});
			TypeRock.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 2},
				{TypeIce.Singleton, 2},
				{TypeFighting.Singleton, 0.5},
				{TypeGround.Singleton, 0.5},
				{TypeFlying.Singleton, 2},
				{TypeBug.Singleton, 2},
				{TypeSteel.Singleton, 0.5}
			});
			TypeGhost.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeNormal.Singleton, 0},
				{TypePsychic.Singleton, 2},
				{TypeGhost.Singleton, 2},
				{TypeDark.Singleton, 0.5},
			});
			TypeDragon.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeIce.Singleton, 0.5},
				{TypeFlying.Singleton, 2},
				{TypeDragon.Singleton, 2},
				{TypeSteel.Singleton, 0.5}, {TypeFairy.Singleton, 0},
				{TypeLight.Singleton, 2}
			});
			TypeDark.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFighting.Singleton, 0.5},
				{TypePsychic.Singleton, 2},
				{TypeGhost.Singleton, 2},
				{TypeDark.Singleton, 0.5},
				{TypeFairy.Singleton, 0.5},
				{TypeLight.Singleton, 2}
			});
			TypeSteel.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 0.5},
				{TypeWater.Singleton, 0.5},
				{TypeElectric.Singleton, 0.5},
				{TypeIce.Singleton, 2},
				{TypeRock.Singleton, 2},
				{TypeSteel.Singleton, 0.5},
				{TypeFairy.Singleton, 2},
			});
			TypeFairy.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeFire.Singleton, 0.5},
				{TypeFighting.Singleton, 2},
				{TypePoison.Singleton, 0.5},
				{TypeDragon.Singleton, 2},
				{TypeDark.Singleton, 2},
				{TypeSteel.Singleton, 0.5},
				{TypeLight.Singleton, 0}
			});
			TypeLight.Singleton.SetAffinities(new Dictionary<PokeType, double>(){
				{TypeWater.Singleton, 2},
				{TypeElectric.Singleton, 2},
				{TypeIce.Singleton, 0.5},
				{TypeGround.Singleton, 0.5},
				{TypeGhost.Singleton, 2},
				{TypeDark.Singleton, 2},
				{TypeFairy.Singleton, 0},
				{TypeLight.Singleton, 0.5}
			});
		}

		// GetWeakness
		public static double GetAffinity(PokeType attacker, PokeType defender)
			=> __affinities[attacker].GetValueOrDefault(defender, 1);

		// SetWeakness
		public static void SetAffinity(PokeType attacker, PokeType defender, double value)
			=> __affinities[attacker][defender] = value;

		// SetWeaknesses
		public void SetAffinities(Dictionary<PokeType, double> weaknesses)
			=> weaknesses
				.ToList()
				.ForEach(pair => PokeType.SetAffinity(this, pair.Key, pair.Value));

		// Static CalculateWeakness
		public static double CalculateAffinity(PokeType attacker, IEnumerable<PokeType> defenders)
			=> defenders
				.Select(defender => GetAffinity(attacker, defender))
				.Aggregate((a, b) => a * b);

		// Non-Static CalculateWeakness
		public double CalculateAffinity(IEnumerable<PokeType> defenders)
			=> PokeType.CalculateAffinity(this, defenders);

		public static void DisplayAffinityTable()
		{
			(PokeType type, string name)[] types = __affinities
				.Select(pair => pair.Key)
				.Select(type => type.Name.Length >= 7
						? (type, type.Name.Substring(0, 5) + '.')
						: (type, type.Name))
				.ToArray();

			int maxLen = types.Select(type => type.name.Length).Max() + 1;
			var output = new StringBuilder("".PadRight(maxLen + 1));

			Array.ForEach(types, defender
				=> output.Append(' ' + defender.name
										.PadLeft(maxLen - (maxLen - defender.name.Length) / 2)
										.PadRight(maxLen)
				));
			output.AppendLine();

			Array.ForEach(types, attacker =>
			{
				output.Append(attacker.name
								.PadLeft(maxLen - (maxLen - attacker.name.Length) / 2)
								.PadRight(maxLen) + ' ');
				types.Select(type => GetAffinity(attacker.type, type.type))
					.Select(affinity => affinity == 0 ? "-" :
										affinity == 0.5 ? "1/2" :
										affinity == 1 ? "" :
										"2")
					.ToList()
					.ForEach(affinity => output
						.Append('|' + affinity
						.PadLeft(maxLen - (maxLen - affinity.Length) / 2)
						.PadRight(maxLen))
					);
				output.AppendLine("|");
			});

			Console.WriteLine(output);
		}

		public override string ToString()
			=> $"\x1b[38;2;{this._color.R};{this._color.G};{this._color.B}m{this._name}\x1b[0m";
		#endregion
	}
}