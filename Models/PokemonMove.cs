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
		protected Pokemon? _caster;
		#endregion

		#region Properties
		/// <inheritdoc/>
		public string Name => this._name;

		/// <inheritdoc/>
		public int? Power => this._power;

		/// <inheritdoc/>
		public MoveClass Class => this._class;

		/// <inheritdoc/>
		public int? Accuracy => this._accuracy;

		/// <inheritdoc/>
		public int MaxPP => this._maxPp;

		/// <inheritdoc/>
		public int PP => this._pp;

		/// <inheritdoc/>
		public int Priority => this._priority;

		/// <inheritdoc/>
		public PokeType Type => this._type;

		/// <inheritdoc/>
        public Pokemon Caster => this._caster ?? throw new InvalidOperationException();
		
		/// <inheritdoc/>
		public I_Combat Arena => this.Arena;

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
		public virtual void OnUse()
		{
			// Select targets
			var targets = this.GetTargets();

			// If it hits, deal damage, and check if fainted
			foreach (var target in targets)
			{
				var hit = this.AccuracyCheck(target);

				if (hit)
					this.DoAction(target);
				else
					Console.WriteLine($"{this.Caster.Name}'s {this.Name} missed {target.Name}\n");
			}
		}

		protected virtual List<Pokemon> GetTargets()
			=> this.Arena.Players
				.Where(player => player != this.Caster.Owner)
				.Select(player => player.Active)
				.ToList();

		protected virtual bool AccuracyCheck(Pokemon target)
		{
			if (this._accuracy == null)
				return true;

			return (this._accuracy ?? 100) >= Program.rnd.Next(1, 100);
		}

		protected virtual void DoAction(Pokemon target)
		{
			bool success = target.ReceiveDamage(this.Caster, this, this._type);
			if (!success)
				Console.WriteLine("But it failed");
		}

		/// <inheritdoc/>
		public virtual void PreAction(MoveEvent event_) { }

		/// <inheritdoc/>
		public string GetQuickStatus()
			=> $"{this._name} - {this._pp}/{this._maxPp} \x1b[38;2;144;238;144mPP\x1b[0m";

		/// <inheritdoc/>
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