namespace Pokedex.Models.Weathers
{
    public class WeatherFog : Weather
    {
        # region Class Variables
        private static WeatherFog? _singleton;
        # endregion

        # region Properties
        public static WeatherFog Singleton { get => _singleton ?? (_singleton = new WeatherFog()); }
        # endregion

        # region Constructors
        protected WeatherFog() : base("Fog")
        {
            this._typePower.Add("Ghost", 1.5f);
            this._typePower.Add("Electric", 0.5f);
            this._typePower.Add("Light", 0.5f);
        }
        # endregion

        # region Methods
        // Flavor Text
        public override void OnTurnStart(CombatInstance context) =>
            Console.WriteLine("Mist swirls in the air!");
        public override void OnEnter() =>
            Console.WriteLine("Mist swirls around the battlefield!");
        public override void OnExit() =>
            Console.WriteLine("The mist clears away.");
        
        # endregion
    }
}