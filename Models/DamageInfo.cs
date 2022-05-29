using System.Diagnostics.Contracts;

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
    public CalcClass Class { get; }

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
    public Stat AttackStats { get; set; }

    /// <summary>
    /// The stats used to reduce damage
    /// </summary>
    public Stat DefenseStats { get; set; }

    /// <summary>
    /// Represent how much of the inflicted damage should be recovered as HP to the attacker
    /// </summary>
    public int DrainPower { get; set; }

    /// <summary>
    /// Whenever the move makes contact
    /// </summary>
    public bool Contact { get; init; }
    #endregion

    #region Constructors
    public DamageInfo(CalcClass @class, double power, PokeType type = null!)
    {
        Class = @class;
        Power = power;
        Type  = type;
    }
    #endregion

    #region Methods
    [Pure]
    public static DamageInfo CreatePhysical(int power, PokeType type)
        => new(CalcClass.Calculated, power, type)
           {
               AttackStats = Stat.Attack, DefenseStats = Stat.Defense,
               Contact     = true,
           };

    [Pure]
    public static DamageInfo CreatePhysicalNoContact(int power, PokeType type)
        => new(CalcClass.Calculated, power, type)
           {
               AttackStats = Stat.Attack, DefenseStats = Stat.Defense,
               Contact     = false,
           };

    [Pure]
    public static DamageInfo CreateSpecial(int power, PokeType type)
        => new(CalcClass.Calculated, power, type)
           {
               AttackStats = Stat.SpecialAttack, DefenseStats = Stat.SpecialDefense,
               Contact     = false,
           };

    [Pure]
    public static DamageInfo CreateSpecialContact(int power, PokeType type)
        => new(CalcClass.Calculated, power, type)
           {
               AttackStats = Stat.SpecialAttack, DefenseStats = Stat.SpecialDefense,
               Contact     = true,
           };
    #endregion
}