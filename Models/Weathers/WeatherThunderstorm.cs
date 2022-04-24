using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Weathers;

public class WeatherThunderstorm : Weather
{
    #region Class Variables
    private static WeatherThunderstorm? _singleton;
    #endregion

    #region Properties
    public static WeatherThunderstorm Singleton
        => _singleton ??= new WeatherThunderstorm();
    #endregion

    #region Constructors
    private WeatherThunderstorm()
        : base("Thunderstorm")
    {
        TypePower.Add(TypeElectric.Singleton, 1.5f);
        TypePower.Add(TypeSteel.Singleton, 0.5f);
    }
    #endregion

    #region Methods
    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("Lightning crackles in the sky.");

    public override void OnEnter()
        => Console.WriteLine("A thunderstorm is brewing!");

    public override void OnExit()
        => Console.WriteLine("The thunderstorm subsided.");
    #endregion
}