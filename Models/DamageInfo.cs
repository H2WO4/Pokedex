using System.Diagnostics.CodeAnalysis;
using Pokedex.Enums;

namespace Pokedex.Models
{
	/// <summary>
	/// Represent a amount of damage, as well as its properties
	/// </summary>
	public class DamageInfo
	{
		#region Properties
		/// <summary>
		/// The class of damage this is
		/// </summary>
		public DamageClass Class { get; set; }

		/// <summary>
		/// How much damage is being dealt
		/// </summary>
		public int Power { get; set; }

		/// <summary>
		/// The type of the damage
		/// </summary>
		public PokeType? Type { get; set; }

		public string AttackStats { get; init; }

		public string DefenseStats { get; init; }
		#endregion

		#region Constructors
		public DamageInfo(DamageClass class_, int power, PokeType type = null!)
		{
			this.Class = class_;
			this.Power = power;
			this.Type = type;

			this.AttackStats = "";
			this.DefenseStats = "";
		}
		#endregion

		#region Methods
		#endregion
	}
}