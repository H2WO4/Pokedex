using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Weathers;

public class WeatherEclipse : Weather
{
    #region Class Variables
    private static WeatherEclipse? _singleton;
    #endregion

    #region Properties
    public static WeatherEclipse Singleton
        => _singleton ??= new WeatherEclipse();
    #endregion

    #region Constructors
    private WeatherEclipse()
        : base("Solar Eclipse")
    {
        TypePower.Add(TypeDragon.Singleton, 1.5f);
        TypePower.Add(TypeFairy.Singleton, 0.5f);
    }
    #endregion

    #region Methods
    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("The sun is still eclipsed.");

    public override void OnEnter()
        => Console.WriteLine("The moon now eclipses the sun!");

    public override void OnExit()
        => Console.WriteLine("The light of the sun has returned.");
    #endregion
}