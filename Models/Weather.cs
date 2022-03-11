using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public abstract class Weather : I_Weather
	{
		#region Variables
		private string _name;
		protected Dictionary<PokeType, float> _typePower;
		protected PokeType[] _typeSelector;
		#endregion

		#region Properties
		public string Name { get => this._name; }
		#endregion

		#region Constructors
		protected Weather(string name)
		{
			this._name = name;
			this._typePower = new Dictionary<PokeType, float>();
			this._typeSelector = new PokeType[] { };
		}
		#endregion

		#region Methods
		// Stats
		public virtual double OnDamageGive(double damage, PokeType type) =>
			this._typePower.GetValueOrDefault(type, 1) * damage;

		// Weather Enter/Exit
		public virtual void OnEnter() { }
		public virtual void OnExit() { }

		// Turn Start/End
		public virtual void OnTurnStart(Combat context) { }
		public virtual void OnTurnEnd(Combat context) { }
		#endregion
	}
}