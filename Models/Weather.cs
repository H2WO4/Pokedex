using Pokedex.Interfaces;

namespace Pokedex.Models
{
    public abstract class Weather : I_Weather
    {
        # region Variables
        protected string _name;
        protected Dictionary<string, float> _typePower;
        protected List<string> _typeSelector;
        # endregion

        # region Properties
        public string Name { get => this._name; }
        # endregion

        # region Constructors
        protected Weather(string name)
        {
            this._name = name;
            this._typePower = new Dictionary<string, float>();
            this._typeSelector = new List<string>();
        }
        # endregion

        # region Methods
        // Stats
        public virtual float OnDamageGive(float damage, PokemonType type) =>
            this._typePower.GetValueOrDefault(type.Name, 1f) * damage;

        // Weather Enter/Exit
        public virtual void OnEnter() {}
        public virtual void OnExit() {}

        // Turn Start/End
        public virtual void OnTurnStart(CombatInstance context) {}
        public virtual void OnTurnEnd(CombatInstance context) {}
        # endregion
    }
}