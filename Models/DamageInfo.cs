using Pokedex.Enums;

namespace Pokedex.Models
{
	/// <summary>
	/// Represent a amount of damage, as well as its properties
	/// </summary>
	public class DamageInfo
	{
		#region Variables
		private DamageClass _class;
		private int _power;
		private PokeType? _type;

		#endregion

		#region Properties
		/// <summary>
		/// The class of damage this is
		/// </summary>
		public DamageClass Class => this._class;

		/// <summary>
		/// How much damage is being dealt
		/// </summary>
		public int Power => this._power;

		/// <summary>
		/// The type of the damage, if there is one
		/// </summary>
		public PokeType? Type => this._type;
		#endregion

		#region Constructors
		public DamageInfo(DamageClass class_, int power, PokeType? type)
		{
			this._class = class_;
			this._power = power;
			this._type = type;
		}
		#endregion

		#region Methods
		#endregion
	}
}