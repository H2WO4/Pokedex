using Pokedex.Interfaces;

namespace Pokedex.Models
{
	/// <summary>
	/// A weather effect happening during a fight
	/// </summary>
	public abstract class Weather
	{
		#region Variables
		protected readonly Dictionary<PokeType, float> TypePower;
		protected readonly List<PokeType> TypeSelector;
		#endregion

		#region Properties
		/// <summary>
		/// The name used for display
		/// </summary>
		public string Name { get; }
		#endregion

		#region Constructors
		protected Weather(string name)
		{
			Name = name;
			TypePower = new Dictionary<PokeType, float>();
			TypeSelector = new List<PokeType>();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Called whenever damage is inflicted
		/// </summary>
		/// <param name="damage">The damage inflicted</param>
		/// <param name="type">The type of the damage</param>
		/// <returns>The new damage value</returns>
		public virtual double OnDamageGive(double damage, PokeType type)
			=> TypePower.GetValueOrDefault(type, 1) * damage;

		/// <summary>
        /// Called at a weather change, when this is the new weather
        /// </summary>
		public virtual void OnEnter() { }

		/// <summary>
        /// Called at a weather change, when this is the old weather
        /// </summary>
		public virtual void OnExit() { }

		/// <summary>
        /// Called at the beginning of a turn
        /// </summary>
		/// <param name="arena">The fight in which the weather is active</param>
		public virtual void OnTurnStart(I_Combat arena) { }

		/// <summary>
		/// Called at the end of a turn
		/// </summary>
		/// <param name="arena">The fight in which the weather is active</param>
		public virtual void OnTurnEnd(I_Combat arena) { }
		#endregion
	}
}