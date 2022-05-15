using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Weathers;

public class WeatherHail : Weather
{
    #region Class Variables
    private static WeatherHail? _singleton;
    #endregion

    #region Properties
    public static WeatherHail Singleton
        => _singleton ??= new WeatherHail();

    private static IEnumerable<PokeType> TypeSelector
    {
        get
        {
            yield return TypeIce.Singleton;
            yield return TypeWater.Singleton;
            yield return TypeLight.Singleton;
        }
    }
    #endregion

    #region Constructors
    private WeatherHail()
        : base("Hail")
    {
        TypePower.Add(TypeIce.Singleton, 1.5f);
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
            Console.WriteLine($"{poke} is buffeted by the hail!");
            InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, 6.25), poke);
        }
    }

    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("Hail continues to fall.");

    public override void OnEnter()
        => Console.WriteLine("It started to hail!");

    public override void OnExit()
        => Console.WriteLine("The hail stopped.");
    #endregion
}