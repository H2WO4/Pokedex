using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers;

public class WeatherAsh : Weather
{
    #region Class Variables
    private static WeatherAsh? _singleton;
    #endregion

    #region Properties
    public static WeatherAsh Singleton
        => _singleton ??= new WeatherAsh();
    #endregion

    #region Constructors
    private WeatherAsh()
        : base("Ash Cloud")
    {
        TypePower.Add(TypeGround.Singleton, 1.5f);
        TypePower.Add(TypeFlying.Singleton, 0.5f);
    }
    #endregion

    #region Methods
    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("The sky is still shrouded in ash.");

    public override void OnEnter()
        => Console.WriteLine("The sky is thick with ash!");

    public override void OnExit()
        => Console.WriteLine("The thick ash veil lifts.");
    #endregion
}