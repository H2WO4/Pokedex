using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers;

public class WeatherZenith : Weather
{
    #region Class Variables
    private static WeatherZenith? _singleton;
    #endregion

    #region Properties
    public static WeatherZenith Singleton
        => _singleton ??= new WeatherZenith();
    #endregion

    #region Constructors
    private WeatherZenith()
        : base("Zenith")
    {
        TypePower.Add(TypeFire.Singleton, 1.5f);
        TypePower.Add(TypeWater.Singleton, 0.5f);
    }
    #endregion

    #region Methods
    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("Bright sunlight washes over the battlefield.");

    public override void OnEnter()
        => Console.WriteLine("The sun rises to its zenith!");

    public override void OnExit()
        => Console.WriteLine("The sun has set.");
    #endregion
}