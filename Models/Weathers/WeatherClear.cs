using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
    public class WeatherClear : Weather
    {
        # region Class Variables
        private static WeatherClear? _singleton;
        # endregion

        # region Properties
        public static WeatherClear Singleton { get => _singleton ?? (_singleton = new WeatherClear()); }
        # endregion

        # region Constructors
        protected WeatherClear() : base("Clear") {}
        # endregion

        # region Methods
        // Flavor Text
        public override void OnEnter() =>
            Console.WriteLine("The sky clears up.");
        
        # endregion
    }
}