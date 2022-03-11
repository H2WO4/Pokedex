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
		protected PokeType _type;
		protected int? _power;
		protected int? _accuracy;
		protected int _maxPp;
		protected int _pp;
		protected int _priority;
		#endregion

		#region Properties
		// * Values
		public string Name => this._name;
		public int? Power => this._power;
		public MoveClass Class => this._class;
		public int? Accuracy => this._accuracy;
		public int MaxPP => this._maxPp;
		public int PP => this._pp;
		public int Priority => this._priority;
		public PokeType Type => this._type;

		#endregion

		#region Constructors
		public PokemonMove(
			string name,
			MoveClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
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
		public virtual void OnUse(Pokemon caster, Trainer origin, Combat context)
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
					Console.WriteLine($"{caster.Name}'s {this.Name} missed {target.pokemon.Name}\n");
			}
		}

		public virtual bool AccuracyCheck(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
		{
			if (this._accuracy == null)
				return true;

			return (this._accuracy ?? 100) >= Program.rnd.Next(1, 100);
		}

		public virtual List<(Trainer player, Pokemon pokemon)> GetTargets(Pokemon caster, Trainer origin, Combat context)
		{
			var enemy = context.PlayerA == origin
						? context.PlayerB
						: context.PlayerA;

			return new List<(Trainer, Pokemon)>()
			{
				(enemy, enemy.Active)
			};
		}

		public virtual void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
		{
			bool success = target.ReceiveDamage(owner, caster, this, this._type, context);
			if (!success)
				Console.WriteLine("But it failed");
		}

		public virtual void PreAction(MoveEvent event_, Combat context) { }

		// * Display
		public string GetQuickStatus()
			=> $"{this._name} - {this._pp}/{this._maxPp} \x1b[38;2;144;238;144mPP\x1b[0m";

		public string GetFullStatus()
		{
			var status = new StringBuilder();
			var classColor = this._class == MoveClass.Physical ? "\x1b[38;2;245;78;10m"
							: this._class == MoveClass.Special ? "\x1b[38;2;38;117;244m"
							: "\x1b[38;2;90;99;123m";

			// Add the name
			status.Append($"\x1b[1m{this._name,-12}\x1b[0m   ");
			// Add the class and type
			status.AppendLine($"{classColor}{this._class}\x1b[0m-{this._type}");
			// Add the Power, '---' if null
			status.Append($"\x1b[38;2;219;112;147mPower\x1b[0m: {this._power?.ToString() ?? "---",4}      ");
			// Add the Accuracy, '---' if null
			status.AppendLine($"\x1b[38;2;173;216;230mAccuracy\x1b[0m: {this._accuracy?.ToString("#'%'") ?? "---",4}");
			// Add the PP
			status.Append($"\x1b[38;2;144;238;144mPP\x1b[0m:   {this._pp,2}/{this._maxPp,2}      ");
			// Add the Priority, with sign if positive, but not if 0
			status.AppendLine($"\x1b[38;2;255;165;0mPriority\x1b[0m:  {this._priority,3:+#;-#;0}");

			return status.ToString();
		}
		#endregion
	}
}