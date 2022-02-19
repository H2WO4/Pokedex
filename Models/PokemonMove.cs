using Pokedex.Interfaces;
using Pokedex.Enums;

namespace Pokedex.Models
{
	public abstract class PokemonMove : I_PokemonMove
	{
		# region Variables
		protected string _name;
		protected SkillClass _class;
		protected int? _power;
		protected int? _accuracy;
		protected int _maxPp;
		protected int _pp;
		protected int _priority;
		protected PokemonType _type;
		# endregion

		# region Properties
		// Values
		public string Name { get => this._name; }
		public int? Power { get => this._power; }
		public SkillClass Class { get => this._class; }
		public int? Accuracy { get => this._accuracy; }
		public int MaxPP { get => this._maxPp; }
		public int PP { get => this._pp; }
		public int Priority { get => this._priority; }
		public PokemonType Type { get => this._type; }

		// Others
		public string QuickStatus { get => $"{this.Name} - {this._pp}/{this._maxPp} PP"; }
		public string FullStatus { get => string.Join('\n', new string[]{
			$"{this._name, -12}   {this._class}-{this._type.Name}",
			$"Power: {this._power, 4}    Accuracy: {this._accuracy, 3}%",
			$"PP:   {this._pp, 2}/{this._maxPp, 2}    Priority: {this._priority, 2:+#;-#;0}",
		}); }
		# endregion

		# region Constructors
		public PokemonMove(
			string name,
			SkillClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokemonType type
		)
		{
			if (name != "")
				this._name = name;
			else throw new ArgumentException("Name cannot be empty");

			this._class = class_;
			this._power = power;
			this._accuracy = accuracy;
			this._maxPp = maxPp;
			this._pp = maxPp;
			this._priority = priority;
			this._type = type;
		}
		# endregion

		# region Methods
		public abstract void OnUse(Pokemon origin, List<Pokemon> targets, CombatInstance context);
		
		public virtual void PreAction(CombatInstance context) {}
		# endregion
	}
}