using System.Drawing;
using System.Text;
using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;


namespace Pokedex.Models
{
	public abstract class PokemonMove : I_PokemonMove
	{
		#region Variables
		protected string _name;
		protected MoveClass _class;
		protected PokemonType _type;
		protected int? _power;
		protected int? _accuracy;
		protected int _maxPp;
		protected int _pp;
		protected int _priority;
		#endregion

		#region Properties
		// * Values
		public string Name { get => this._name; }
		public int? Power { get => this._power; }
		public MoveClass Class { get => this._class; }
		public int? Accuracy { get => this._accuracy; }
		public int MaxPP { get => this._maxPp; }
		public int PP { get => this._pp; }
		public int Priority { get => this._priority; }
		public PokemonType Type { get => this._type; }

		#endregion

		#region Constructors
		public PokemonMove(
			string name,
			MoveClass class_,
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
		#endregion

		#region Methods
		// * Game Logic
		public virtual void OnUse(Pokemon caster, Player origin, CombatInstance context)
		{
			// Select targets
			var targets = this.GetTargets(caster, origin, context);

			// If it hits, deal damage, and check if fainted
			foreach (var target in targets)
			{
				var hit = this.AccuracyCheck(target.pokemon, target.player, caster, origin, context);

				if (hit)
					this.DoAction(target.pokemon, target.player, caster, origin, context);
				else
					Console.WriteLine($"{caster.Nickname}'s {this.Name} missed {target.pokemon.Nickname}\n");
			}
		}

		public virtual bool AccuracyCheck(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
		{
			if (this._accuracy == null)
				return true;

			return (this._accuracy ?? 100) >= Program.rnd.Next(1, 100);
		}

		public virtual List<(Player player, Pokemon pokemon)> GetTargets(Pokemon caster, Player origin, CombatInstance context)
		{
			var enemy = context.PlayerA == origin
						? context.PlayerB
						: context.PlayerA;

			return new List<(Player, Pokemon)>()
			{
				(enemy, enemy.Active)
			};
		}

		public virtual void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context)
		{
			bool success = target.ReceiveDamage(owner, caster, this, this._type, context);
			if (!success)
				Console.WriteLine("But it failed");
		}

		public virtual void PreAction(MoveEvent event_, CombatInstance context) { }

		// * Display
		public string GetQuickStatus()
			=> $"{this._name} - {this._pp}/{this._maxPp} PP";

		public string GetFullStatus()
		{
			var output = new StringBuilder();

			output.AppendLine($"{this._name,-12}   {this._class}-{this._type.Name}");

			output.Append($"\x1b[38;2;219;112;147mPower\x1b[0m: {this._power?.ToString() ?? "---",4}    ");
			// Displays "---" if the power is null, displays it normally otherwise
			output.AppendLine($"\x1b[38;2;173;216;230mAccuracy\x1b[0m: {this._accuracy?.ToString("#'%'") ?? "---",4}");
			// Displays "---" if the accuracy is null, displays it with a '%' appended otherwise
			// Color.Orange
			output.Append($"\x1b[38;2;144;238;144mPP\x1b[0m:   {this._pp,2}/{this._maxPp,2}    ");
			output.AppendLine($"\x1b[38;2;255;165;0mPriority\x1b[0m:  {this._priority,3:+#;-#;0}");
			// Format specificator :
			//	+# -> case if x > 0, displays "+x"
			//	-# -> case if x < 0, displays "-x"
			//	0 -> case if x = 0, displays "0"

			return output.ToString();
		}
		#endregion
	}
}