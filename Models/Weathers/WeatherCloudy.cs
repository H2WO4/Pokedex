using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Weathers;

public class WeatherCloudy : Weather
{
    #region Class Variables
    private static WeatherCloudy? _singleton;
    #endregion

    #region Properties
    public static WeatherCloudy Singleton
        => _singleton ??= new WeatherCloudy();
    #endregion

    #region Constructors
    private WeatherCloudy()
        : base("Cloudy")
    {
        TypePower.Add(TypeNormal.Singleton, 1f);
    }
    #endregion

    #region Methods
    public override double OnDamageGive(in double damage, in PokeType type)
        => TypePower.GetValueOrDefault(type, 0.75f) * damage;

    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("The sky is cloudy.");

    public override void OnEnter()
        => Console.WriteLine("The sky filled with clouds!");

    public override void OnExit()
        => Console.WriteLine("The clouds disappeared.");
    #endregion
}