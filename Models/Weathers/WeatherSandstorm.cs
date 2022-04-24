using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Weathers;

public class WeatherSandstorm : Weather
{
    #region Class Variables
    private static WeatherSandstorm? _singleton;
    #endregion

    #region Properties
    public static WeatherSandstorm Singleton
        => _singleton ??= new WeatherSandstorm();

    private static IEnumerable<PokeType> TypeSelector
    {
        get
        {
            yield return TypeRock.Singleton;
            yield return TypeSteel.Singleton;
            yield return TypeGround.Singleton;
        }
    }
    #endregion

    #region Constructors
    private WeatherSandstorm()
        : base("Sandstorm")
    {
        TypePower.Add(TypeRock.Singleton, 1.5f);
    }
    #endregion

    #region Methods
    public override void OnTurnEnd(I_Combat arena)
    {
        IEnumerable<I_Battler> attacked =
            arena.Players
                 .Select(player => player.Active)
                 .Where(poke => poke.Types
                                    .Intersect(TypeSelector)
                                    .Any() is false);

        foreach (I_Battler poke in attacked)
        {
            Console.WriteLine($"{poke} is buffeted by the sandstorm!");
            DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 6.25), poke);
        }
    }

    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("The sandstorm rages.");

    public override void OnEnter()
        => Console.WriteLine("A sandstorm kicked up!");

    public override void OnExit()
        => Console.WriteLine("The sandstorm subsided.");
    #endregion
}