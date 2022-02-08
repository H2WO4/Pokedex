namespace Pokedex.Models.Weathers
{
    public class WeatherHail : Weather
    {
        # region Class Variables
        private static WeatherHail? _singleton;
        # endregion

        # region Properties
        public static WeatherHail Singleton { get => _singleton ?? (_singleton = new WeatherHail()); }
        # endregion

        # region Constructors
        protected WeatherHail() : base("Hail")
        {
            this._typePower.Add("Ice", 1.5f);

            this._typeSelector.Add("Ice");
            this._typeSelector.Add("Water");
            this._typeSelector.Add("Light");
        }
        # endregion

        # region Methods
        public override void OnTurnEnd(CombatInstance context)
        {
            if (context.ActiveA.Types
                    .Select(x => x.Name)
                    .Intersect(this._typeSelector)
                    .Count() == 0)
            {
                Console.WriteLine($"{context.ActiveA.Name} is buffeted by the hail!");
                // Damage logic
            }
            
            if (context.ActiveB.Types
                    .Select(x => x.Name)
                    .Intersect(this._typeSelector)
                    .Count() == 0)
            {
                Console.WriteLine($"{context.ActiveB.Name} is buffeted by the hail!");
                // Damage logic
            }
        }

        // Flavor Text
        public override void OnTurnStart(CombatInstance context) =>
            Console.WriteLine("Hail continues to fall.");
        public override void OnEnter() =>
            Console.WriteLine("It started to hail!");
        public override void OnExit() =>
            Console.WriteLine("The hail stopped.");
        
        # endregion
    }
}