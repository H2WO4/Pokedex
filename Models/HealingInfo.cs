using Pokedex.Enums;

namespace Pokedex.Models;

/// <summary>
/// Represent a amount of healing, as well as its properties
/// </summary>
public class HealInfo
{
    #region Properties
    /// <summary>
    /// The class of heal this is
    /// </summary>
    public DamageClass Class { get; }

    /// <summary>
    /// How much health is being healed
    /// </summary>
    /// <remarks>
    /// Pure → Raw heal number<br />
    /// Percent → Percentage of MaxHP<br />
    /// Calculated → Invalid
    /// </remarks>
    public double Power { get; set; }
    #endregion

    #region Constructors
    public HealInfo(DamageClass @class, double power)
    {
        Class = @class;
        Power = power;
    }
    #endregion
}