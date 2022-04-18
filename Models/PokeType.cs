
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models;

/// <summary>
/// The type of a Pokemon, Move, or DamageInfo
/// </summary>
public abstract class PokeType
{
    #region Class Properties
    private static Dictionary<PokeType, Dictionary<PokeType, double>> Affinities { get; } = new();
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

        Affinities[this] = new Dictionary<PokeType, double>();
    }
    #endregion

    #region Methods
    public static void InitializeTypes()
    {
        Affinities.Add(TypeNormal.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeFire.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeWater.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeElectric.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeGrass.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeIce.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeFighting.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypePoison.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeGround.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeFlying.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypePsychic.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeBug.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeRock.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeGhost.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeDragon.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeDark.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeSteel.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeFairy.Singleton, new Dictionary<PokeType, double>());
        Affinities.Add(TypeLight.Singleton, new Dictionary<PokeType, double>());

        Affinities[TypeNormal.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeRock.Singleton, 0.5 }, { TypeGhost.Singleton, 0 },
                { TypeSteel.Singleton, 0.5 }, { TypeFairy.Singleton, 2 },
            };

        Affinities[TypeFire.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 0.5 },
                { TypeGrass.Singleton, 2 }, { TypeIce.Singleton, 2 },
                { TypeBug.Singleton, 2 }, { TypeRock.Singleton, 0.5 },
                { TypeDragon.Singleton, 0.5 }, { TypeSteel.Singleton, 2 },
            };

        Affinities[TypeWater.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 2 }, { TypeWater.Singleton, 0.5 },
                { TypeGrass.Singleton, 0.5 }, { TypeGround.Singleton, 2 },
                { TypeRock.Singleton, 2 }, { TypeDragon.Singleton, 0.5 },
                { TypeLight.Singleton, 0.5 },
            };

        Affinities[TypeElectric.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 2 }, { TypeWater.Singleton, 2 },
                { TypeElectric.Singleton, 0.5 }, { TypeGrass.Singleton, 0.5 },
                { TypeGround.Singleton, 0 }, { TypeFlying.Singleton, 2 },
                { TypeDragon.Singleton, 0.5 }, { TypeLight.Singleton, 0.5 },
            };

        Affinities[TypeGrass.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 2 },
                { TypeGrass.Singleton, 0.5 }, { TypePoison.Singleton, 0.5 },
                { TypeGround.Singleton, 2 }, { TypeFlying.Singleton, 0.5 },
                { TypeBug.Singleton, 0.5 }, { TypeRock.Singleton, 2 },
                { TypeDragon.Singleton, 0.5 }, { TypeSteel.Singleton, 0.5 },
            };

        Affinities[TypeIce.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 0.5 },
                { TypeGrass.Singleton, 2 }, { TypeIce.Singleton, 0.5 },
                { TypeGround.Singleton, 2 }, { TypeFlying.Singleton, 2 },
                { TypeDragon.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
                { TypeLight.Singleton, 2 },
            };

        Affinities[TypeFighting.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeNormal.Singleton, 2 }, { TypeIce.Singleton, 2 },
                { TypePoison.Singleton, 0.5 }, { TypeFlying.Singleton, 0.5 },
                { TypePsychic.Singleton, 0.5 }, { TypeBug.Singleton, 0.5 },
                { TypeRock.Singleton, 2 }, { TypeGhost.Singleton, 0 },
                { TypeDark.Singleton, 2 }, { TypeSteel.Singleton, 2 },
                { TypeFairy.Singleton, 0.5 },
            };

        Affinities[TypePoison.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeGrass.Singleton, 2 }, { TypePoison.Singleton, 0.5 },
                { TypeGround.Singleton, 0.5 }, { TypeRock.Singleton, 0.5 },
                { TypeGhost.Singleton, 0.5 }, { TypeSteel.Singleton, 0 },
                { TypeFairy.Singleton, 2 },
            };

        Affinities[TypeGround.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 2 }, { TypeElectric.Singleton, 2 },
                { TypeGrass.Singleton, 0.5 }, { TypePoison.Singleton, 2 },
                { TypeFlying.Singleton, 0 }, { TypeBug.Singleton, 0.5 },
                { TypeRock.Singleton, 2 }, { TypeSteel.Singleton, 2 },
                { TypeLight.Singleton, 0.5 },
            };

        Affinities[TypeFlying.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeElectric.Singleton, 0.5 }, { TypeGrass.Singleton, 2 },
                { TypeFighting.Singleton, 2 }, { TypeFlying.Singleton, 0.5 },
                { TypeBug.Singleton, 2 }, { TypeRock.Singleton, 0.5 },
                { TypeSteel.Singleton, 0.5 },
            };

        Affinities[TypePsychic.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeNormal.Singleton, 0.5 }, { TypeFighting.Singleton, 2 },
                { TypePoison.Singleton, 2 }, { TypePsychic.Singleton, 0.5 },
                { TypeDark.Singleton, 0 }, { TypeSteel.Singleton, 2 },
                { TypeLight.Singleton, 2 },
            };

        Affinities[TypeBug.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 0.5 }, { TypeElectric.Singleton, 0.5 },
                { TypeGrass.Singleton, 2 }, { TypeFighting.Singleton, 0.5 },
                { TypePoison.Singleton, 0.5 }, { TypeFlying.Singleton, 0.5 },
                { TypePsychic.Singleton, 2 }, { TypeGhost.Singleton, 0.5 },
                { TypeDark.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
                { TypeFairy.Singleton, 0.5 },
            };

        Affinities[TypeRock.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 2 }, { TypeIce.Singleton, 2 },
                { TypeFighting.Singleton, 0.5 }, { TypeGround.Singleton, 0.5 },
                { TypeFlying.Singleton, 2 }, { TypeBug.Singleton, 2 },
                { TypeSteel.Singleton, 0.5 },
            };

        Affinities[TypeGhost.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeNormal.Singleton, 0 }, { TypePsychic.Singleton, 2 },
                { TypeGhost.Singleton, 2 }, { TypeDark.Singleton, 0.5 },
            };

        Affinities[TypeDragon.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeIce.Singleton, 0.5 }, { TypeFlying.Singleton, 2 },
                { TypeDragon.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
                { TypeFairy.Singleton, 0 }, { TypeLight.Singleton, 2 },
            };

        Affinities[TypeDark.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFighting.Singleton, 0.5 }, { TypePsychic.Singleton, 2 },
                { TypeGhost.Singleton, 2 }, { TypeDark.Singleton, 0.5 },
                { TypeFairy.Singleton, 0.5 }, { TypeLight.Singleton, 2 },
            };

        Affinities[TypeSteel.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 0.5 }, { TypeWater.Singleton, 0.5 },
                { TypeElectric.Singleton, 0.5 }, { TypeIce.Singleton, 2 },
                { TypeRock.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
                { TypeFairy.Singleton, 2 },
            };

        Affinities[TypeFairy.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeFire.Singleton, 0.5 }, { TypeFighting.Singleton, 2 },
                { TypePoison.Singleton, 0.5 }, { TypeDragon.Singleton, 2 },
                { TypeDark.Singleton, 2 }, { TypeSteel.Singleton, 0.5 },
                { TypeLight.Singleton, 0 },
            };

        Affinities[TypeLight.Singleton] =
            new Dictionary<PokeType, double>
            {
                { TypeWater.Singleton, 2 }, { TypeElectric.Singleton, 2 },
                { TypeIce.Singleton, 0.5 }, { TypeGround.Singleton, 0.5 },
                { TypeGhost.Singleton, 2 }, { TypeDark.Singleton, 2 },
                { TypeFairy.Singleton, 0 }, { TypeLight.Singleton, 0.5 },
            };
    }

    private static double GetAffinity(PokeType attacker, PokeType defender)
        => Affinities[attacker].GetValueOrDefault(defender, 1);

    public double CalculateAffinity(IEnumerable<PokeType> defenders)
        => defenders.Select(defender => GetAffinity(this, defender))
                    .Aggregate((a, b) => a * b);

    public override string ToString()
        => $"{Name}";
    #endregion
}