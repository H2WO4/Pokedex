using System.Text;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models
{
	/// <summary>
	/// The type of a Pokemon, Move, or DamageInfo
	/// </summary>
	public abstract class PokeType
	{
		#region Class Variables
		public static Dictionary<PokeType, Dictionary<PokeType, double>> Affinities = new Dictionary<PokeType, Dictionary<PokeType, double>>();
		#endregion

		#region Properties
		/// <summary>
		/// Name used for display
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Color used for display
		/// </summary>
		private (int R, int G, int B) Color { get; }
		#endregion

		#region Constructor
		public PokeType
		(
			string name,
			(int R, int G, int B) color
		)
		{
			if (name != "")
				Name = name;
			else throw new ArgumentException("Name must not be empty");

			if (color.R >= 0 && color.R <= 255 &&
				color.G >= 0 && color.G <= 255 &&
				color.B >= 0 && color.B <= 255)
				Color = color;
			else throw new ArgumentException("Color channels must be between 0-255");

			Affinities[this] = new Dictionary<PokeType, double>();
		}
		#endregion

		#region Methods
		public static void InitializeTypes()
		{
			Affinities = new Dictionary<PokeType, Dictionary<PokeType, double>>()
			{
				{ TypeNormal.Singleton, new() },
				{ TypeFire.Singleton, new() },
				{ TypeWater.Singleton, new() },
				{ TypeElectric.Singleton, new() },
				{ TypeGrass.Singleton, new() },
				{ TypeIce.Singleton, new() },
				{ TypeFighting.Singleton, new() },
				{ TypePoison.Singleton, new() },
				{ TypeGround.Singleton, new() },
				{ TypeFlying.Singleton, new() },
				{ TypePsychic.Singleton, new() },
				{ TypeBug.Singleton, new() },
				{ TypeRock.Singleton, new() },
				{ TypeGhost.Singleton, new() },
				{ TypeDragon.Singleton, new() },
				{ TypeDark.Singleton, new() },
				{ TypeSteel.Singleton, new() },
				{ TypeFairy.Singleton, new() },
				{ TypeLight.Singleton, new() },
			};

			TypeNormal.Singleton.SetAffinities(new()
			{
				{TypeRock.Singleton, 0.5},
				{TypeGhost.Singleton, 0},
				{TypeSteel.Singleton, 0.5},
				{TypeFairy.Singleton, 2},
			});
			TypeFire.Singleton.SetAffinities(new()
			{
				{TypeFire.Singleton, 0.5},
				{TypeWater.Singleton, 0.5},
				{TypeGrass.Singleton, 2},
				{TypeIce.Singleton, 2},
				{TypeBug.Singleton, 2},
				{TypeRock.Singleton, 0.5},
				{TypeDragon.Singleton, 0.5},
				{TypeSteel.Singleton, 2},
			});
			TypeWater.Singleton.SetAffinities(new()
			{
				{TypeFire.Singleton, 2},
				{TypeWater.Singleton, 0.5},
				{TypeGrass.Singleton, 0.5},
				{TypeGround.Singleton, 2},
				{TypeRock.Singleton, 2},
				{TypeDragon.Singleton, 0.5},
				{TypeLight.Singleton, 0.5}
			});
			TypeElectric.Singleton.SetAffinities(new()
			{
				{TypeFire.Singleton, 2},
				{TypeWater.Singleton, 2},
				{TypeElectric.Singleton, 0.5},
				{TypeGrass.Singleton, 0.5},
				{TypeGround.Singleton, 0},
				{TypeFlying.Singleton, 2},
				{TypeDragon.Singleton, 0.5},
				{TypeLight.Singleton, 0.5}
			});
			TypeGrass.Singleton.SetAffinities(new()
			{
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
			TypeIce.Singleton.SetAffinities(new()
			{
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
			TypeFighting.Singleton.SetAffinities(new()
			{
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
			TypePoison.Singleton.SetAffinities(new()
			{
				{TypeGrass.Singleton, 2},
				{TypePoison.Singleton, 0.5},
				{TypeGround.Singleton, 0.5},
				{TypeRock.Singleton, 0.5},
				{TypeGhost.Singleton, 0.5},
				{TypeSteel.Singleton, 0},
				{TypeFairy.Singleton, 2},
			});
			TypeGround.Singleton.SetAffinities(new()
			{
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
			TypeFlying.Singleton.SetAffinities(new()
			{
				{TypeElectric.Singleton, 0.5},
				{TypeGrass.Singleton, 2},
				{TypeFighting.Singleton, 2},
				{TypeFlying.Singleton, 0.5},
				{TypeBug.Singleton, 2},
				{TypeRock.Singleton, 0.5},
				{TypeSteel.Singleton, 0.5},
			});
			TypePsychic.Singleton.SetAffinities(new()
			{
				{TypeNormal.Singleton, 0.5},
				{TypeFighting.Singleton, 2},
				{TypePoison.Singleton, 2},
				{TypePsychic.Singleton, 0.5},
				{TypeDark.Singleton, 0},
				{TypeSteel.Singleton, 2},
				{TypeLight.Singleton, 2}
			});
			TypeBug.Singleton.SetAffinities(new()
			{
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
			TypeRock.Singleton.SetAffinities(new()
			{
				{TypeFire.Singleton, 2},
				{TypeIce.Singleton, 2},
				{TypeFighting.Singleton, 0.5},
				{TypeGround.Singleton, 0.5},
				{TypeFlying.Singleton, 2},
				{TypeBug.Singleton, 2},
				{TypeSteel.Singleton, 0.5}
			});
			TypeGhost.Singleton.SetAffinities(new()
			{
				{TypeNormal.Singleton, 0},
				{TypePsychic.Singleton, 2},
				{TypeGhost.Singleton, 2},
				{TypeDark.Singleton, 0.5},
			});
			TypeDragon.Singleton.SetAffinities(new()
			{
				{TypeIce.Singleton, 0.5},
				{TypeFlying.Singleton, 2},
				{TypeDragon.Singleton, 2},
				{TypeSteel.Singleton, 0.5}, {TypeFairy.Singleton, 0},
				{TypeLight.Singleton, 2}
			});
			TypeDark.Singleton.SetAffinities(new()
			{
				{TypeFighting.Singleton, 0.5},
				{TypePsychic.Singleton, 2},
				{TypeGhost.Singleton, 2},
				{TypeDark.Singleton, 0.5},
				{TypeFairy.Singleton, 0.5},
				{TypeLight.Singleton, 2}
			});
			TypeSteel.Singleton.SetAffinities(new()
			{
				{TypeFire.Singleton, 0.5},
				{TypeWater.Singleton, 0.5},
				{TypeElectric.Singleton, 0.5},
				{TypeIce.Singleton, 2},
				{TypeRock.Singleton, 2},
				{TypeSteel.Singleton, 0.5},
				{TypeFairy.Singleton, 2},
			});
			TypeFairy.Singleton.SetAffinities(new()
			{
				{TypeFire.Singleton, 0.5},
				{TypeFighting.Singleton, 2},
				{TypePoison.Singleton, 0.5},
				{TypeDragon.Singleton, 2},
				{TypeDark.Singleton, 2},
				{TypeSteel.Singleton, 0.5},
				{TypeLight.Singleton, 0}
			});
			TypeLight.Singleton.SetAffinities(new()
			{
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

		private static double GetAffinity(PokeType attacker, PokeType defender)
			=> Affinities[attacker].GetValueOrDefault(defender, 1);

		private static void SetAffinity(PokeType attacker, PokeType defender, double value)
			=> Affinities[attacker][defender] = value;

		private void SetAffinities(Dictionary<PokeType, double> weaknesses)
			=> weaknesses
				.ToList()
				.ForEach(pair => SetAffinity(this, pair.Key, pair.Value));

		public double CalculateAffinity(IEnumerable<PokeType> defenders)
			=> defenders
				.Select(defender => GetAffinity(this, defender))
				.Aggregate((a, b) => a * b);

		public static void DisplayAffinityTable()
		{
			(PokeType type, string name)[] types = Affinities
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

			Array.ForEach(types, attacker
			=> {
				output.Append(attacker.name
								.PadLeft(maxLen - (maxLen - attacker.name.Length) / 2)
								.PadRight(maxLen) + ' ');
				types.Select(type => GetAffinity(attacker.type, type.type))
					.Select(affinity => affinity switch
						{
							0 => "-",
							0.5 => "1/2",
							1 => "",
							_ => "2"
						})
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
			=> $"\x1b[38;2;{Color.R};{Color.G};{Color.B}m{Name}\x1b[0m";
		#endregion
	}
}