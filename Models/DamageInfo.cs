using Pokedex.Enums;

namespace Pokedex.Models;

/// <summary>
/// Represent a amount of damage, as well as its properties
/// </summary>
public class DamageInfo
{
    #region Properties
    /// <summary>
    /// The class of damage this is
    /// </summary>
    public DamageClass Class { get; }

    /// <summary>
    /// How much damage is being dealt
    /// </summary>
    /// <remarks>
    /// Pure → Raw damage number<br />
    /// Percent → Percentage of MaxHP<br />
    /// Calculated → Multiplier
    /// </remarks>
    public double Power { get; set; }

    /// <summary>
    /// The type of the damage
    /// </summary>
    public PokeType? Type { get; set; }

    /// <summary>
    /// The stats used to augment damage
    /// </summary>
    public Stat AttackStats { get; init; }

    /// <summary>
    /// The stats used to reduce damage
    /// </summary>
    public Stat DefenseStats { get; init; }

    /// <summary>
    /// Whenever the move makes contact
    /// </summary>
    public bool Contact { get; init; }
    #endregion

    #region Constructors
    public DamageInfo(DamageClass @class, double power, PokeType type = null!)
    {
        Class = @class;
        Power = power;
        Type  = type;
    }
    #endregion

    #region Methods
    public static DamageInfo CreatePhysical(int power, PokeType type)
        => new(DamageClass.Calculated, power, type)
           {
               AttackStats = Stat.Atk, DefenseStats = Stat.Def, Contact = true,
           };

    public static DamageInfo CreatePhysicalNoContact(int power, PokeType type)
        => new(DamageClass.Calculated, power, type)
           {
               AttackStats = Stat.Atk, DefenseStats = Stat.Def, Contact = false,
           };

    public static DamageInfo CreateSpecial(int power, PokeType type)
        => new(DamageClass.Calculated, power, type)
           {
               AttackStats = Stat.SpAtk, DefenseStats = Stat.SpDef, Contact = false,
           };

    public static DamageInfo CreateSpecialContact(int power, PokeType type)
        => new(DamageClass.Calculated, power, type)
           {
               AttackStats = Stat.SpAtk, DefenseStats = Stat.SpDef, Contact = true,
           };
    #endregion
}