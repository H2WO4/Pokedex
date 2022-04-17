using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers;

public class WeatherLocust : Weather
{
    #region Class Variables
    private static WeatherLocust? _singleton;
    #endregion

    #region Properties
    public static WeatherLocust Singleton
        => _singleton ??= new WeatherLocust();
    #endregion

    #region Constructors
    private WeatherLocust()
        : base("Locust Swarm")
    {
        TypePower.Add(TypeBug.Singleton, 1.5f);

        TypeSelector.Add(TypeBug.Singleton);
        TypeSelector.Add(TypePoison.Singleton);
        TypeSelector.Add(TypeGrass.Singleton);
    }
    #endregion

    #region Methods
    public override void OnTurnEnd(I_Combat arena)
    {
        arena.Players
             .Select(player => player.Active)
             .Where(poke => poke.Types.Intersect(TypeSelector)
                                .Any())
             .ToList()
             .ForEach(poke => Console.WriteLine($"{poke.Name} is buffeted by the locust swarm!"));
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