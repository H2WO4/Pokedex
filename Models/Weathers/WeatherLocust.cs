using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Weathers;

public class WeatherLocust : Weather
{
    #region Class Variables
    private static WeatherLocust? _singleton;
    #endregion

    #region Properties
    public static WeatherLocust Singleton
        => _singleton ??= new WeatherLocust();

    private static IEnumerable<PokeType> TypeSelector
    {
        get
        {
            yield return TypeBug.Singleton;
            yield return TypePoison.Singleton;
            yield return TypeGrass.Singleton;
        }
    }
    #endregion

    #region Constructors
    private WeatherLocust()
        : base("Locust Swarm")
    {
        TypePower.Add(TypeBug.Singleton, 1.5f);
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
            Console.WriteLine($"{poke} is buffeted by the locust swarm!");
            InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, 6.25), poke);
        }
    }

    // Flavor Text
    public override void OnTurnStart(I_Combat arena)
        => Console.WriteLine("The swarm of locusts is flying around.");

    public override void OnEnter()
        => Console.WriteLine("Locusts are starting to swarm the area!");

    public override void OnExit()
        => Console.WriteLine("The swarm of locusts has dispersed.");
    #endregion
}