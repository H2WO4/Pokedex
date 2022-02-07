namespace Pokedex.Models.Weathers
{
    public class WeatherSunny : Weather
    {
        # region Class Variables
        private static WeatherSunny? _singleton;
        # endregion

        # region Properties
        public static WeatherSunny Singleton { get => _singleton ?? (_singleton = new WeatherSunny()); }
        # endregion

        # region Constructors
        protected WeatherSunny() : base("Sunny")
        {
            this._typePower.Add("Fire", 1.5f);
            this._typePower.Add("Water", 0.5f);
        }
        # endregion

        # region Methods
        // Flavor Text
        public override void OnTurnStart(CombatInstance context) =>
            Console.WriteLine("The sunlight is strong.");
        public override void OnEnter() =>
            Console.WriteLine("The sunlight turned harsh!");
        public override void OnExit() =>
            Console.WriteLine("The harsh sunlight faded.");
        
        # endregion
    }
}