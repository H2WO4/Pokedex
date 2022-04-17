using System.Diagnostics.CodeAnalysis;

using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models;

/// <summary>
///     The type of a Pokemon, Move, or DamageInfo
/// </summary>
public abstract class PokeType
{
	#region Constructor
	protected PokeType
	(
		string name,
		(int R, int G, int B) color
	)
	{
		if (name != "")
			Name = name;
		else throw new ArgumentException("Name must not be empty");

		if (color.R is >= 0 and <= 255
		 && color.G is >= 0 and <= 255
		 && color.B is >= 0 and <= 255)
			Color = color;
		else throw new ArgumentException("Color channels must be between 0-255");
	}
	#endregion

	#region Class Properties
	/// <summary>
	///     Represents the damage relations between types
	/// </summary>
	[NotNull]
	public static Dictionary<PokeType, Dictionary<PokeType, double>>? Affinities { get; private set; }
	#endregion

	#region Properties
	/// <summary>
	///     Name used for display
	/// </summary>
	public string Name { get; }

	/// <summary>
	///     Color used for display
	/// </summary>
	private (int R, int G, int B) Color { get; }
	#endregion

	#region Methods
	/// <summary>
	///     Initializes type resistances
	/// </summary>
	/// <remarks>
	///     Should be called at the beginning of the program
	/// </remarks>
	public static void InitializeTypes()
	{
		Affinities =
			new Dictionary<PokeType, Dictionary<PokeType, double>>
			{
				{ TypeNormal.Singleton, new() }, { TypeFire.Singleton, new() },
				{ TypeWater.Singleton, new() }, { TypeElectric.Singleton, new() },
				{ TypeGrass.Singleton, new() }, { TypeIce.Singleton, new() },
				{ TypeFighting.Singleton, new() }, { TypePoison.Singleton, new() },
				{ TypeGround.Singleton, new() }, { TypeFlying.Singleton, new() },
				{ TypePsychic.Singleton, new() }, { TypeBug.Singleton, new() },
				{ TypeRock.Singleton, new() }, { TypeGhost.Singleton, new() },
				{ TypeDragon.Singleton, new() }, { TypeDark.Singleton, new() },
				{ TypeSteel.Singleton, new() }, { TypeFairy.Singleton, new() },
				{ TypeLight.Singleton, new() },
			};

		Dictionary<PokeType, double> normal =
			new()
			{
				{ TypeRock.Singleton, 0.5 }, { TypeGhost.Singleton, 0 },
				{ TypeSteel.Singleton, 0.5 }, { TypeFairy.Singleton, 2 },
			};
		TypeNormal.Singleton.SetAffinities(normal);

		Dictionary<PokeType, double> fire =
			new()
			{
				{ TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 0.5 },
				{ TypeGrass.Singleton, 2 }, { TypeIce.Singleton, 2 },
				{ TypeBug.Singleton, 2 }, { TypeRock.Singleton, 0.5 },
				{ TypeDragon.Singleton, 0.5 }, { TypeSteel.Singleton, 2 },
			};
		TypeFire.Singleton.SetAffinities(fire);

		Dictionary<PokeType, double> water =
			new()
			{
				{ TypeFire.Singleton, 2 }, { TypeWater.Singleton, 0.5 },
				{ TypeGrass.Singleton, 0.5 }, { TypeGround.Singleton, 2 },
				{ TypeRock.Singleton, 2 }, { TypeDragon.Singleton, 0.5 },
				{ TypeLight.Singleton, 0.5 },
			};
		TypeWater.Singleton.SetAffinities(water);

		Dictionary<PokeType, double> electric =
			new()
			{
				{ TypeFire.Singleton, 2 }, { TypeWater.Singleton, 2 },
				{ TypeElectric.Singleton, 0.5 }, { TypeGrass.Singleton, 0.5 },
				{ TypeGround.Singleton, 0 }, { TypeFlying.Singleton, 2 },
				{ TypeDragon.Singleton, 0.5 }, { TypeLight.Singleton, 0.5 },
			};
		TypeElectric.Singleton.SetAffinities(electric);

		Dictionary<PokeType, double> grass =
			new()
			{
				{ TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 2 },
				{ TypeGrass.Singleton, 0.5 }, { TypePoison.Singleton, 0.5 },
				{ TypeGround.Singleton, 2 }, { TypeFlying.Singleton, 0.5 },
				{ TypeBug.Singleton, 0.5 }, { TypeRock.Singleton, 2 },
				{ TypeDragon.Singleton, 0.5 }, { TypeSteel.Singleton, 0.5 },
			};
		TypeGrass.Singleton.SetAffinities(grass);

		Dictionary<PokeType, double> ice =
			new()
			{
				{ TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 0.5 },
				{ TypeGrass.Singleton, 2 }, { TypeIce.Singleton, 0.5 },
				{ TypeGround.Singleton, 2 }, { TypeFlying.Singleton, 2 },
				{ TypeDragon.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
				{ TypeLight.Singleton, 2 },
			};
		TypeIce.Singleton.SetAffinities(ice);

		Dictionary<PokeType, double> fighting =
			new()
			{
				{ TypeNormal.Singleton, 2 }, { TypeIce.Singleton, 2 },
				{ TypePoison.Singleton, 0.5 }, { TypeFlying.Singleton, 0.5 },
				{ TypePsychic.Singleton, 0.5 }, { TypeBug.Singleton, 0.5 },
				{ TypeRock.Singleton, 2 }, { TypeGhost.Singleton, 0 },
				{ TypeDark.Singleton, 2 }, { TypeSteel.Singleton, 2 },
				{ TypeFairy.Singleton, 0.5 },
			};
		TypeFighting.Singleton.SetAffinities(fighting);

		Dictionary<PokeType, double> poison =
			new()
			{
				{ TypeGrass.Singleton, 2 }, { TypePoison.Singleton, 0.5 },
				{ TypeGround.Singleton, 0.5 }, { TypeRock.Singleton, 0.5 },
				{ TypeGhost.Singleton, 0.5 }, { TypeSteel.Singleton, 0 },
				{ TypeFairy.Singleton, 2 },
			};
		TypePoison.Singleton.SetAffinities(poison);

		Dictionary<PokeType, double> ground =
			new()
			{
				{ TypeFire.Singleton, 2 }, { TypeElectric.Singleton, 2 },
				{ TypeGrass.Singleton, 0.5 }, { TypePoison.Singleton, 2 },
				{ TypeFlying.Singleton, 0 }, { TypeBug.Singleton, 0.5 },
				{ TypeRock.Singleton, 2 }, { TypeSteel.Singleton, 2 },
				{ TypeLight.Singleton, 0.5 },
			};
		TypeGround.Singleton.SetAffinities(ground);

		Dictionary<PokeType, double> flying =
			new()
			{
				{ TypeElectric.Singleton, 0.5 }, { TypeGrass.Singleton, 2 },
				{ TypeFighting.Singleton, 2 }, { TypeFlying.Singleton, 0.5 },
				{ TypeBug.Singleton, 2 }, { TypeRock.Singleton, 0.5 },
				{ TypeSteel.Singleton, 0.5 },
			};
		TypeFlying.Singleton.SetAffinities(flying);

		Dictionary<PokeType, double> psychic =
			new()
			{
				{ TypeNormal.Singleton, 0.5 }, { TypeFighting.Singleton, 2 },
				{ TypePoison.Singleton, 2 }, { TypePsychic.Singleton, 0.5 },
				{ TypeDark.Singleton, 0 }, { TypeSteel.Singleton, 2 },
				{ TypeLight.Singleton, 2 },
			};
		TypePsychic.Singleton.SetAffinities(psychic);

		Dictionary<PokeType, double> bug =
			new()
			{
				{ TypeFire.Singleton, 0.5 }, { TypeElectric.Singleton, 0.5 },
				{ TypeGrass.Singleton, 2 }, { TypeFighting.Singleton, 0.5 },
				{ TypePoison.Singleton, 0.5 }, { TypeFlying.Singleton, 0.5 },
				{ TypePsychic.Singleton, 2 }, { TypeGhost.Singleton, 0.5 },
				{ TypeDark.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
				{ TypeFairy.Singleton, 0.5 },
			};
		TypeBug.Singleton.SetAffinities(bug);

		Dictionary<PokeType, double> rock =
			new()
			{
				{ TypeFire.Singleton, 2 }, { TypeIce.Singleton, 2 },
				{ TypeFighting.Singleton, 0.5 }, { TypeGround.Singleton, 0.5 },
				{ TypeFlying.Singleton, 2 }, { TypeBug.Singleton, 2 },
				{ TypeSteel.Singleton, 0.5 },
			};
		TypeRock.Singleton.SetAffinities(rock);

		Dictionary<PokeType, double> ghost =
			new()
			{
				{ TypeNormal.Singleton, 0 }, { TypePsychic.Singleton, 2 },
				{ TypeGhost.Singleton, 2 }, { TypeDark.Singleton, 0.5 },
			};
		TypeGhost.Singleton.SetAffinities(ghost);

		Dictionary<PokeType, double> dragon =
			new()
			{
				{ TypeIce.Singleton, 0.5 }, { TypeFlying.Singleton, 2 },
				{ TypeDragon.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
				{ TypeFairy.Singleton, 0 }, { TypeLight.Singleton, 2 },
			};
		TypeDragon.Singleton.SetAffinities(dragon);

		Dictionary<PokeType, double> dark =
			new()
			{
				{ TypeFighting.Singleton, 0.5 }, { TypePsychic.Singleton, 2 },
				{ TypeGhost.Singleton, 2 }, { TypeDark.Singleton, 0.5 },
				{ TypeFairy.Singleton, 0.5 }, { TypeLight.Singleton, 2 },
			};
		TypeDark.Singleton.SetAffinities(dark);

		Dictionary<PokeType, double> steel =
			new()
			{
				{ TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 0.5 },
				{ TypeElectric.Singleton, 0.5 }, { TypeIce.Singleton, 2 },
				{ TypeRock.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
				{ TypeFairy.Singleton, 2 },
			};
		TypeSteel.Singleton.SetAffinities(steel);

		Dictionary<PokeType, double> fairy =
			new()
			{
				{ TypeFire.Singleton, 0.5 }, { TypeFighting.Singleton, 2 },
				{ TypePoison.Singleton, 0.5 }, { TypeDragon.Singleton, 2 },
				{ TypeDark.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
				{ TypeLight.Singleton, 0 },
			};
		TypeFairy.Singleton.SetAffinities(fairy);

		Dictionary<PokeType, double> light =
			new()
			{
				{ TypeWater.Singleton, 2 }, { TypeElectric.Singleton, 2 },
				{ TypeIce.Singleton, 0.5 }, { TypeGround.Singleton, 0.5 },
				{ TypeGhost.Singleton, 2 }, { TypeDark.Singleton, 2 },
				{ TypeFairy.Singleton, 0 }, { TypeLight.Singleton, 0.5 },
			};
		TypeLight.Singleton.SetAffinities(light);
	}

	public double GetAffinity(PokeType defender)
	{
		return Affinities[this].GetValueOrDefault(defender, 1);
	}

	public void SetAffinity(PokeType defender, double value)
	{
		Affinities[this][defender] = value;
	}

	private void SetAffinities(Dictionary<PokeType, double> weaknesses)
	{
		foreach ((PokeType type, double value) in weaknesses)
			SetAffinity(type, value);
	}

	/// <summary>
	///     Calculate the compound damage resistance between this and other types
	/// </summary>
	/// <param name="defenders">The types of the defending pokemon</param>
	public double CalculateAffinity(IEnumerable<PokeType> defenders)
	{
		return defenders
			  .Select(GetAffinity)
			  .Aggregate((a, b) => a * b);
	}

	public override string ToString()
	{
		return Name;
	}
	#endregion
}