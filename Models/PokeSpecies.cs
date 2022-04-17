using Pokedex.Enums;

namespace Pokedex.Models;

/// <summary>
/// Contains the immutable info of a Pokemon
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
    /// Types the Pokemon possesses
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

    /// <summary>
    /// Determine if this form can be used only in combat
    /// </summary>
    public bool BattleOnly { get; }
    #endregion

    #region Constructors
    protected PokeSpecies(
        int id, string name,
        List<PokeType> types,
        Dictionary<Stat, int> stats,
        int generation, string genus, PokeClass @class,
        int height, int weight,
        bool battleOnly = false
    )
    {
        ID         = id;
        Name       = name;
        Types      = types;
        Stats      = stats;
        Generation = generation;
        Genus      = genus;
        Class      = @class;
        Height     = height;
        Weight     = weight;
        BattleOnly = battleOnly;
    }
    #endregion
}