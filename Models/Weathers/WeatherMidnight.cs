using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers;

public class WeatherMidnight : Weather
{
    #region Class Variables
    private static WeatherMidnight? _singleton;
    #endregion

    #region Properties
    public static WeatherMidnight Singleton
        => _singleton ??= new WeatherMidnight();
    #endregion

    #region Constructors
    private WeatherMidnight()
        : base("Midnight")
    {
        TypePower.Add(TypeDark.Singleton, 1.5f);
        TypePower.Add(TypeLight.Singleton, 0.5f);
    }
    #endregion

    #region Methods
    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("Moonlight shines through the night sky.");

    public override void OnEnter()
        => Console.WriteLine("The moon is rising to its apex!");

    public override void OnExit()
        => Console.WriteLine("The moon has set.");
    #endregion
}