using Pokedex.Enums;

namespace Pokedex.Models
{
	public class DamageInfo
	{
		#region Variables
		private DamageClass _class;
		private int _power;
		private PokeType? _type;

		#endregion

		#region Properties
		public DamageClass Class => this._class;
		public int Power => this._power;
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